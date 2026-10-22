using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.OpenXmlFormats.Dml.Diagram;
using Seagull.BarTender.Print;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class Decode : UserControl
    {
        public event Back back;
        public string DecodeStr = string.Empty;
        public Decode()
        {
            InitializeComponent();
            Printer_Click(null, null);
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Printer))
            {
                Printer.Text = Properties.Settings.Default.Printer;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.PrintFilePath))
            {
                FilePath.Text = Properties.Settings.Default.PrintFilePath;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.PrintFields))
            {
                PrintFields.Text = Properties.Settings.Default.PrintFields;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.InputRegex))
            {
                NumRegex.Text = Properties.Settings.Default.InputRegex;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DecodeRegex))
            {
                DecodeRegex.Text = Properties.Settings.Default.DecodeRegex;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.model))
            {
                Model.Text = Properties.Settings.Default.model;
            }
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }


        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            FilePath.Text = GetOpenPath();
        }

        public static string GetOpenPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // openFileDialog.InitialDirectory = @"D:\";
            openFileDialog.Filter = "模板文件|*.btw";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void Printer_Click(object sender, EventArgs e)
        {
            Printer.Items.Clear();
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                Printer.Items.Add(printerName);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Printer = Printer.Text;
            Properties.Settings.Default.PrintFilePath = FilePath.Text;
            Properties.Settings.Default.PrintFields = PrintFields.Text;
            Properties.Settings.Default.InputRegex = NumRegex.Text;
            Properties.Settings.Default.DecodeRegex = DecodeRegex.Text;
            Properties.Settings.Default.model = Model.Text;
            Properties.Settings.Default.Save();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            ResultTips.Text = "";
            string input = Input.Text;


            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    int length = DecodeRegex.Text.Length;
                    string oldstr = input.Substring(0, length);
                    DecodeStr = Input.Text.Replace(oldstr, DecodeRegex.Text);
                    Regex regex = new Regex("^" + NumRegex.Text + "$");
                    if (regex.IsMatch(DecodeStr))
                    {
                        if (IsCheck())
                        {
                            Print(DecodeStr);
                            ResultTips.Text = Input.Text+"修改为"+DecodeStr + " 打印成功！";
                            DecodeStr = string.Empty;
                        }
                        else
                        {
                            ResultTips.Text = Input.Text + " 服务器查无此记录！";
                        }

                    }
                    else
                    {
                        ResultTips.Text = Input.Text + " 输入值格式错误！";
                    }
                }
                Input.Text = "";
            }




        }

        private void Print(string Value)
        {
            string PrinterName = Printer.Text;


            if (!string.IsNullOrEmpty(Value))
            {

                if (PrinterName != "")
                {
                    if (File.Exists(FilePath.Text))
                    {
                        Engine btEngine = new Engine();

                        bool isAlive = btEngine.IsAlive;

                        btEngine.Start();

                        LabelFormatDocument btFormat = btEngine.Documents.Open(FilePath.Text);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                        btFormat.PrintSetup.PrinterName = PrinterName;

                        btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数


                        btFormat.SubStrings[PrintFields.Text].Value = Value;


                        Messages messages;

                        //int waitout = 500; // 5秒 超时

                        //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                        Result nResult = btFormat.Print("打印工具", out messages);

                        btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;

                        btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改

                        btEngine.Stop();
                    }
                    else
                    {
                        MessageBox.Show("打印模板不存在，或打印模板命名无效");
                    }

                }
                else
                {
                    MessageBox.Show("未设置默认打印机，请先设置默认打印机！");
                }


            }
            else
            {
                MessageBox.Show("输入为空不能打印，请等待设备连接成功后在尝试打印！");
            }

        }

        public async Task<Hashtable> GetDutFields(string model, string fields, string value)
        {
            Hashtable DutFieldsList = new Hashtable();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://192.168.8.2:8090/box_cms_v3/mes_v1/getDutFields.php"),
                Content = new MultipartFormDataContent
                 {

                    new StringContent(model)
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "model",
                            }
                        }
                    },
                    new StringContent(fields)
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "dut_number_name",
                            }
                        }
                    },
                    new StringContent(value)
                    {
                        Headers =
                         {
                                ContentDisposition = new ContentDispositionHeaderValue("form-data")
                                {
                                    Name = "dut_number_value",
                                }
                         }
                    },
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var Json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(Json);
                if (!Json.Contains("{\"resultCode\":\"9999\",\"resultMsg\":\"查询到的数据为空！\"}"))
                {
                    JObject jArray = (JObject)JsonConvert.DeserializeObject(Json);
                    DutFieldsList = JsonConvert.DeserializeObject<Hashtable>(jArray["fields"].ToString());
                }
            }
            return DutFieldsList;
        }

        private List<string> GetModel()
        {
            string Url = "http://192.168.8.8/testbackground/web/index.php?r=/admin-devInfos/model/modelids&access-token=k_Cfne5tZGexkDO1XqDGKHYU2mZi_vpI";
            string Json = Post(Url);
            JObject jArray = (JObject)JsonConvert.DeserializeObject(Json);
            string items = jArray["data"]["items"].ToString();
            JArray models = (JArray)JsonConvert.DeserializeObject(items);
            List<string> modellist = new List<string>();
            for(int x =0; x<models.Count; x++)
            {
                string model = models[x]["model_name"].ToString();
                modellist.Add(model);
            }
            modellist.Sort();
            return modellist;
            
        }

        private bool IsCheck()
        {
            bool result = false;
            string Url = "http://192.168.8.2:8090/box_cms_v3/mes_v1/getDutFields.php?model="+Model.Text+"&dut_number_name="+PrintFields.Text+"&dut_number_value="+DecodeStr;
            string Json = Post(Url);
            JObject jArray = (JObject)JsonConvert.DeserializeObject(Json);
            string Value = string.Empty;
            if (jArray["resultMsg"].ToString() == "success")
            {
                Value = jArray["fields"][PrintFields.Text].ToString();

            }
            if (Value == DecodeStr)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="Url">访问链接</param>
        /// <param name="jsonStr">所需上传的json格式数据</param>
        /// <returns></returns>
        public string Post(string Url, string jsonStr = "")
        {
            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/json";
            //设置参数，并进行URL编码 
            string paraUrlCoded = jsonStr;//System.Web.HttpUtility.UrlEncode(jsonParas);   
            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;
            //发送请求，获得请求流 
            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception ex)
            {
                writer = null;
                throw ex;
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流
                           // String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
            Stream s = response.GetResponseStream();
            //  Stream postData = Request.InputStream;
            StreamReader sRead = new StreamReader(s);
            string postContent = sRead.ReadToEnd();
            sRead.Close();
            return postContent;//返回Json数据
        }
    }
}
