using Seagull.BarTender.Print;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class PrintMain_board : UserControl
    {
        public event Back back;
        private Engine btEngine;
        public PrintMain_board()
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

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            ResultTips.Text = "";
            string input = Input.Text;


            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    Regex regex = new Regex("^" + NumRegex.Text + "$");
                    if (regex.IsMatch(Input.Text))
                    {
                        Print();
                        ResultTips.Text = Input.Text + " 打印成功！";
                    }
                    else
                    {
                        ResultTips.Text = Input.Text + " 输入值格式错误！";
                    }
                }
                Input.Text = "";
            }




        }




        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Printer = Printer.Text;
            Properties.Settings.Default.PrintFilePath = FilePath.Text;
            Properties.Settings.Default.PrintFields = PrintFields.Text;
            Properties.Settings.Default.InputRegex = NumRegex.Text;
            Properties.Settings.Default.Save();
        }

        private void Print()
        {
            string PrinterName = Printer.Text;


            if (!string.IsNullOrEmpty(Input.Text))
            {

                if (PrinterName != "")
                {
                    if (File.Exists(FilePath.Text))
                    {

                        if (btEngine == null)
                        {
                            btEngine = new Engine();
                        }

                        btEngine.Start();
                        LabelFormatDocument btFormat = btEngine.Documents.Open(FilePath.Text);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                        btFormat.PrintSetup.PrinterName = PrinterName;

                        btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数


                        btFormat.SubStrings[PrintFields.Text].Value = Input.Text;


                        Messages messages;

                        //int waitout = 500; // 5秒 超时

                        //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                        Result nResult = btFormat.Print("打印工具", out messages);

                        btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;

                        btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改

                        //btEngine.Stop();
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
            // });




        }


    }

}
