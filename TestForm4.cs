using MiniExcelLibs;
using Newtonsoft.Json;
using NPOI.XWPF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class TestForm4 : UserControl
    {
        public event Back back;
        private string path { get; set; }
        public TestForm4()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.model))
            {
                model.Text = Properties.Settings.Default.model;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.dutname))
            {
                dutname.Text = Properties.Settings.Default.dutname;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.filepath))
            {
                filepath.Text = Properties.Settings.Default.filepath;
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.CheckFields))
            {
                checkfields.Text = Properties.Settings.Default.CheckFields;
            }

            

        }

        public void GetModel(string model)
        {
            TestName.Text = model;
            BackColor = Color.PeachPuff;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void model_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.model = model.Text;
            Properties.Settings.Default.Save();
        }

        private void dutname_TextChanged(object sender, EventArgs e)
        {
            Dut.Text = dutname.Text;
            Properties.Settings.Default.dutname = dutname.Text;
            Properties.Settings.Default.Save();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Fields = CheckFields(Input.Text);
                if (Fields == "")
                {
                    Tips.Text = Input.Text + "绑定"+checkfields.Text+"数据为空！";
                    ResultShow(Input.Text, false);
                }
                else
                {
                    Tips.Text = Input.Text + "绑定"+checkfields.Text+"数据为：" + Fields;
                    if (CheckExcel(Fields))
                    {
                        if (SelectNG.Checked)
                        {
                            Tips.Text = Tips.Text + "\r" + "Excel成功查询到对应" + Fields + "！";
                            ResultShow(Input.Text, false);
                        }
                        else
                        {
                            Tips.Text = Tips.Text + "\r" + "Excel成功查询到对应" + Fields + "！";
                            ResultShow(Input.Text, true);
                        }
                    }
                    else
                    {
                        if (SelectNG.Checked)
                        {
                            Tips.Text = Tips.Text + "\r" + "Excel未查询到对应" + Fields + "！";
                            ResultShow(Input.Text, true);
                        }
                        else
                        {
                            Tips.Text = Tips.Text + "\r" + "Excel未查询到对应" + Fields + "！";
                            ResultShow(Input.Text, false);
                        }

                    }
                }

                Input.Clear();
            }

        }

        private string CheckFields(string Input)
        {
            string imei = "";
            try
            {
                string model = Properties.Settings.Default.model;
                string dutname = Properties.Settings.Default.dutname;
                string url = "http://192.168.8.8/box_cms_v3/mes_v1/getDutFields.php?model=" + model + "&dut_number_name=" + dutname + "&dut_number_value=" + Input;
                string JsonStr = GetInfo(url);
                Hashtable hashtable = new Hashtable(JsonConvert.DeserializeObject<Hashtable>(JsonStr));
                string fields = hashtable["fields"].ToString();
                Hashtable hashtable2 = new Hashtable(JsonConvert.DeserializeObject<Hashtable>(fields));

                if (hashtable2[checkfields.Text]!=null)
                {
                    imei = hashtable2[checkfields.Text].ToString();
                }
                else
                {
                    imei = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return imei;
        }

        private bool CheckExcel(string Input)
        {
            bool res = false;
            try
            {
                path = Properties.Settings.Default.filepath;

                //var List = MiniExcel.Query<Test>(path).Where(p => p.IMEI == imei).First();
                var row = MiniExcel.Query(path).ToList();
                List<string> List = new List<string>();
                for(int x = 1;x<row.Count;x++)
                {
                    List.Add(row[x].A);
                }
                if (List.Contains(Input))
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return res;
        }

        private string GetInfo(string url)
        {

            string Info = "";
            try
            {
                var request = WebRequest.Create(url);
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        StreamReader RepstreamReader = new StreamReader(responseStream, Encoding.UTF8);
                        Info = RepstreamReader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("网络错误，请检查网络" + ex.Message);

            }
            return Info;

        }

        private void ResultShow(string input, bool result)
        {
            if (result)
            {
                Result.Text = input + "  " + "PASS";
                Result.BackColor = Color.GreenYellow;
            }
            else
            {
                Result.Text = input + "  " + "NG";
                Result.BackColor = Color.Red;
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "*.xlsx|*.xlsx";
            DialogResult result = openFile.ShowDialog();
            if(result == DialogResult.OK)
            {
                filepath.Text = openFile.FileName;
                Properties.Settings.Default.filepath = openFile.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void CheckFields_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckFields = checkfields.Text;
            Properties.Settings.Default.Save(); 
        }

        private void TestForm4_Load(object sender, EventArgs e)
        {
            Input.Focus();
        }
    }

    public class Test
    {
        public string IMEI { get; set; }
    }
}
