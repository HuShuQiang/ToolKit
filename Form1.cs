using Seagull.BarTender.Print;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class Form1 : Form
    {
        private MainForm main;
        private TestForm test;
        private TestForm2 test2;
        private TestForm3 test3;
        private TestForm4 test4;
        private CheckNumber checknumber;
        private CheckQRForm checkqr;
        private PrintMain_board printMain;
        private Decode decode;
        private OfflineCheck offlineCheck;
        private ExcelPrintFields excelPrintFields;
        public Engine btEngine;
        private InfoCheck infoCheck;
        private ZhaogeReprint zhaogereprint;
        private FieldsPrint fieldsPrint;
        private OfflineCheckFields offlineCheckFields;
        private CheckFieldsStationView checkFieldsStation;
        private TagListPrintView tagListPrint;
        private MTTagListPrintView mtTagListPrint;
        public Form1()
        {
            InitializeComponent();
            Text = "工具集合" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            main = new MainForm();
            MainPanel.Controls.Add(main);
            main._changeForm += new ChangeForm(ChangePanel);
            main.Dock = DockStyle.Fill;
            main.Show();
        }

        private void ChangePanel(string FormName)
        {
            MainPanel.Controls.Clear();
            string Name = string.Empty;
            switch (FormName)
            {
                case "MRC01":
                    Name = "MRC01";
                    test = new TestForm();
                    test.GetModel(Name);
                    test.back += new Back(ComeBack);
                    MainPanel.Controls.Add(test);
                    test.Dock = DockStyle.Fill;
                    test.Show();
                    break;
                case "MRC02":
                    Name = "MRC02";
                    test = new TestForm();
                    test.GetModel(Name);
                    test.back += new Back(ComeBack);
                    MainPanel.Controls.Add(test);
                    test.Dock = DockStyle.Fill;
                    test.Show();
                    break;
                case "Tablo(LAN_MAC)":
                    Name = "Tablo(LAN_MAC)";
                    test2 = new TestForm2();
                    test2.GetModel(Name);
                    test2.back += new Back(ComeBack);
                    MainPanel.Controls.Add(test2);
                    test2.Dock = DockStyle.Fill;
                    test2.Show();
                    test2.Input69code.Focus();
                    break;
                case "Tablo(69Code)":
                    Name = "Tablo(69Code)";
                    test2 = new TestForm2();
                    test2.GetModel(Name);
                    test2.back += new Back(ComeBack);
                    MainPanel.Controls.Add(test2);
                    test2.Dock = DockStyle.Fill;
                    test2.Show();
                    test2.Input69code.Focus();
                    break;
                case "ExcelPrint":
                    Name = "Excel打印贴纸";
                    test3 = new TestForm3();
                    test3.GetModel(Name);
                    test3.BackColor = Color.LightCoral;
                    test3.back += new Back(ComeBack);
                    MainPanel.Controls.Add(test3);
                    test3.Dock = DockStyle.Fill;
                    test3.Show();
                    break;
                case "CheckIMEI":
                    Name = "在线核查字段";
                    test4 = new TestForm4();
                    test4.GetModel(Name);
                    test4.BackColor = Color.LightCoral;
                    test4.back += new Back(ComeBack);
                    MainPanel.Controls.Add(test4);
                    test4.Dock = DockStyle.Fill;
                    test4.Show();
                    break;
                case "CheckNumber":
                    Name = "核对号码";
                    checknumber = new CheckNumber();
                    checknumber.GetModel(Name);
                    checknumber.BackColor = Color.Gold;
                    checknumber.back += new Back(ComeBack);
                    MainPanel.Controls.Add(checknumber);
                    checknumber.Dock = DockStyle.Fill;
                    checknumber.Show();
                    break;
                case "CheckQR":
                    Name = "朝歌核对二维码";
                    checkqr = new CheckQRForm();
                    checkqr.GetModel(Name);
                    checkqr.BackColor = Color.LimeGreen;
                    checkqr.back += new Back(ComeBack);
                    MainPanel.Controls.Add(checkqr);
                    checkqr.Dock = DockStyle.Fill;
                    checkqr.Show();
                    break;
                case "PrintMain_board":
                    Name = "打印号码";
                    printMain = new PrintMain_board();
                    printMain.GetModel(Name);
                    printMain.BackColor = Color.Aquamarine;
                    printMain.back += new Back(ComeBack);
                    MainPanel.Controls.Add(printMain);
                    printMain.Dock = DockStyle.Fill;
                    printMain.Show();
                    break;
                case "Decode":
                    Name = "修正打印";
                    decode = new Decode();
                    decode.GetModel(Name);
                    decode.BackColor = Color.RoyalBlue;
                    decode.back += new Back(ComeBack);
                    MainPanel.Controls.Add(decode);
                    decode.Dock = DockStyle.Fill;
                    decode.Show();
                    break;
                case "OfflineCheck":
                    Name = "离线核对";
                    offlineCheck = new OfflineCheck();
                    offlineCheck.GetModel(Name);
                    offlineCheck.BackColor = Color.PowderBlue;
                    offlineCheck.back += new Back(ComeBack);
                    MainPanel.Controls.Add(offlineCheck);
                    offlineCheck.Dock = DockStyle.Fill;
                    offlineCheck.Show();
                    break;
                case "ExcelPrintFields":
                    Name = "Excel离线打印";
                    excelPrintFields = new ExcelPrintFields();
                    excelPrintFields.GetModel(Name);
                    excelPrintFields.BackColor = Color.SkyBlue;
                    excelPrintFields.back += new Back(ComeBack);
                    MainPanel.Controls.Add(excelPrintFields);
                    excelPrintFields.Dock = DockStyle.Fill;
                    excelPrintFields.Show();
                    break;
                case "ZhaogeReprint":
                    Name = "朝歌重打贴纸";
                    zhaogereprint = new ZhaogeReprint();
                    zhaogereprint.GetModel(Name);
                    zhaogereprint.BackColor = Color.DodgerBlue;
                    zhaogereprint.back += new Back(ComeBack);
                    MainPanel.Controls.Add(zhaogereprint);
                    zhaogereprint.Dock = DockStyle.Fill;
                    zhaogereprint.Show();
                    break;
                case "FieldsPrint":
                    Name = "双项打印";
                    fieldsPrint = new FieldsPrint();
                    fieldsPrint.GetModel(Name);
                    fieldsPrint.BackColor = Color.CornflowerBlue;
                    fieldsPrint.back += new Back(ComeBack);
                    MainPanel.Controls.Add(fieldsPrint);
                    fieldsPrint.Dock = DockStyle.Fill;
                    fieldsPrint.Show();
                    break;
                case "OfflineCheckFields":
                    Name = "离线核对字段";
                    offlineCheckFields = new OfflineCheckFields();
                    offlineCheckFields.GetModel(Name);
                    offlineCheckFields.BackColor = Color.SandyBrown;
                    offlineCheckFields.back += new Back(ComeBack);
                    MainPanel.Controls.Add(offlineCheckFields);
                    offlineCheckFields.Dock = DockStyle.Fill;
                    offlineCheckFields.Show();
                    break;
                case "CheckFieldsStation":
                    Name = "对号过站";
                    checkFieldsStation = new CheckFieldsStationView();
                    checkFieldsStation.GetModel(Name);
                    checkFieldsStation.BackColor = Color.DarkTurquoise;
                    checkFieldsStation.back += new Back(ComeBack);
                    MainPanel.Controls.Add(checkFieldsStation);
                    checkFieldsStation.Dock = DockStyle.Fill;
                    checkFieldsStation.Show();
                    break;
                case "TagListPrint":
                    Name = "条码集合打印";
                    tagListPrint = new TagListPrintView();
                    tagListPrint.GetModel(Name);
                    tagListPrint.BackColor = Color.Violet;
                    tagListPrint.back += new Back(ComeBack);
                    MainPanel.Controls.Add(tagListPrint);
                    tagListPrint.Dock = DockStyle.Fill;
                    tagListPrint.Show();
                    break;
                case "MTTagListPrint":
                    Name = "美团条码集合打印";
                    mtTagListPrint = new MTTagListPrintView();
                    mtTagListPrint.GetModel(Name);
                    mtTagListPrint.BackColor = Color.Wheat;
                    mtTagListPrint.back += new Back(ComeBack);
                    MainPanel.Controls.Add(mtTagListPrint);
                    mtTagListPrint.Dock = DockStyle.Fill;
                    mtTagListPrint.Show();
                    break;
            }
            //if (FormName == "MRC01" | FormName == "MRC02")
            //{
            //    test = new TestForm();
            //    test.GetModel(FormName);
            //    test.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(test);
            //    test.Dock = DockStyle.Fill;
            //    test.Show();
            //}
            //else if (FormName == "Tablo(LAN_MAC)" | FormName == "Tablo(69Code)")
            //{
            //    test2 = new TestForm2();
            //    test2.GetModel(FormName);
            //    test2.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(test2);
            //    test2.Dock = DockStyle.Fill;
            //    test2.Show();
            //    test2.Input69code.Focus();
            //}
            //else if (FormName == "ExcelPrint")
            //{
            //    test3 = new TestForm3();
            //    test3.GetModel("Excel打印贴纸");
            //    test3.BackColor = Color.LightCoral;
            //    test3.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(test3);
            //    test3.Dock = DockStyle.Fill;
            //    test3.Show();
            //}
            //else if (FormName == "CheckIMEI")
            //{
            //    test4 = new TestForm4();
            //    test4.GetModel("在线核查字段");
            //    test4.BackColor = Color.LightCoral;
            //    test4.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(test4);
            //    test4.Dock = DockStyle.Fill;
            //    test4.Show();
            //}
            //else if (FormName == "CheckNumber")
            //{
            //    checknumber = new CheckNumber();
            //    checknumber.GetModel("核对号码");
            //    checknumber.BackColor = Color.Gold;
            //    checknumber.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(checknumber);
            //    checknumber.Dock = DockStyle.Fill;
            //    checknumber.Show();
            //}
            //else if (FormName == "CheckQR")
            //{
            //    checkqr = new CheckQRForm();
            //    checkqr.GetModel("朝歌核对二维码");
            //    checkqr.BackColor = Color.LimeGreen;
            //    checkqr.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(checkqr);
            //    checkqr.Dock = DockStyle.Fill;
            //    checkqr.Show();
            //}
            //else if (FormName == "PrintMain_board")
            //{
            //    printMain = new PrintMain_board();
            //    printMain.GetModel("打印号码");
            //    printMain.BackColor = Color.Aquamarine;
            //    printMain.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(printMain);
            //    printMain.Dock = DockStyle.Fill;
            //    printMain.Show();
            //}
            //else if (FormName == "Decode")
            //{
            //    decode = new Decode();
            //    decode.GetModel("修正打印");
            //    decode.BackColor = Color.RoyalBlue;
            //    decode.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(decode);
            //    decode.Dock = DockStyle.Fill;
            //    decode.Show();
            //}
            //else if (FormName == "OfflineCheck")
            //{
            //    offlineCheck = new OfflineCheck();
            //    offlineCheck.GetModel("离线核对");
            //    offlineCheck.BackColor = Color.PowderBlue;
            //    offlineCheck.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(offlineCheck);
            //    offlineCheck.Dock = DockStyle.Fill;
            //    offlineCheck.Show();
            //}
            //else if (FormName == "ExcelPrintFields")
            //{
            //    excelPrintFields = new ExcelPrintFields();
            //    excelPrintFields.GetModel("Excel离线打印");
            //    excelPrintFields.BackColor = Color.SkyBlue;
            //    excelPrintFields.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(excelPrintFields);
            //    excelPrintFields.Dock = DockStyle.Fill;
            //    excelPrintFields.Show();
            //}
            //else if (FormName == "ZhaogeReprint")
            //{
            //    zhaogereprint = new ZhaogeReprint();
            //    zhaogereprint.GetModel("朝歌重打贴纸");
            //    zhaogereprint.BackColor = Color.DodgerBlue;
            //    zhaogereprint.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(zhaogereprint);
            //    zhaogereprint.Dock = DockStyle.Fill;
            //    zhaogereprint.Show();
            //}
            //else if (FormName == "FieldsPrint")
            //{
            //    fieldsPrint = new FieldsPrint();
            //    fieldsPrint.GetModel("双项打印");
            //    fieldsPrint.BackColor = Color.CornflowerBlue;
            //    fieldsPrint.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(fieldsPrint);
            //    fieldsPrint.Dock = DockStyle.Fill;
            //    fieldsPrint.Show();
            //}
            //else if (FormName == "OfflineCheckFields")
            //{
            //    offlineCheckFields = new OfflineCheckFields();
            //    offlineCheckFields.GetModel("离线核对字段");
            //    offlineCheckFields.BackColor = Color.SandyBrown;
            //    offlineCheckFields.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(offlineCheckFields);
            //    offlineCheckFields.Dock = DockStyle.Fill;
            //    offlineCheckFields.Show();
            //}
            //else if (FormName == "CheckFieldsStation")
            //{
            //    checkFieldsStation = new CheckFieldsStationView();
            //    checkFieldsStation.GetModel("对号过站");
            //    checkFieldsStation.BackColor = Color.DarkTurquoise;
            //    checkFieldsStation.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(checkFieldsStation);
            //    checkFieldsStation.Dock = DockStyle.Fill;
            //    checkFieldsStation.Show();
            //}
            //else if (FormName == "TagListPrint")
            //{
            //    tagListPrint = new TagListPrintView();
            //    tagListPrint.GetModel("条码集合打印");
            //    tagListPrint.BackColor = Color.Violet;
            //    tagListPrint.back += new Back(ComeBack);
            //    MainPanel.Controls.Add(tagListPrint);
            //    tagListPrint.Dock = DockStyle.Fill;
            //    tagListPrint.Show();
            //}

        }

        private void ComeBack()
        {
            MainPanel.Controls.Clear();
            main = new MainForm();
            MainPanel.Controls.Add(main);
            main.Dock = DockStyle.Fill;
            main._changeForm += new ChangeForm(ChangePanel);
            main.Show();
        }



    }
}
