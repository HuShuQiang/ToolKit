using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工具集合
{
    public partial class CheckNumber : UserControl
    {
        private string Value1 { get; set; }
        private string Value2 { get; set; }
        public event Back back;
        public CheckNumber()
        {
            InitializeComponent();

            Input1.KeyDown += new KeyEventHandler(Input);
            Input2.KeyDown += new KeyEventHandler(Input);
            Input2.GotFocus += new EventHandler(Focus);
            ComeBack.Click += new EventHandler(ComeBack_Click);
            Input1.Focus();
        }

        public void GetModel(string model)
        {
            TestName.Text = model;
            BackColor = Color.Gold;
        }

        private void ComeBack_Click(object sender, EventArgs e)
        {
            back();
        }

        private void Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Input1.Text))
            {
                Input1.Focus();
            }
        }

        private void Input(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Name == "Input1")
                {
                    Value1 = Input1.Text;
                    Input2.Focus();
                }
                else if (textBox.Name == "Input2")
                {
                    Value2 = Input2.Text;
                    CheckNum();
                }
            }
        }

        private void CheckNum()
        {
            try
            {
                if (Value1.Equals(Value2))
                {
                    ShowTips(Value1 + "    " + "PASS", Color.LightGreen);
                    Input1.Clear();
                    Input2.Clear();
                    Input1.Focus();
                }
                else
                {
                    ShowTips(Value1 + "    " + "NG", Color.Red);
                    Input1.Clear();
                    Input2.Clear();
                    Input1.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowTips(ex.Message, Color.Red);
                Input1.Clear();
                Input2.Clear();
                Input1.Focus();
            }

        }

        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="Info">输出提示信息</param>
        public void ShowTips(string Info, Color color)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                this.ResultTips.Invoke(new Action(() =>
                {
                    ResultTips.Text = Info;
                    ResultTips.BackColor = color;
                }));
            });

        }
    }
}
