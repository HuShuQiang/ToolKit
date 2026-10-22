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
    public delegate void ChangeForm(string FormName);
    public partial class MainForm : UserControl
    {
        public event ChangeForm _changeForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MRC01_button_Click(object sender, EventArgs e)
        {
            _changeForm("MRC01");
        }

        private void MRC02_button_Click(object sender, EventArgs e)
        {
            _changeForm("MRC02");
        }

        private void LANMAC_69Code_Click(object sender, EventArgs e)
        {
            _changeForm("Tablo(LAN_MAC)");
        }

        private void _69Code_Click(object sender, EventArgs e)
        {
            _changeForm("Tablo(69Code)");
        }

        private void ExcelPrint_Click(object sender, EventArgs e)
        {
            _changeForm("ExcelPrint");
        }

        private void Check0505IMEI(object sender,EventArgs e)
        {
            _changeForm("CheckIMEI");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _changeForm("CheckNumber");
        }

        private void CheckQR_Click(object sender, EventArgs e)
        {
            _changeForm("CheckQR");
        }

        private void PrintMain_board_Click(object sender, EventArgs e)
        {
            _changeForm("PrintMain_board");
        }

        private void Decode(object sender, EventArgs e)
        {
            _changeForm("Decode");
        }

        private void OfflineCheck_Click(object sender, EventArgs e)
        {
            _changeForm("OfflineCheck");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _changeForm("ExcelPrintFields");
        }

        private void ZhaogeReprint_Click(object sender, EventArgs e)
        {
            _changeForm("ZhaogeReprint");
        }

        private void FieldsPrint_Click(object sender, EventArgs e)
        {
            _changeForm("FieldsPrint");
        }

        private void OfflineCheckFields_Click(object sender, EventArgs e)
        {
            _changeForm("OfflineCheckFields");
        }

        private void CheckFieldsStation_Click(object sender, EventArgs e)
        {
            _changeForm("CheckFieldsStation");
        }

        private void TagListPrint_Click(object sender, EventArgs e)
        {
            _changeForm("TagListPrint");
        }

        private void MTTagListPrint_Click(object sender, EventArgs e)
        {
            _changeForm("MTTagListPrint");
        }
    }
}
