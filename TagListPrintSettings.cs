using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class TagListPrintSettings : Form
    {
        public TagListPrintSettings()
        {
            InitializeComponent();
            Text = "条码集合打印设置";
        }

        private void SelectFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "标签模板|*.btw";
            if(openFile.ShowDialog()== DialogResult.OK )
            {
                FilePath.Text = openFile.FileName;
            }
            else
            {
                FilePath.Text = "";
            }
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrintFilePath = FilePath.Text;
            if (string.IsNullOrEmpty(FilePath.Text))
            {
                Properties.Settings.Default.PrintFilePath = AppDomain.CurrentDomain.BaseDirectory+"SN.btw";
            }
            Properties.Settings.Default.DataSource = DataSource.Text;
            Properties.Settings.Default.TagNum = TagNum.Text;
            Properties.Settings.Default.Character = Character.Text;
            Properties.Settings.Default.TagRegex = TagRegex.Text;
            Properties.Settings.Default.Printer = PrinterList.Text;
            Properties.Settings.Default.PrintNum = PrintNum.Text;
            Properties.Settings.Default.Save();
            Close();
        }

        private void TagListPrintSettings_Load(object sender, EventArgs e)
        {
            FilePath.Text = Properties.Settings.Default.PrintFilePath;
            DataSource.Text = Properties.Settings.Default.DataSource;
            TagNum.Text = Properties.Settings.Default.TagNum;
            Character.Text = Properties.Settings.Default.Character;
            TagRegex.Text = Properties.Settings.Default.TagRegex;
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                PrinterList.Items.Add(printerName);
            }
            PrinterList.Text = Properties.Settings.Default.Printer;
            PrintNum.Text = Properties.Settings.Default.PrintNum;
        }
    }
}
