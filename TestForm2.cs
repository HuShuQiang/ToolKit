using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class TestForm2 : UserControl
    {
        private Settings settings;
        public event Back back;
        public string ModelName;
        public string IP;
        private string Model;
        private string Regex69Code;
        private string RegexMAC;
        private string URL;
        private string _69Code;
        private string LANMAC;
        public TestForm2()
        {
            InitializeComponent();
            settings = new Settings();
            IP = settings.Read("settings", "IP");
            Model = settings.Read("settings", "69CodeModel");

        }

        public void GetModel(string model)
        {
            ModelName = model;
            TestName.Text = ModelName;
            if (ModelName == "Tablo(69Code)")
            {
                BackColor = Color.DarkOrange;
                Regex69Code = settings.Read("settings", "69Code1");
                LAN_MAC.Visible = false;
                Input_LANMAC.Visible = false;

            }
            else if (ModelName == "Tablo(LAN_MAC)")
            {
                BackColor = Color.Orange;
                Regex69Code = settings.Read("settings", "69Code2");
                RegexMAC = settings.Read("settings", "MAC");
            }

        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void Input69Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _69Code = Input69code.Text;
                if (ModelName == "Tablo(69Code)")
                {
                    Regex regex = new Regex(Regex69Code);
                    if (regex.IsMatch(_69Code))
                    {
                        Input69code.Text = "";
                        ResultTips.Text = _69Code + " PASS";
                        ResultTips.ForeColor = Color.Green;
                    }
                    else
                    {
                        Input69code.Text = "";
                        ResultTips.Text = _69Code + " 69码格式错误！";
                        ResultTips.ForeColor = Color.Red;
                    }
                }
                else if (ModelName == "Tablo(LAN_MAC)")
                {
                    Regex regex = new Regex(Regex69Code);
                    if (regex.IsMatch(_69Code))
                    {
                        ResultTips.Text = "";
                        Input_LANMAC.Focus();
                    }
                    else
                    {
                        Input69code.Text = "";
                        ResultTips.Text = _69Code + " 69码格式错误！";
                        ResultTips.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void Input_LANMAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(Input69code.Text))
                {
                    LANMAC = Input_LANMAC.Text;
                    Regex regex = new Regex(RegexMAC);
                    if (regex.IsMatch(LANMAC))
                    {
                        URL = "http://" + IP + "/box_cms_v3/upload_weight.php?model=" + Model + "&up_lan_mac=" + LANMAC + "&weight=100";
                        Input69code.Text = "";
                        Input_LANMAC.Text = "";
                        if (UploadURL(URL))
                        {
                            Input69code.Focus();
                            ResultTips.Text = LANMAC + " PASS 上传成功！";
                            ResultTips.ForeColor = Color.Green;
                        }
                        else
                        {
                            ResultTips.Text = LANMAC + " PASS 上传失败！";
                            ResultTips.ForeColor = Color.Red;
                        }

                    }
                    else
                    {
                        Input_LANMAC.Text = "";
                        ResultTips.Text = LANMAC + " LAN_MAC格式错误！";
                        ResultTips.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Input_LANMAC.Text = "";
                    ResultTips.Text = "69码不能为空";
                    ResultTips.ForeColor = Color.Red;
                    Input69code.Focus();
                }

            }
        }

        private bool UploadURL(string URL)
        {
            string Info = "";
            try
            {
                var request = WebRequest.Create(URL);
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        StreamReader RepstreamReader = new StreamReader(responseStream, Encoding.UTF8);
                        Info = RepstreamReader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("网络错误，请检查网络" + ex.Message);
            }

            if (Info == "succeed")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
