using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class OfflineCheck : UserControl
    {
        public event Back back;
        private string input1 = string.Empty;
        private string input2 = string.Empty;
        public OfflineCheck()
        {
            InitializeComponent();
            inputname.Text = Properties.Settings.Default.InputName;
            checkname.Text = Properties.Settings.Default.CheckName;
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }


        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Form form = new OfflineCheckSettings();
            form.ShowDialog();
            inputname.Text = Properties.Settings.Default.InputName;
            checkname.Text = Properties.Settings.Default.CheckName;
        }

        private void Input1_KeyDown(object sender, KeyEventArgs e)
        {
            ResultTips.Text = "";
            if(e.KeyCode == Keys.Enter)
            {
                input1 = Input1.Text;
                Input2.Focus();
            }
        }

        private void Input2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                input2 = Input2.Text;
                string filepath = Properties.Settings.Default.SourceFile;
                IDictionary<string, object> FirstRows = MiniExcel.Query(filepath).First();
                List<string> fields = new List<string>();
                foreach (string key in FirstRows.Keys)
                {
                    fields.Add(FirstRows[key].ToString());
                }

                DataTable datatable = MiniExcel.QueryAsDataTable(filepath, useHeaderRow: true);

                DataRow[] alldata = datatable.Select(Properties.Settings.Default.InputName + "='" + Input1.Text + "'");

                if (alldata.Length > 0)
                {
                    DataRow data = alldata[0];
                    int num = fields.IndexOf(Properties.Settings.Default.CheckName);
                    if (data[num].ToString() == Input2.Text)
                    {
                        ResultTips.Text = Input1.Text + "和" + Input2.Text + "对比PASS！";
                        ResultTips.BackColor = Color.Green;
                    }
                    else
                    {
                        ResultTips.Text = Input1.Text + "和" + Input2.Text + "对比NG！";
                        ResultTips.BackColor = Color.Red;
                    }
                }
                else
                {
                    ResultTips.Text = "Excel文件中不存在"+ Properties.Settings.Default.InputName+"="+Input1.Text;
                    ResultTips.BackColor = Color.Red;
                }

                

                Input1.Clear();
                Input2.Clear();
                Input1.Focus();
            }
        }
    }
}