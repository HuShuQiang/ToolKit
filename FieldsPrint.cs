using Seagull.BarTender.Print;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class FieldsPrint : UserControl
    {
        public event Back back;
        private string sn;
        private string mac;
        private const string PrintJopName = "PrintTag";
        public static Engine engine = null;
        private LabelFormatDocument btFormat = null;
        private bool isRun = false;
        public FieldsPrint()
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
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void Printer_Click(object sender, EventArgs e)
        {
            Printer.Items.Clear();
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                Printer.Items.Add(printerName);
            }
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            FilePath.Text = GetOpenPath();

            Properties.Settings.Default.PrintFilePath = FilePath.Text;
            Properties.Settings.Default.Save();
        }

        private string GetOpenPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // openFileDialog.InitialDirectory = @"D:\";
            openFileDialog.Filter = "模板文件|*.btw";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void Printer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Printer.Text))
            {
                Properties.Settings.Default.Printer = Printer.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void SN_KeyDown(object sender, KeyEventArgs e)
        {
            ResultTips.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(SN.Text))
                {
                    sn = SN.Text;
                    MAC.Focus();
                }
            }
        }

        private void MAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(MAC.Text))
                {
                    mac = MAC.Text;
                    Print();
                    MAC.Clear();
                    SN.Clear();
                    SN.Focus();
                }
            }
        }

        private void Print()
        {

            if (Printer.Text != "")
            {
                if (File.Exists(FilePath.Text))
                {
                    if (!isRun)
                    {
                        engine = new Engine(true);
                        isRun = true;
                    }
                    //BarTender.Application BtApp = new BarTender.Application();
                    //BarTender.Format btFormat = BtApp.Formats.Open(Properties.Settings.Default.PrintFilePath);
                    //btFormat.PrintSetup.Printer = PrinterName;
                    //foreach (string key in Data.Keys)
                    //{
                    //    btFormat.SetNamedSubStringValue(key, Data[key].ToString());
                    //}
                    //btFormat.PrintOut();

                    //btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
                    //BtApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);

                    btFormat = engine.Documents.Open(FilePath.Text);

                    btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
                    btFormat.PrintSetup.NumberOfSerializedLabels = 1;

                    //LabelFormatDocument btFormat = btEngine.Documents.Open(FilePath.Text);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                    btFormat.PrintSetup.PrinterName = Printer.Text;

                    // btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数


                    //btFormat.SetNamedSubStringValue(key, Data[key].ToString());
                    btFormat.SubStrings["SN"].Value = sn;
                    btFormat.SubStrings["MAC"].Value = mac;




                    Messages messages;

                    //int waitout = 500; // 5秒 超时

                    //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                    Result nResult = btFormat.Print("打印工具", out messages);
                    if (nResult == Result.Success)
                    {
                        ResultTips.Text = "SN:"+sn +"  MAC:"+ mac +" 打印成功！";
                        ResultTips.ForeColor = Color.LightGreen;
                    }

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
    }
}
