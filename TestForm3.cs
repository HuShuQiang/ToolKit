using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICell = NPOI.SS.UserModel.ICell;

namespace 工具集合
{


    public partial class TestForm3 : UserControl
    {
        public event Back back;
        private string excelpath;
        private string bartenderpath;
        private string caseCodePrefix;
        private int caseCodeLength;
        private int firstCase;
        private int lastCase;
        private int caseNumber;
        private string printer;
        private DataTable datatable;
        private PageValues pageValues;

        public TestForm3()
        {
            InitializeComponent();
            GetPrinter();
            excelpath = Properties.Settings.Default.ExcelPath;
            bartenderpath = Properties.Settings.Default.BartenderPath;
            ExcelPath.Text = excelpath;
            BarTenderPath.Text = bartenderpath;
            caseCodePrefix = Properties.Settings.Default.CaseCodePrefix;
            caseCodeLength = Convert.ToInt32(Properties.Settings.Default.CaseCodeLength);
            CaseCodePrefix.Text = caseCodePrefix;
            CaseCodeLength.Text = caseCodeLength.ToString(); ;
            firstCase = Convert.ToInt32(Properties.Settings.Default.FirstCase);
            lastCase = Convert.ToInt32(Properties.Settings.Default.LastCase);
            FirstCase.Text = firstCase.ToString();
            LastCase.Text = lastCase.ToString();
            caseNumber = Convert.ToInt32(Properties.Settings.Default.CaseNumber);
            CaseNumber.Text = caseNumber.ToString();
            datatable = new DataTable();
            datatable.Columns.Add("CaseCode", typeof(string));
            datatable.Columns.Add("Serial", typeof(string));


        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
            BackColor = Color.LightCoral;
        }

        private void GetPrinter()
        {
            List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
            foreach (String s in list)
            {
                PrinterList.Items.Add(s); //将打印机名称添加到下拉框中
            }
            PrinterList.Text = LocalPrinter.DefaultPrinter();
            printer = PrinterList.Text;
        }

        private void PrinterList_TextChanged(object sender, EventArgs e)
        {
            LocalPrinter.SetDefaultPrinter(PrinterList.Text);
            printer = PrinterList.Text;
        }

        private string OpenPath()
        {
            string Filepath = "";
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "选择文件";
            openFile.Filter = "所有文件(*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Filepath = openFile.FileName;
            }
            return Filepath;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "Excel_Button")
            {
                string Path = OpenPath();
                if (!string.IsNullOrEmpty(Path))
                {
                    excelpath = Path;
                    ExcelPath.Text = excelpath;
                }


            }
            else if (button.Name == "BarTender_Button")
            {
                string Path = OpenPath();
                if (!string.IsNullOrEmpty(Path))
                {
                    bartenderpath = Path;
                    BarTenderPath.Text = bartenderpath;
                }
            }
        }

        private bool PrintExcel()
        {
            bool result = false;
            datatable = ExcelData(excelpath);
            if(datatable.Rows.Count>0)
            {
                Regex regex = new Regex(string.Format("\\w{0}", "{" + caseCodeLength + "}"));

                for (int x = firstCase; x <= lastCase; x++)
                {

                    string Case = string.Format("{0}{1}", caseCodePrefix, x);
                    if (!regex.IsMatch(Case))
                    {
                        Case = string.Format("{0}{1}", caseCodePrefix, x.ToString().PadLeft(5, '0'));
                    }
                    List<DataRow> row = datatable.AsEnumerable().Where(p => p["CaseCode"].ToString() == Case).ToList();
                    if (row.Count > 0)
                    {
                        PrintPage(row);
                    }
                }
                result = true;
            }
            else
            {
                MessageBox.Show("数据异常，退出打印！");
                
            }
            

            return result;

        }

        private bool PrintTest()
        {
            datatable = ExcelData(excelpath);
            Regex regex = new Regex(string.Format("\\w{0}", "{" + caseCodeLength + "}"));

            string Case = string.Format("{0}{1}", caseCodePrefix, 1);
            if (!regex.IsMatch(Case))
            {
                Case = string.Format("{0}{1}", caseCodePrefix, "1".ToString().PadLeft(5, '0'));
            }
            List<DataRow> row = datatable.AsEnumerable().Where(p => p["CaseCode"].ToString() == Case).ToList();
            PrintPage(row);

            return true;

        }

        private DataTable ExcelData(string fileName, string sheetName = null)
        {
            IWorkbook workbook = null;
            FileStream fs = null;
            ISheet sheet = null;
            DataTable data = new DataTable();
            data.Columns.Add("CaseCode", typeof(string));
            data.Columns.Add("Serial", typeof(string));
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                {
                    workbook = new HSSFWorkbook(fs);
                }

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);

                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {

                    int rowCount = sheet.LastRowNum;
                    int firstRow = (firstCase - 1) * caseNumber + 1;
                    int lastRow = lastCase * caseNumber;
                    IRow row = sheet.GetRow(0);

                    if (firstRow > 0 & lastRow <= rowCount)
                    {
                        int casenum = 0;
                        for (int x = 1; x <= rowCount; x++)
                        {
                            if (!string.IsNullOrEmpty(sheet.GetRow(x).GetCell(1).ToString()))
                            {
                                casenum++;
                            }
                        }
                        Data item = new Data();
                        for (int i = 1; i <= rowCount; i++)
                        {

                            if (!string.IsNullOrEmpty(sheet.GetRow(i).GetCell(2).StringCellValue))
                            {
                                try
                                {
                                    ICell cell = sheet.GetRow(i).GetCell(1);
                                    //if (!string.IsNullOrEmpty(cell.ToString()))
                                    //{
                                    Regex regex = new Regex(string.Format("\\w{0}", "{" + caseCodeLength + "}"));

                                    if (cell.CellType == CellType.String)
                                    {
                                        item.Cartoon = string.Format("{0}", cell.StringCellValue);
                                        if (!regex.IsMatch(item.Cartoon))
                                        {
                                            item.Cartoon = string.Format("{0}{1}", caseCodePrefix, (cell.StringCellValue).PadLeft(5, '0'));
                                        }

                                    }
                                    else if (cell.CellType == CellType.Numeric)
                                    {
                                        item.Cartoon = string.Format("{0}", cell.NumericCellValue.ToString());
                                        if (!regex.IsMatch(item.Cartoon))
                                        {
                                            item.Cartoon = string.Format("{0}{1}", caseCodePrefix, (cell.NumericCellValue.ToString()).PadLeft(5, '0'));
                                        }
                                    }

                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message);
                                }



                                try
                                {
                                    ICell cell = sheet.GetRow(i).GetCell(2);
                                    if (!string.IsNullOrEmpty(cell.StringCellValue))
                                    {
                                        if (cell.CellType == CellType.String)
                                        {
                                            item.SERIAL = cell.StringCellValue;
                                        }
                                        else if (cell.CellType == CellType.Numeric)
                                        {
                                            item.SERIAL = cell.NumericCellValue.ToString();
                                        }

                                    }
                                    else
                                    {
                                        item.SERIAL = "";
                                    }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message);
                                }


                                data.Rows.Add(item.Cartoon, item.SERIAL);
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("箱号范围与实际不符，请检查实际范围");
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入异常：" + ex.Message);

            }

            return data;
        }

        /// <summary>  
        /// 将excel导入到datatable  
        /// </summary>  
        /// <param name="filePath">excel路径</param>  
        /// <param name="isColumnName">第一行是否是列名</param>  
        /// <returns>返回datatable</returns>  
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;
            try
            {
                using (fs = System.IO.File.OpenRead(filePath))
                {
                    // 2007版本  
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本  
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheetAt(0);//读取第一个sheet，当然也可以循环读取每个sheet  
                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;//总行数  
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(0);//第一行  
                                int cellCount = firstRow.LastCellNum;//列数  

                                //构建datatable的列  
                                if (isColumnName)
                                {
                                    startRow = 1;//如果第一行是列名，则从第二行开始读取  
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                //填充行  
                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        if (row.GetCell(j).IsMergedCell)
                                        {
                                            for (int x = 0; x < row.GetCell(j).Sheet.NumMergedRegions; x++)
                                            {
                                                var cellRange = row.GetCell(j).Sheet.GetMergedRegion(x);
                                                if (row.GetCell(j).ColumnIndex >= cellRange.FirstColumn && row.GetCell(j).ColumnIndex <= cellRange.LastColumn &&
                                                row.GetCell(j).RowIndex >= cellRange.FirstRow && row.GetCell(j).RowIndex <= cellRange.LastRow)
                                                {
                                                    cell = row.GetCell(j).Sheet.GetRow(cellRange.FirstRow).GetCell(cellRange.FirstColumn);
                                                    break;
                                                }

                                            }

                                        }
                                        else
                                        {
                                            cell = row.GetCell(j);
                                        }

                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                            switch (cell.CellType)
                                            {
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.Numeric:
                                                    short format = cell.CellStyle.DataFormat;
                                                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)
                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                throw ex;
            }
        }

        private static CellRangeAddress GetMergedRegion(ISheet sheet, int rowNum, int colNum, out int index)
        {
            index = -1;
            var b = false;
            CellRangeAddress region = null;
            for (int i = 0; i < sheet.NumMergedRegions; i++)
            {
                region = sheet.GetMergedRegion(i);
                if (region.FirstRow <= rowNum && rowNum <= region.LastRow && region.FirstColumn <= colNum && colNum <= region.LastColumn) b = true;
                if (b)
                {
                    index = i;
                    break;
                }
            }

            return b ? region : null;
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "ExcelPath")
            {
                if (!string.IsNullOrEmpty(ExcelPath.Text))
                {
                    Properties.Settings.Default.ExcelPath = ExcelPath.Text;
                    excelpath = Properties.Settings.Default.ExcelPath;
                    Properties.Settings.Default.Save();
                }
            }
            else if (textBox.Name == "BarTenderPath")
            {
                if (!string.IsNullOrEmpty(BarTenderPath.Text))
                {
                    Properties.Settings.Default.BartenderPath = BarTenderPath.Text;
                    bartenderpath = Properties.Settings.Default.BartenderPath;
                    Properties.Settings.Default.Save();
                }
            }
            else if (textBox.Name == "CaseCodePrefix")
            {
                if (!string.IsNullOrEmpty(CaseCodePrefix.Text))
                {
                    Properties.Settings.Default.CaseCodePrefix = CaseCodePrefix.Text;
                    caseCodePrefix = Properties.Settings.Default.CaseCodePrefix;
                    Properties.Settings.Default.Save();
                }
            }
            else if (textBox.Name == "CaseCodeLength")
            {
                if (!string.IsNullOrEmpty(CaseCodeLength.Text))
                {
                    Properties.Settings.Default.CaseCodeLength = CaseCodeLength.Text;
                    caseCodeLength = Convert.ToInt32(Properties.Settings.Default.CaseCodeLength);
                    Properties.Settings.Default.Save();
                }
            }
            else if (textBox.Name == "FirstCase")
            {
                if (!string.IsNullOrEmpty(FirstCase.Text))
                {
                    Properties.Settings.Default.FirstCase = FirstCase.Text;
                    firstCase = Convert.ToInt32(Properties.Settings.Default.FirstCase);
                    Properties.Settings.Default.Save();
                }
            }
            else if (textBox.Name == "LastCase")
            {
                if (!string.IsNullOrEmpty(LastCase.Text))
                {
                    Properties.Settings.Default.LastCase = LastCase.Text;
                    lastCase = Convert.ToInt32(Properties.Settings.Default.LastCase);
                    Properties.Settings.Default.Save();
                }
            }
            else if (textBox.Name == "CaseNumber")
            {
                if (!string.IsNullOrEmpty(CaseNumber.Text))
                {
                    Properties.Settings.Default.CaseNumber = CaseNumber.Text;
                    caseNumber = Convert.ToInt32(Properties.Settings.Default.CaseNumber);
                    Properties.Settings.Default.Save();
                }
            }
        }

        private  void PrintPage(List<DataRow> datas)
        {

            //await Task.Run(() =>
            //{
                if (datas != null)
                {

                    if (printer != "")
                    {
                        if (File.Exists(bartenderpath))
                        {
                            Engine btEngine = new Engine();

                            bool isAlive = btEngine.IsAlive;

                            btEngine.Start();

                            LabelFormatDocument btFormat = btEngine.Documents.Open(bartenderpath);//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。

                            btFormat.PrintSetup.PrinterName = printer;

                            btFormat.PrintSetup.IdenticalCopiesOfLabel = 1; //打印份数

                            btFormat.SubStrings["caseCode"].Value = datas[0][0].ToString();

                            for (int x = 0; x < datas.Count; x++)
                            {
                                btFormat.SubStrings[string.Format("sn{0}", x + 1)].Value = datas[x][1].ToString();
                            }
                            //if (Sn != "")
                            //{
                            //    btFormat.SubStrings["sn"].Value = Sn;
                            //}
                            //else
                            //{
                            //    btFormat.SubStrings["sn"].Value = "000000";
                            //}

                            Messages messages;

                            //int waitout = 500; // 5秒 超时

                            //Result nResult = btFormat.Print("工具集合", waitout, out messages);
                            Result nResult = btFormat.Print("PrintPages", out messages);

                            btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;

                            btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改

                            btEngine.Stop();
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
            //});

        }

        private void Start_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "开始打印")
            {
                button.Text = "打印中";
                button.BackColor = Color.Yellow;
                Test.Enabled = false;

                if (PrintExcel())
                {
                    button.Text = "开始打印";
                    button.BackColor = Color.SpringGreen;
                    Test.Enabled = true;
                    MessageBox.Show("打印完成！");
                }
                else
                {
                    
                    button.Text = "开始打印";
                    button.BackColor = Color.SpringGreen;
                    Test.Enabled = true;
                }
            }
            else if (button.Text == "打印中")
            {
                if (MessageBox.Show("是否确认停止打印？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    button.Text = "开始打印";
                    button.BackColor = Color.SpringGreen;
                    Test.Enabled = true;
                }

            }
        }

        private void Test_Click(object sender, EventArgs e)
        {
            Test.Text = "测试中";
            Test.BackColor = Color.Yellow;
            Test.Enabled = false;
            Start.Enabled = false;
            if (PrintTest())
            {
                Test.Text = "测试成功！";
                Test.BackColor = Color.LightSeaGreen;
                Start.Enabled = true;
                Test.Enabled = true;
            }
        }
    }

    public class LocalPrinter
    {
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(String Name); //调用win api将指定名称的打印机设置为默认打印机

        private static PrintDocument fPrintDocument = new PrintDocument();
        //获取本机默认打印机名称
        public static String DefaultPrinter()
        {
            return fPrintDocument.PrinterSettings.PrinterName;
        }
        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            fPrinters.Add(DefaultPrinter()); //默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                {
                    fPrinters.Add(fPrinterName);
                }
            }
            return fPrinters;
        }
    }


    struct PageValues
    {
        public string caseCode;
        public string sn1;
        public string sn2;
        public string sn3;
        public string sn4;
        public string sn5;
        public string sn6;
        public string sn7;
        public string sn8;
        public string sn9;
        public string sn10;
        public string sn11;
        public string sn12;
        public string sn13;
        public string sn14;
        public string sn15;
        public string sn16;
        public string sn17;
        public string sn18;
        public string sn19;
        public string sn20;
        public string sn21;
        public string sn22;
        public string sn23;
        public string sn24;
        public string sn25;
        public string sn26;
        public string sn27;
        public string sn28;
        public string sn29;
        public string sn30;

    }

    public class Data
    {
        public string Cartoon { get; set; }
        public string SERIAL { get; set; }
    }

}
