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
using MiniExcelLibs;
using Seagull.BarTender.Print;

namespace 工具集合
{
    public partial class OfflineCheckFields : UserControl
    {
        public event Back back;
        public OfflineCheckFields()
        {
            InitializeComponent();
            ExcelPath.Text = Properties.Settings.Default.OfflineCheckExcelPath;
            CheckFields.Text = Properties.Settings.Default.OfflineCheckFields;
            InputName.Text = CheckFields.Text + ":";
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void SelectExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel文件|*.xlsx";
            openFileDialog.Title = "选择Excel文件";
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                ExcelPath.Text = openFileDialog.FileName;
                Properties.Settings.Default.OfflineCheckExcelPath = ExcelPath.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ResultTips.Text = "";
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(CheckFields.Text))
                    {
                        MessageBox.Show("检查字段名不能为空！");
                        return;
                    }

                    if (string.IsNullOrEmpty(Input.Text))
                    {
                        MessageBox.Show("输入内容不能为空！");
                        return;
                    }

                    var FirstRows = MiniExcel.Query(ExcelPath.Text).First();
                    var row = MiniExcel.Query(ExcelPath.Text).ToList();
                    DataTable datatable = MiniExcel.QueryAsDataTable(ExcelPath.Text, useHeaderRow: true);

                    DataRow[] data = datatable.Select(CheckFields.Text + "='" + Input.Text + "'");
                    if (SelectNg.Checked)
                    {
                        if (data.Length > 0)
                        {
                            string value = data[0][CheckFields.Text].ToString();
                            ResultTips.Text = Input.Text + "存在Excel文件中，NG！";
                            ResultTips.BackColor = Color.Red;
                        }
                        else
                        {
                            ResultTips.Text = Input.Text + "不存在Excel文件中，PASS！";
                            ResultTips.BackColor = Color.GreenYellow;
                        }
                    }
                    else
                    {
                        if (data.Length > 0)
                        {
                            string value = data[0][CheckFields.Text].ToString();
                            ResultTips.Text = Input.Text + "存在Excel文件中，PASS！";
                            ResultTips.BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            ResultTips.Text = Input.Text + "不存在Excel文件中，NG！";
                            ResultTips.BackColor = Color.Red;
                        }
                    }

                    Input.Clear();
                    Input.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CheckFields.Text+"字段不存在Excel中，请检查字段正确名称！");
            }
            
        }

        private void CheckFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(CheckFields.Text))
                {
                    MessageBox.Show("检查字段名不能为空！");
                    return;
                }
                Properties.Settings.Default.OfflineCheckFields = CheckFields.Text;
                Properties.Settings.Default.Save();
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        InputName.Text = CheckFields.Text + ":";
                    }));
                }
                else
                {
                    InputName.Text = CheckFields.Text + ":";
                }

            }
        }
    }
}
