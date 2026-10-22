using Seagull.BarTender.Print;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class InputWindow : Form
    {
        private List<string> Fieldslist;
        private List<string> Regexlist;
        public Hashtable FiedsTable;
        public Regex regex1;
        public Regex regex2;
        public Regex regex3;
        public Hashtable Data;
        //private BarTender.Application BtApp;
        //private BarTender.Format btFormat;
        private const string PrintJopName = "PrintTag";
        public static Engine engine = null;
        private LabelFormatDocument btFormat = null;
        private bool isRun = false;

        public InputWindow()
        {
            InitializeComponent();
            //BtApp = new BarTender.Application();
            //btFormat = BtApp.Formats.Open(Properties.Settings.Default.PrintFilePath);
            Data = new Hashtable();
        }

        private void Input1_KeyDown(object sender, KeyEventArgs e)
        {
            Tips.Text = "";
            Tips.BackColor = System.Drawing.SystemColors.Control;
            if (e.KeyCode == Keys.Enter)
            {
                if (regex1.IsMatch(Input1.Text))
                {
                    Data.Add(Fields1.Text, Input1.Text);
                    Input2.Focus();
                }
                else
                {
                    Tips.Text = Input1.Text + "与正则表达式不匹配！";
                    Tips.BackColor = Color.Red;
                    Input1.Clear();
                    Input1.Focus();
                }
            }
        }

        private void Input2_KeyDown(object sender, KeyEventArgs e)
        {
            Tips.Text = "";
            Tips.BackColor = System.Drawing.SystemColors.Control;
            if (e.KeyCode == Keys.Enter)
            {
                if (regex2.IsMatch(Input2.Text))
                {
                    Input3.Focus();
                }
                else
                {
                    Tips.Text = Input2.Text + "与正则表达式不匹配！";
                    Tips.BackColor = Color.Red;
                    Input2.Clear();
                    Input2.Focus();
                }
            }
        }

        private void Input3_KeyDown(object sender, KeyEventArgs e)
        {
            Tips.Text = "";
            Tips.BackColor = System.Drawing.SystemColors.Control;

            if (e.KeyCode == Keys.Enter)
            {
                if (!isRun)
                {
                    engine = new Engine(true);
                    isRun = true;
                }
                if (regex3.IsMatch(Input3.Text))
                {
                    if (DataWorker())
                    {
                        Print();
                        Tips.Text = Input1.Text + "打印成功！";
                        Tips.BackColor = Color.Lime;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("字段数量不足40，是否继续打印！","",MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Print();
                            Tips.Text = Input1.Text + "打印成功！";
                            Tips.BackColor = Color.Lime;
                        }
                        else
                        {
                            Tips.Text = Input1.Text + "打印失败！字段数量不足40！";
                            Tips.BackColor = Color.Red;
                        }
                    }
                    

                   
                    Data = new Hashtable();
                    Input1.Clear();
                    Input2.Clear();
                    Input3.Clear(); 
                    Input1.Focus();

                }
                else
                {
                    Tips.Text = Input3.Text + "与正则表达式不匹配！";
                    Tips.BackColor = Color.Red;
                    Input3.Clear();
                    Input3.Focus();
                }
            }
        }

        private bool DataWorker()
        {
            bool res = false;
            List<string> List2 = Input2.Text.Split(',').ToList();
            List<string> List3 = Input3.Text.Split(',').ToList();
            if (List2.Count == 40 & List3.Count == 40)
            {
                res = true;
            }

            for (int x = 0; x < 40; x++)
            {
                if (x > List2.Count-1)
                {
                    Data.Add(Fields2.Text + "_" + (x + 1), "");
                }
                else
                {
                    Data.Add(Fields2.Text + "_" + (x + 1), List2[x]);
                }
                
            }
            for (int x = 0; x < 40; x++)
            {
                if (x > List3.Count - 1)
                {
                    Data.Add(Fields3.Text + "_" + (x + 1), "");
                }
                else
                {
                    Data.Add(Fields3.Text + "_" + (x + 1), List3[x]);
                }
            }

            return res;
        }

        private void Print()
        {
            string PrinterName = Properties.Settings.Default.Printer;

            if (Data.Count > 0)
            {

                if (PrinterName != "")
                {
                    if (File.Exists(Properties.Settings.Default.PrintFilePath))
                    {

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

                        btFormat = engine.Documents.Open(Properties.Settings.Default.PrintFilePath);

                        btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
                        btFormat.PrintSetup.NumberOfSerializedLabels = 1;

                        //LabelFormatDocument btFormat = btEngine.Documents.Open(FilePath.Text);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                        btFormat.PrintSetup.PrinterName = PrinterName;

                        // btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数

                        foreach (string key in Data.Keys)
                        {
                            //btFormat.SetNamedSubStringValue(key, Data[key].ToString());
                            btFormat.SubStrings[key].Value = Data[key].ToString();
                        }
                        


                        Messages messages;

                        //int waitout = 500; // 5秒 超时

                        //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                        Result nResult = btFormat.Print("打印工具", out messages);
                        //if (nResult == Result.Success)
                        //{
                        //    ResultTips.Text = input + "的" + PrintFields.Text + "为" + inputStr + "，打印成功！";
                        //    ResultTips.BackColor = Color.Green;
                        //}

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

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsLoop = false;
            Properties.Settings.Default.Save();
            Close();
        }

        private void InputWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IsLoop = false;
            Properties.Settings.Default.Save();
            //btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
            //BtApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);
            engine.Stop();
            engine.Dispose();

        }
    }
}
