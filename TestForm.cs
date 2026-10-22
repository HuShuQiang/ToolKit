using Newtonsoft.Json;
using Seagull.BarTender.Print;
using Seagull.BarTender.PrintServer.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using SaveOptions = Seagull.BarTender.Print.SaveOptions;
using Task = System.Threading.Tasks.Task;

namespace 工具集合
{
    public delegate void Back();

    public partial class TestForm : UserControl
    {
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name);

        public event Back back;
        public string ModelName;
        private System.Timers.Timer timer = new System.Timers.Timer(500);
        private bool isConnect = false;
        private string IP;
        private string Model;
        private string Fields;
        private string Sn;
        private string FilePath;
        Dictionary<string, string> DeviceState = new Dictionary<string, string>();
        private Settings settings;
        public TestForm()
        {
            InitializeComponent();
            settings = new Settings();
            IP = settings.Read("Settings", "IP");
            Fields = settings.Read("Settings", "Fields");

            DeviceState.Add("0", "已导入");
            DeviceState.Add("1", "已测试");
            DeviceState.Add("2", "已包装");
            DeviceState.Add("3", "已称重");
            DeviceState.Add("4", "已装箱");
            DeviceState.Add("100", "已发货");
            DeviceState.Add("101", " ");

            timer.Elapsed += new System.Timers.ElapsedEventHandler(CheckADB);
            timer.AutoReset = true;
            timer.Enabled = true;

            ConnectStatus.Text = "等待连接中。。。";
        }

        public void GetModel(string model)
        {
            ModelName = model;
            //Fields = "sn";
            //IP = "192.168.120.23";
            TestName.Text = ModelName;
            if (ModelName == "MRC01")
            {
                BackColor = Color.MediumTurquoise;
                //Model = "MRC01";
                Model = settings.Read("Settings", "MRC01");
                FilePath = System.AppDomain.CurrentDomain.BaseDirectory + settings.Read("Settings", "MRC01Temp");
            }
            else if (ModelName == "MRC02")
            {
                BackColor = Color.DeepSkyBlue;
                //Model = "MRC02_A113";
                Model = settings.Read("Settings", "MRC02");
                FilePath = System.AppDomain.CurrentDomain.BaseDirectory +settings.Read("Settings", "MRC02Temp");

            }

        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void TestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                back();
            }
        }

        private void CheckADB(object source, ElapsedEventArgs e)
        {

            if (ModelName == "MRC01")
            {
                string Str = RunADB("shell /userdata/factorytest/factory 9 0");
                Str = Str.Replace("\r\r\n", "").Trim();

                if (Str != "")
                {
                    if (Str.Length == 16)
                    {
                        isConnect = true;
                       // timer.Enabled = false;
                        Action action = () =>
                        {
                            ConnectStatus.Text = "连接成功！";
                            SN.Text = Str;
                            Sn = Str;
                        };
                        Invoke(action);

                    }
                    else
                    {
                        Action action = () =>
                        {
                            ConnectStatus.Text = "SN长度异常，可能烧错号码或者机型选择错误！";
                            //SN.Text = Str;
                        };
                        Invoke(action);
                    }
                }
                else
                {
                    ConnectStatus.Text = "等待连接中。。。";
                    SN.Text = "";
                }
            }
            else if (ModelName == "MRC02")
            {
                string Str = RunADB("shell /data/factorytest/factory 9 0");
                Str = Str.Replace("\r\r\n", "").Trim();
                if (Str != "")
                {
                    if (Str.Length == 16)
                    {
                        isConnect = true;
                        //timer.Enabled = false;
                        Action action = () =>
                        {
                            ConnectStatus.Text = "连接成功！";
                            SN.Text = Str;
                            Sn = Str;

                        };
                        Invoke(action);

                    }
                    else
                    {
                        Action action = () =>
                        {
                            ConnectStatus.Text = "SN长度异常，可能烧错号码或者机型选择错误！";
                            //SN.Text = Str;
                        };
                        Invoke(action);
                    }
                }
                else
                {
                    ConnectStatus.Text = "等待连接中。。。";
                    SN.Text = "";
                }
            }

        }

        public string RunADB(string arg)
        {
            Process p = new Process(); //实例一个Process类，启动一个独立进程
            string Info = "";

            p.StartInfo.FileName = "adb.exe"; //设定程序名
            p.StartInfo.Arguments = arg;
            p.StartInfo.UseShellExecute = false; //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true; //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true; //重定向标准输出
            p.StartInfo.RedirectStandardError = true; //重定向错误输出
            p.StartInfo.CreateNoWindow = true; // 设置不显示窗口
            p.StartInfo.ErrorDialog = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.Start();
            Info = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();


            return Info;
        }

        private void SearchInfo(string SN)
        {
            string URL = "http://" + IP + "/box_cms_v3/mes_v1/getDutFields.php?model=" + Model + "&dut_number_name=" + Fields + "&dut_number_value=" + SN;
            string JsonStr = GetInfo(URL);
            if(JsonStr != "{\"resultCode\":\"9999\",\"resultMsg\":\"查询到的数据为空！\"}")
            {
                Hashtable hashtable = new Hashtable(JsonConvert.DeserializeObject<Hashtable>(JsonStr));
                string fields = hashtable["fields"].ToString();
                Hashtable hashtable2 = new Hashtable(JsonConvert.DeserializeObject<Hashtable>(fields));
                string mac = "";
                if (hashtable2["mac"] == null)
                {
                    mac = "XXXXXXXXXX";
                }
                else
                {
                    mac = hashtable2["mac"].ToString();

                }
                string status = hashtable["status"].ToString();
            }
            else
            {
                MessageBox.Show("当前设备后台数据信息为空，请检查连接设备的型号是否匹配！");

            }

        }

        private string GetInfo(string url)
        {

            string Info = "";
            try
            {
                var request = WebRequest.Create(url);
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
            return Info;

        }

        private void Print_Click(object sender, EventArgs e)
        {
            PrintDocument print = new PrintDocument();
            string PrinterName = print.PrinterSettings.PrinterName;

            Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(Sn))
                {
                    
                        if (PrinterName != "")
                        {
                            if (File.Exists(FilePath))
                            {
                                Engine btEngine = new Engine();

                                bool isAlive = btEngine.IsAlive;

                                btEngine.Start();

                                LabelFormatDocument btFormat = btEngine.Documents.Open(FilePath);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                                btFormat.PrintSetup.PrinterName = PrinterName;

                                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数

                                if (Sn != "")
                                {
                                    btFormat.SubStrings["sn"].Value = Sn;
                                }
                                else
                                {
                                    btFormat.SubStrings["sn"].Value = "000000";
                                }

                                Messages messages;

                                //int waitout = 500; // 5秒 超时

                                //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                                Result nResult = btFormat.Print("工具集合", out messages);

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
                    MessageBox.Show("SN为空不能打印，请等待设备连接成功后在尝试打印！");
                }
            });
            
            

            
        }
    }
}
