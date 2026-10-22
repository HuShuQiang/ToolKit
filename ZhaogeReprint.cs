using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class ZhaogeReprint : UserControl
    {
        public event Back back;
        private InputWindow input;
        private string fields;
        private List<string> fieldslist;
        private List<string> regexlist;
        private Hashtable FiedsTable;
        private Hashtable FieldsRegex;
        private string value;
        public ZhaogeReprint()
        {
            InitializeComponent();
            Properties.Settings.Default.IsLoop = false;
            Properties.Settings.Default.Save();
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

        private string GetOpenPath()
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

        private void Run_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Printer = Printer.Text;
            Properties.Settings.Default.PrintFilePath = FilePath.Text;
            Properties.Settings.Default.PrintFields = PrintFields.Text;
            Properties.Settings.Default.InputRegex = NumRegex.Text;
            Properties.Settings.Default.Save();

            fieldslist = new List<string>();
            List<string>list = PrintFields.Text.Split(';').ToList();
            foreach (string field in list)
            {
                if (field.Count(i => "_".Contains(i)) > 1)
                {
                    fieldslist.Add(field.Substring(0, field.LastIndexOf('_')));
                }
                else
                {
                    fieldslist.Add(field);
                }
            }
            regexlist = new List<string>();
            regexlist = NumRegex.Text.Split(';').ToList();

            Properties.Settings.Default.IsLoop = true;
            Properties.Settings.Default.Save();
            Task.Run(() =>
            {
                RunThrad();
            });

        }

        private void RunThrad()
        {
            while (Properties.Settings.Default.IsLoop)
            {

                ChangeStatu(false);

                input = new InputWindow();
                input.Fields1.Text = fieldslist[0];
                input.Fields2.Text = fieldslist[1];
                input.Fields3.Text = fieldslist[2];
                input.regex1 = new Regex(regexlist[0].ToString());
                input.regex2 = new Regex(regexlist[1].ToString());
                input.regex3 = new Regex(regexlist[2].ToString());
                input.RegexStr1.Text = "正则表达式：" + regexlist[0].ToString();
                input.RegexStr2.Text = "正则表达式：" + regexlist[1].ToString();
                input.RegexStr3.Text = "正则表达式：" + regexlist[2].ToString();




                this.Invoke(new Action(() =>
                {
                    DialogResult result = input.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {

                    }
                }));
                


                if (!Properties.Settings.Default.IsLoop)
                {
                    break;
                }
            }

            ChangeStatu(true);
        }



        private void ChangeStatu(bool Statu)
        {
            this.Invoke(new Action(() =>
            {
                if (!Statu)
                {
                    Run.Text = "运行中";
                    Run.BackColor = Color.YellowGreen;
                }
                else
                {
                    Run.Text = "开始运行";
                    Run.BackColor = Color.Lime;
                }
                Run.Enabled = Statu;
                SelectFile.Enabled = Statu;
                Printer.Enabled = Statu;
                PrintFields.Enabled = Statu;
                NumRegex.Enabled = Statu;
                ComeBack.Enabled = Statu;
            }));




        }


    }
}
