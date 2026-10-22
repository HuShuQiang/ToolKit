using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class CheckQRForm : UserControl
    {
        public event Back back;
        private string Value1 { get; set; }
        private string Value2 { get; set; }
        private List<string> ValueList { get; set; }
        private string SN { get; set; }
        private LogHelper Log;
        public CheckQRForm()
        {
            InitializeComponent();
            Log = new LogHelper();
            Input1.KeyDown += new KeyEventHandler(Input);
            Input2.KeyDown += new KeyEventHandler(Input);
            Input2.GotFocus += new EventHandler(Focus);
            ComeBack.Click += new EventHandler(ComeBack_Click);
            Input1.Focus();
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
            BackColor = Color.LimeGreen;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Input1.Text))
            {
                Input1.Focus();
            }
        }

        private void Input(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Name == "Input1")
                {
                    Value1 = Input1.Text;
                    if (Value1.Contains("&"))
                    {
                        GetValueList(Value1);
                    }
                    Input2.Focus();
                    ResultTips.Text = "";
                    ResultTips.BackColor = Color.LimeGreen;


                }
                else if (textBox.Name == "Input2")
                {
                    Value2 = Input2.Text;
                    if (Value2.Contains("&"))
                    {
                        GetValueList(Value2);
                    }
                    CheckNum();
                }
            }
        }

        private void GetValueList(string Value)
        {
            Value = Value.Trim('&');
            ValueList = new List<string>();
            List<string> list = Value.Split('&').ToList();
            for (int i = 0; i < list.Count; i++)
            {
                int a = list[i].IndexOf('=') + 1;
                int length = list[i].Length - a;
                ValueList.Add(list[i].Substring(a, length));
                if (list[i].Contains("stbid"))
                {
                    SN = list[i].Substring(a, length);
                }

            }
        }

        private void CheckNum()
        {
            try
            {
                if (ValueList.Contains(Value1))
                {
                    if (IsCheck(true))
                    {
                        ShowTips(Value1 + "    " + "PASS", Color.LightGreen);
                    }
                    else
                    {
                        ShowTips(SN + "    " + "上传失败    NG", Color.Red);
                    }
                    Input1.Clear();
                    Input2.Clear();
                    Input1.Focus();
                    
                }
                else if (ValueList.Contains(Value2))
                {
                    if (IsCheck(true))
                    {
                        ShowTips(Value2 + "    " + "PASS", Color.LightGreen);
                    }
                    else
                    {
                        ShowTips(SN + "    " + "上传失败    NG", Color.Red);
                    }
                    Input1.Clear();
                    Input2.Clear();
                    Input1.Focus();
                    
                }
                else
                {
                    ShowTips(SN + "    " + "NG", Color.Red);
                    Input1.Clear();
                    Input2.Clear();
                    Input1.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowTips(ex.Message, Color.Red);
                Input1.Clear();
                Input2.Clear();
                Input1.Focus();
            }

        }

        private bool IsCheck(bool res)
        {
            bool result = false;
            if (res)
            {
                string Url = "http://192.168.8.8/box_cms_v3/mes_v1/bindDutFields.php?model=B182K02GDYD&dut_number_name=sn&dut_number_value="+SN;
                string Json = "{ \"fields\": { \"IsCheck\": \"OK\" } }";
                string Result = Post(Url, Json);
                if(Result == "{\"resultCode\":\"0\",\"resultMsg\":\"success\"}")
                {
                    Log.WriteLogs(SN);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="Info">输出提示信息</param>
        public void ShowTips(string Info, Color color)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                this.ResultTips.Invoke(new Action(() =>
                {
                    ResultTips.Text = Info;
                    ResultTips.BackColor = color;
                }));
            });

        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="Url">访问链接</param>
        /// <param name="jsonStr">所需上传的json格式数据</param>
        /// <returns></returns>
        public string Post(string Url, string jsonStr)
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

    public class LogHelper
    {
        public void WriteLogs(string logInfo)
        {
            string FloderPath = AppDomain.CurrentDomain.BaseDirectory;
            string FilePath = FloderPath.Replace("/", "\\") + "Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            FilePath += DateTime.Now.ToString("yyyyMMddHH") + "log.txt";
            StreamWriter writer = new StreamWriter(FilePath, true, System.Text.Encoding.UTF8);
            writer.WriteLine(DateTime.Now + " " + logInfo);
            writer.Close();
        }
    }

}
