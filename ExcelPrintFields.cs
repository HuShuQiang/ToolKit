using MiniExcelLibs;
using NPOI.SS.UserModel;
using Seagull.BarTender.Print;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class ExcelPrintFields : UserControl
    {
        public event Back back;
        private const string PrintJopName = "PrintTag";
        public static Engine engine = null;
        private LabelFormatDocument btFormat = null;
        private string input = null;
        private string printer = null;
        private string filepath = null;
        private bool isRun = false;
        public ExcelPrintFields()
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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ScanFields))
            {
                ScanFields.Text = Properties.Settings.Default.ScanFields;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SourceExcelPath))
            {
                ExcelPath.Text = Properties.Settings.Default.SourceExcelPath;
            }

            
            //if (btFormat != null)
                //btFormat.Close(SaveOptions.DoNotSaveChanges);

            Input.Focus();
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            //engine.Stop();
            //engine.Dispose();
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

        public static string GetExcelPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // openFileDialog.InitialDirectory = @"D:\";
            openFileDialog.Filter = "Excel文件|*.xlsx";
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
            input = Input.Text;
            printer = Printer.Text;
            filepath = FilePath.Text;



            if (e.KeyCode == Keys.Enter)
            {
                if (!isRun)
                {
                    engine = new Engine(true);
                    isRun = true;
                }
                string input = Input.Text;
                if (!string.IsNullOrEmpty(input))
                {
                    var FirstRows = MiniExcel.Query(ExcelPath.Text).First();
                    var row = MiniExcel.Query(ExcelPath.Text).ToList();
                    DataTable datatable = MiniExcel.QueryAsDataTable(ExcelPath.Text, useHeaderRow: true);
                    
                    DataRow[] data = datatable.Select(ScanFields.Text+"='"+input+"'");
                    if (data.Length > 0)
                    {
                        string value = data[0][PrintFields.Text].ToString();
                        Task.Run(() =>
                        {
                            Print(value,printer,filepath);
                        });
                        
                    }
                    else
                    {
                        ResultTips.Text = input + "不存在Excel文件中";
                        ResultTips.BackColor = Color.Red;
                    }
                  
       
                }
                Input.Clear();
                Input.Focus();
            }




        }




        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Printer = Printer.Text;
            Properties.Settings.Default.PrintFilePath = FilePath.Text;
            Properties.Settings.Default.PrintFields = PrintFields.Text;
            Properties.Settings.Default.ScanFields = ScanFields.Text;
            Properties.Settings.Default.SourceExcelPath = ExcelPath.Text;
            Properties.Settings.Default.Save();
        }

        private void Print(string inputStr,string printer,string filepath)
        {

            if (!string.IsNullOrEmpty(inputStr))
            {

                if (printer != "")
                {
                    if (File.Exists(filepath))
                    {
                        btFormat = engine.Documents.Open(filepath);

                        btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
                        btFormat.PrintSetup.NumberOfSerializedLabels = 1;

                        //LabelFormatDocument btFormat = btEngine.Documents.Open(FilePath.Text);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                        btFormat.PrintSetup.PrinterName = printer;

                       // btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数


                        btFormat.SubStrings[PrintFields.Text].Value = inputStr;


                        Messages messages;

                        //int waitout = 500; // 5秒 超时

                        //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                        Result nResult = btFormat.Print("打印工具", out messages);
                        if(nResult == Result.Success)
                        {
                            ResultTips.Text = input + "的" + PrintFields.Text + "为"+ inputStr + "，打印成功！";
                            ResultTips.BackColor = Color.Green;
                        }

                        //btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;

                        //btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改

                        //btEngine.Stop();
                        //btEngine.Dispose();
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
                ResultTips.Text = input+"的"+ PrintFields.Text+"为空，打印失败！";
                ResultTips.BackColor = Color.Red;
            }
            // });




        }

        private void SelectExcel_Click(object sender, EventArgs e)
        {
            ExcelPath.Text = GetExcelPath();
        }

    }

}
