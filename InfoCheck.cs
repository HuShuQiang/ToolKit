using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class InfoCheck : UserControl
    {
        public event Back back;
        public InfoCheck()
        {
            InitializeComponent();
            //if (!string.IsNullOrEmpty(Properties.Settings.Default.model))
            //{
            //    model.Text = Properties.Settings.Default.model;
            //}
            //if (!string.IsNullOrEmpty(Properties.Settings.Default.dutname))
            //{
            //    dutname.Text = Properties.Settings.Default.dutname;
            //}
        }
        public void GetModel(string model)
        {
            //TestName.Text = model;
            BackColor = Color.PeachPuff;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        //private void model_TextChanged(object sender, EventArgs e)
        //{
        //    Properties.Settings.Default.model = model.Text;
        //    Properties.Settings.Default.Save();
        //}

        //private void dutname_TextChanged(object sender, EventArgs e)
        //{
        //    Dut.Text = dutname.Text;
        //    Properties.Settings.Default.dutname = dutname.Text;
        //    Properties.Settings.Default.Save();
        //}

        //private void ResultShow(string input, bool result)
        //{
        //    if (result)
        //    {
        //        Result.Text = input + "  " + "存在于服务器数据库中";
        //        Result.BackColor = Color.GreenYellow;
        //    }
        //    else
        //    {
        //        Result.Text = input + "  " + "不存在于服务器数据库中";
        //        Result.BackColor = Color.Red;
        //    }
        //}

        //private void Input_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Result.Text = "";

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (CheckFields(Input.Text))
        //        {
        //            ResultShow(Input.Text, true);
        //        }
        //        else
        //        {
        //            ResultShow(Input.Text, false);
        //        }


        //        Input.Clear();
        //    }

        //}

        //private bool CheckFields(string Input)
        //{
        //    bool res = false;
        //    try
        //    {
        //        string model = Properties.Settings.Default.model;
        //        string dutname = Properties.Settings.Default.dutname;
        //        string url = "http://192.168.8.8/box_cms_v3/mes_v1/getDutFields.php?model=" + model + "&dut_number_name=" + dutname + "&dut_number_value=" + Input;
        //        string JsonStr = GetInfo(url);
        //        Hashtable hashtable = new Hashtable(JsonConvert.DeserializeObject<Hashtable>(JsonStr));
        //        if (hashtable["resultCode"].ToString() == "0" && hashtable["resultMsg"].ToString()== "success")
        //        {
        //            res = true;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }


        //    return res;
        //}

        //private string GetInfo(string url)
        //{

        //    string Info = "";
        //    try
        //    {
        //        var request = WebRequest.Create(url);
        //        using (var response = request.GetResponse())
        //        {
        //            using (var responseStream = response.GetResponseStream())
        //            {
        //                StreamReader RepstreamReader = new StreamReader(responseStream, Encoding.UTF8);
        //                Info = RepstreamReader.ReadToEnd();
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        MessageBox.Show("网络错误，请检查网络" + ex.Message);

        //    }
        //    return Info;

        //}

        //private void TestForm4_Load(object sender, EventArgs e)
        //{
        //    Input.Focus();
        //}

    }
}
