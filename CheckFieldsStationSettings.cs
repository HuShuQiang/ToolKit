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
    public partial class CheckFieldsStationSettings : Form
    {
        public CheckFieldsStationSettings()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Model.Text = Properties.Settings.Default.CheckFields_Model;
            Fixid.Text = Properties.Settings.Default.CheckFields_Fixid;
            Station.Text = Properties.Settings.Default.CheckFields_Station;
            FieldsList.Text = Properties.Settings.Default.CheckFields_FieldsList;
            IsUploadStation.Checked = Properties.Settings.Default.CheckFields_IsUploadStation;
            FieldRegex.Text = Properties.Settings.Default.FieldRegex;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckFields_Model = Model.Text;
            Properties.Settings.Default.CheckFields_Fixid = Fixid.Text;
            Properties.Settings.Default.CheckFields_Station = Station.Text;
            Properties.Settings.Default.CheckFields_FieldsList = FieldsList.Text;
            Properties.Settings.Default.CheckFields_IsUploadStation = IsUploadStation.Checked;
            Properties.Settings.Default.FieldRegex = FieldRegex.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
