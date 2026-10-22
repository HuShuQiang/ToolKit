using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class CheckFieldsStationView : UserControl
    {
        public event Back back;
        private List<string> fieldslist = new List<string>();
        private Hashtable serverdatatable = new Hashtable();
        private Hashtable localdatatable = new Hashtable();
        private Hashtable fieldregextable = new Hashtable();
        private bool isgetserverdata = false;
        private int num = 0;
        private int enternum = 0;
        public CheckFieldsStationView()
        {
            InitializeComponent();
            configload();
            Load += CheckFieldsStationView_Load;
        }

        private void CheckFieldsStationView_Load(object sender, EventArgs e)
        {
            fieldslist = Properties.Settings.Default.CheckFields_FieldsList.Split(';').ToList();
            IsUpload.Text = Properties.Settings.Default.CheckFields_IsUploadStation ? "是" : "否";
            FieldRegex.Text = Properties.Settings.Default.FieldRegex;
            fieldregextable = new Hashtable();
            List<string> fieldregexlist = new List<string>();
            fieldregexlist = FieldRegex.Text.Split(';').ToList();
            foreach (string regexstr in fieldregexlist)
            {
                List<string> list = new List<string>();
                list = regexstr.Split('=').ToList();
                fieldregextable[list[0]] = list[1];
            }

            if (fieldslist.Contains(""))
            {
                int num = fieldslist.Where(x => x == "").Count();
                for (int i = 0; i < num; i++)
                {
                    fieldslist.Remove("");
                }
            }
            num = 0;
            FieldName.Text = fieldslist[0];
            FieldsValue.Focus();
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            CheckFieldsStationSettings settings = new CheckFieldsStationSettings();
            settings.ShowDialog();
            configload();
        }

        private void configload()
        {
            Model.Text = Properties.Settings.Default.CheckFields_Model;
            Fixid.Text = Properties.Settings.Default.CheckFields_Fixid;
            Station.Text = Properties.Settings.Default.CheckFields_Station;
            FieldsList.Text = Properties.Settings.Default.CheckFields_FieldsList;
            CheckFieldsStationView_Load(null, null);
        }

        private void FieldsValue_KeyDown(object sender, KeyEventArgs e)
        {
            ClearShow();
            if (Model.Text == "CD1")
            {
                if (FieldName.Text == "sn")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (enternum == 0)
                        {
                            enternum = 1;
                        }
                        else if (enternum == 1)
                        {
                            if (e.KeyCode == Keys.Enter)
                            {
                                if (!string.IsNullOrWhiteSpace(FieldsValue.Text))
                                {
                                    Regex regex = new Regex(fieldregextable[FieldName.Text].ToString());
                                    Match match = regex.Match(FieldsValue.Text);
                                    if (match.Success)
                                    {
                                        FieldsValue.Text = match.Value.ToString();
                                    }
                                    else
                                    {
                                        ShowResult(false);
                                        ShowTips($"输入的{FieldName.Text}与截取规则不匹配！检查规则内容！");
                                        return;
                                    }

                                    //判断是否获取服务器数据
                                    if (!isgetserverdata)
                                    {
                                        GetServerData();
                                    }
                                    else
                                    {
                                        if (num != fieldslist.Count - 1)
                                        {
                                            if (CheckData(FieldName.Text, FieldsValue.Text))
                                            {
                                                num++;
                                                if (num == fieldslist.Count - 1)
                                                {
                                                    ShowResult(true);
                                                    ShowTips(fieldslist[0] + ":" + serverdatatable[fieldslist[0]] + "所有字段数据匹配！");
                                                    if (Properties.Settings.Default.CheckFields_IsUploadStation)
                                                    {
                                                        UploadStation(fieldslist[0], serverdatatable[fieldslist[0]].ToString());
                                                    }

                                                }
                                                else
                                                {
                                                    FieldName.Text = fieldslist[num + 1];
                                                    FieldsValue.Text = "";
                                                }
                                            }
                                            else
                                            {
                                                ShowTips(fieldslist[0] + ":" + serverdatatable[fieldslist[0]] + "服务器数据" + FieldName.Text + ":" + serverdatatable[FieldName.Text] + "与输入字段" + FieldName.Text + ":" + FieldsValue.Text + "数据不匹配！");
                                                ShowResult(false);
                                            }
                                        }
                                        else
                                        {
                                            ShowResult(false);

                                        }

                                    }
                                }
                            }
                            enternum = 0;
                        }
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (!string.IsNullOrWhiteSpace(FieldsValue.Text))
                        {
                            Regex regex = new Regex(fieldregextable[FieldName.Text].ToString());
                            Match match = regex.Match(FieldsValue.Text);
                            if (match.Success)
                            {
                                FieldsValue.Text = match.Value.ToString();
                            }
                            else
                            {
                                ShowResult(false);
                                ShowTips($"输入的{FieldName.Text}与截取规则不匹配！检查规则内容！");
                                return;
                            }

                            //判断是否获取服务器数据
                            if (!isgetserverdata)
                            {
                                GetServerData();
                            }
                            else
                            {
                                if (num != fieldslist.Count - 1)
                                {
                                    if (CheckData(FieldName.Text, FieldsValue.Text))
                                    {
                                        num++;
                                        if (num == fieldslist.Count - 1)
                                        {
                                            ShowResult(true);
                                            ShowTips(fieldslist[0] + ":" + serverdatatable[fieldslist[0]] + "所有字段数据匹配！");
                                            if (Properties.Settings.Default.CheckFields_IsUploadStation)
                                            {
                                                UploadStation(fieldslist[0], serverdatatable[fieldslist[0]].ToString());
                                            }

                                        }
                                        else
                                        {
                                            FieldName.Text = fieldslist[num + 1];
                                            FieldsValue.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        ShowTips(fieldslist[0] + ":" + serverdatatable[fieldslist[0]] + "服务器数据" + FieldName.Text + ":" + serverdatatable[FieldName.Text] + "与输入字段" + FieldName.Text + ":" + FieldsValue.Text + "数据不匹配！");
                                        ShowResult(false);
                                    }
                                }
                                else
                                {
                                    ShowResult(false);

                                }

                            }
                        }
                    }
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(FieldsValue.Text))
                    {
                        Regex regex = new Regex(fieldregextable[FieldName.Text].ToString());
                        Match match = regex.Match(FieldsValue.Text);
                        if (match.Success)
                        {
                            FieldsValue.Text = match.Value.ToString();
                        }
                        else
                        {
                            ShowResult(false);
                            ShowTips($"输入的{FieldName.Text}与截取规则不匹配！检查规则内容！");
                            return;
                        }

                        //判断是否获取服务器数据
                        if (!isgetserverdata)
                        {
                            GetServerData();
                        }
                        else
                        {
                            if (num != fieldslist.Count - 1)
                            {
                                if (CheckData(FieldName.Text, FieldsValue.Text))
                                {
                                    num++;
                                    if (num == fieldslist.Count - 1)
                                    {
                                        ShowResult(true);
                                        ShowTips(fieldslist[0] + ":" + serverdatatable[fieldslist[0]] + "所有字段数据匹配！");
                                        if (Properties.Settings.Default.CheckFields_IsUploadStation)
                                        {
                                            UploadStation(fieldslist[0], serverdatatable[fieldslist[0]].ToString());
                                        }

                                    }
                                    else
                                    {
                                        FieldName.Text = fieldslist[num + 1];
                                        FieldsValue.Text = "";
                                    }
                                }
                                else
                                {
                                    ShowTips(fieldslist[0] + ":" + serverdatatable[fieldslist[0]] + "服务器数据" + FieldName.Text + ":" + serverdatatable[FieldName.Text] + "与输入字段" + FieldName.Text + ":" + FieldsValue.Text + "数据不匹配！");
                                    ShowResult(false);
                                }
                            }
                            else
                            {
                                ShowResult(false);

                            }

                        }
                    }
                }

            }
        }

        private void ClearShow()
        {
            Result.Text = "";
            Tips.Text = "";
        }

        private void ShowResult(bool state)
        {
            if (state)
            {
                Result.Text = "PASS";
                Result.BackColor = Color.Green;
            }
            else
            {
                Result.Text = "NG";
                Result.BackColor = Color.Red;
            }
            WriteLogs(Result.Text);
            FieldsValue.Text = "";
            num = 0;
            isgetserverdata = false;
            CheckFieldsStationView_Load(null, null);


        }

        private void ShowTips(string tips)
        {
            Tips.Text = tips;
            WriteLogs(tips);
        }

        private void WriteLogs(string log)
        {
            string FloderPath = AppDomain.CurrentDomain.BaseDirectory;
            string FilePath = FloderPath.Replace("/", "\\") + "Logs\\";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            FilePath += DateTime.Now.ToString("yyyyMMdd") + "_log.txt";
            StreamWriter writer = new StreamWriter(FilePath, true, System.Text.Encoding.UTF8);
            writer.WriteLine(DateTime.Now + " " + log);
            writer.Close();

        }


        private bool CheckData(string fields, string fieldsvalue)
        {
            bool res = false;
            if (serverdatatable[fields].ToString() == fieldsvalue)
            {
                res = true;
            }
            return res;
        }

        private void GetServerData()
        {
            try
            {
                string url = $"http://192.168.8.8/box_cms_v3/mes_v1/getDutFields.php?model={Model.Text}&dut_number_name={fieldslist[0]}&dut_number_value={FieldsValue.Text}";
                string json = Post(url, "");
                JObject data = JsonConvert.DeserializeObject<JObject>(json);
                if (data["resultCode"].ToString() == "0")
                {
                    serverdatatable = JsonConvert.DeserializeObject<Hashtable>(data["fields"].ToString());
                    isgetserverdata = true;
                    FieldsValue.Text = "";
                    FieldName.Text = fieldslist[num + 1];
                }
                else
                {

                    ShowTips(FieldName.Text + ":" + FieldsValue.Text + " 获取服务器字段失败：" + data["resultMsg"].ToString());
                    ShowResult(false);
                }
            }
            catch (Exception ex)
            {
                ShowTips(FieldName.Text + ":" + FieldsValue.Text + " 获取服务器字段异常：" + ex.Message);
                ShowResult(false);
            }

        }

        private void UploadStation(string field, string value)
        {
            string url = $"http://192.168.8.8/box_cms_v3/mes_v1/postTestDataStr.php?model={Model.Text}&dut_number_name={field}&dut_number_value={value}&station={Station.Text}&fix_id={Fixid.Text}&line_name=&elapsed=1&is_pass=true&retry_cnt=1&is_misdetect=false";
            WriteLogs(url);
            string json = Post(url, "");
            JObject data = JsonConvert.DeserializeObject<JObject>(json);
            if (data["resultCode"].ToString() != "0")
            {
                ShowTips("上传工站信息失败：" + data["resultMsg"].ToString());
                ShowResult(false);
            }
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
}
