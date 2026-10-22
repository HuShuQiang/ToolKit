using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class TagListPrintView : UserControl
    {
        public event Back back;
        private int ScanTagCount = 0;
        public static Engine engine = null;
        private LabelFormatDocument btFormat = null;
        private List<string> LastList = new List<string>();
        public TagListPrintView()
        {
            InitializeComponent();
            TagList.RowTemplate.Height = 40;
            TagList.RowPostPaint += dataGridView1_RowPostPaint;
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 行号列没启用就别画了
            if (!TagList.RowHeadersVisible) return;
            var rect = new Rectangle(
                e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                TagList.RowHeadersWidth,
                e.RowBounds.Height);
            TextRenderer.DrawText(
                e.Graphics,
                (e.RowIndex + 1).ToString(),
                TagList.RowHeadersDefaultCellStyle.Font,
                rect,
                TagList.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void TagList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < TagList.Rows.Count; i++)
            {
                TagList.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            RefreshRowNumbers();
            SafeScrollToBottom();
        }

        private void SafeScrollToBottom()
        {
            try
            {
                if (TagList.Rows.Count == 0) return;

                int lastRow = TagList.Rows.Count - 1;

                int visibleRows = TagList.DisplayedRowCount(true);
                if (visibleRows > 0 && lastRow >= 0)
                {
                    TagList.FirstDisplayedScrollingRowIndex = lastRow;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"滚动失败: {ex.Message}");
            }
        }

        private void RefreshRowNumbers()
        {
            for (int i = 0; i < TagList.Rows.Count; i++)
            {
                TagList.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            ScanNum.Text = TagList.Rows.Count.ToString();
        }

        private void TagList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshRowNumbers();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            TagListPrintSettings settingsForm = new TagListPrintSettings();
            settingsForm.ShowDialog();
            TagListPrintView_Load(null, null);
        }

        private bool IsColumnDuplicate(DataGridView dgv, int columnIndex, string newValue)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnIndex].Value?.ToString() == newValue)
                {
                    return true;  // 找到重复
                }
            }
            return false;  // 无重复
        }

        private int FindRowIndex(DataGridView dgv, int columnIndex, string searchValue)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string cellValue = dgv.Rows[i].Cells[columnIndex].Value?.ToString();
                if (cellValue == searchValue)
                {
                    return i;  // 找到，返回行索引
                }
            }
            return -1;  // 未找到
        }

        private void InputValue_KeyDown(object sender, KeyEventArgs e)
        {
            PrintResult.Text = "";
            Tips.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(InputValue.Text))
                {
                    Regex regex = new Regex(TagRegex.Text);
                    if (regex.IsMatch(InputValue.Text))
                    {
                        if (IsColumnDuplicate(TagList,0,InputValue.Text))
                        {
                            int index = FindRowIndex(TagList, 0, InputValue.Text) +1;
                            Tips.Text = $"输入的条码{InputValue.Text} 已存在第{index}行，无法重复扫描！";
                            Tips.BackColor = Color.Red;
                            
                            InputValue.Clear();
                            return;
                        }

                        
                        TagList.Rows.Add(InputValue.Text);
                        InputValue.Clear();

                        if (TagList.Rows.Count == int.Parse(TagNum.Text))
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int i = 0; i < TagList.Rows.Count; i++)
                            {
                                stringBuilder.Append(TagList.Rows[i].Cells[0].Value.ToString() + ",");
                            }
                            string value = stringBuilder.ToString().TrimEnd(',');
                            LastList = value.Split(',').ToList();
                            Task.Factory.StartNew(() =>
                            {
                                PrintTag(value);
                            }).Wait();

                            TagList.Rows.Clear();
                        }
                    }
                    else
                    {
                        Tips.Text = $"输入的条码{InputValue.Text} 格式不正确，请核查！";
                        Tips.BackColor = Color.Red;
                        InputValue.Clear();
                        return;
                    }

                }
            }
        }

        private void PrintTag(string inputvalue)
        {

            if (!string.IsNullOrEmpty(inputvalue))
            {

                if (Printer.Text != "")
                {
                    if (File.Exists(FilePath.Text))
                    {
                        if (engine == null)
                        {
                            engine = new Engine(true);
                        }
                        btFormat = engine.Documents.Open(FilePath.Text);

                        btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;
                        btFormat.PrintSetup.NumberOfSerializedLabels = 1;


                        btFormat.PrintSetup.PrinterName = Printer.Text;

                        btFormat.PrintSetup.IdenticalCopiesOfLabel = int.Parse(PrintNum.Text); //打印份数


                        btFormat.SubStrings[DataSource.Text].Value = inputvalue;


                        Messages messages;

                        Result nResult = btFormat.Print("打印工具", out messages);
                        if (nResult == Result.Success)
                        {
                            PrintResult.Text = "打印成功！";
                            PrintResult.BackColor = Color.Green;
                            
                        }
                        else
                        {
                            PrintResult.Text = "打印失败！";
                            PrintResult.BackColor = Color.Red;
                        }

                        btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;

                        btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改

                        //btEngine.Stop();
                        //btEngine.Dispose();
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
                //ResultTips.Text = input + "的" + PrintFields.Text + "为空，打印失败！";
                //ResultTips.BackColor = Color.Red;
            }
            // });




        }

        private void TagListPrintView_Load(object sender, EventArgs e)
        {

            FilePath.Text = Properties.Settings.Default.PrintFilePath;
            if (string.IsNullOrEmpty(FilePath.Text))
            {
                FilePath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SN.btw");
            }
            DataSource.Text = Properties.Settings.Default.DataSource;
            TagNum.Text = Properties.Settings.Default.TagNum;
            Character.Text = Properties.Settings.Default.Character;
            TagRegex.Text = Properties.Settings.Default.TagRegex;
            Printer.Text = Properties.Settings.Default.Printer;
            InputValue.Select();
            InputValue.Focus();
        }

        private void RePrint_Click(object sender, EventArgs e)
        {
            string value = string.Join(",", LastList);
            Task.Factory.StartNew(() =>
            {
                PrintTag(value);
            }).Wait();
        }
    }
}
