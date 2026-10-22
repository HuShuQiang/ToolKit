using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class OfflineCheckSettings : Form
    {
        public OfflineCheckSettings()
        {
            InitializeComponent();
            SourceFile.Text = Properties.Settings.Default.SourceFile;
            InputName.Text = Properties.Settings.Default.InputName;
            CheckName.Text = Properties.Settings.Default.CheckName;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "*.xlsx|*.xlsx";
            DialogResult result =  openFile.ShowDialog();
            if(result == DialogResult.OK)
            {
                SourceFile.Text = openFile.FileName;
            }
        }

        private void SourceFile_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SourceFile = SourceFile.Text;
            Properties.Settings.Default.Save();
        }

        private void InputName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputName = InputName.Text;
            Properties.Settings.Default.Save();
        }

        private void CheckName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckName = CheckName.Text;
            Properties.Settings.Default.Save();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SourceFile = SourceFile.Text;
            Properties.Settings.Default.InputName = InputName.Text;
            Properties.Settings.Default.CheckName = CheckName.Text;

            Properties.Settings.Default.Save();
            MessageBox.Show("保存成功！");
        }
    }
}
