namespace 工具集合
{
    partial class TestForm4
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Input = new System.Windows.Forms.TextBox();
            this.Dut = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dutname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.model = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkfields = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Tips = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.filepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Select = new System.Windows.Forms.Button();
            this.SelectNG = new System.Windows.Forms.CheckBox();
            this.ComeBack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TestName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TestName.SuspendLayout();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Input.BackColor = System.Drawing.SystemColors.Window;
            this.Input.Location = new System.Drawing.Point(231, 36);
            this.Input.Margin = new System.Windows.Forms.Padding(0);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(483, 38);
            this.Input.TabIndex = 4;
            this.Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            // 
            // Dut
            // 
            this.Dut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Dut.AutoSize = true;
            this.Dut.Location = new System.Drawing.Point(84, 41);
            this.Dut.Margin = new System.Windows.Forms.Padding(0);
            this.Dut.Name = "Dut";
            this.Dut.Size = new System.Drawing.Size(147, 27);
            this.Dut.TabIndex = 0;
            this.Dut.Text = "扫描字段名";
            this.Dut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Result, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Tips, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1, 33);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(780, 374);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.dutname, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.model, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkfields, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 35);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(778, 29);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // dutname
            // 
            this.dutname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dutname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dutname.Location = new System.Drawing.Point(360, 2);
            this.dutname.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.dutname.Name = "dutname";
            this.dutname.Size = new System.Drawing.Size(157, 26);
            this.dutname.TabIndex = 1;
            this.dutname.TextChanged += new System.EventHandler(this.dutname_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(271, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "扫描字段：";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "机型：";
            // 
            // model
            // 
            this.model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.model.Location = new System.Drawing.Point(101, 2);
            this.model.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(157, 26);
            this.model.TabIndex = 1;
            this.model.TextChanged += new System.EventHandler(this.model_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(529, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "核对字段：";
            // 
            // checkfields
            // 
            this.checkfields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkfields.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkfields.Location = new System.Drawing.Point(620, 2);
            this.checkfields.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkfields.Name = "checkfields";
            this.checkfields.Size = new System.Drawing.Size(156, 26);
            this.checkfields.TabIndex = 3;
            this.checkfields.TextChanged += new System.EventHandler(this.CheckFields_TextChanged);
            // 
            // Result
            // 
            this.Result.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Result.Location = new System.Drawing.Point(301, 74);
            this.Result.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(177, 40);
            this.Result.TabIndex = 7;
            this.Result.Text = "核对结果";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.86231F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.1377F));
            this.tableLayoutPanel5.Controls.Add(this.Input, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.Dut, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 125);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(776, 110);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // Tips
            // 
            this.Tips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Tips.AutoSize = true;
            this.Tips.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tips.Location = new System.Drawing.Point(365, 295);
            this.Tips.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(49, 20);
            this.Tips.TabIndex = 8;
            this.Tips.Text = "提示";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel4.Controls.Add(this.filepath, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Select, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.SelectNG, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(776, 29);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // filepath
            // 
            this.filepath.BackColor = System.Drawing.SystemColors.Window;
            this.filepath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filepath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filepath.Location = new System.Drawing.Point(101, 2);
            this.filepath.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.filepath.Name = "filepath";
            this.filepath.ReadOnly = true;
            this.filepath.Size = new System.Drawing.Size(398, 26);
            this.filepath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Excel文件：";
            // 
            // Select
            // 
            this.Select.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Select.Location = new System.Drawing.Point(502, 2);
            this.Select.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(96, 24);
            this.Select.TabIndex = 4;
            this.Select.Text = "选择";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // SelectNG
            // 
            this.SelectNG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectNG.AutoSize = true;
            this.SelectNG.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectNG.Location = new System.Drawing.Point(602, 4);
            this.SelectNG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SelectNG.Name = "SelectNG";
            this.SelectNG.Size = new System.Drawing.Size(122, 20);
            this.SelectNG.TabIndex = 5;
            this.SelectNG.Text = "筛选对象为NG";
            this.SelectNG.UseVisualStyleBackColor = true;
            // 
            // ComeBack
            // 
            this.ComeBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ComeBack.BackColor = System.Drawing.SystemColors.Control;
            this.ComeBack.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComeBack.Location = new System.Drawing.Point(649, 418);
            this.ComeBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComeBack.Name = "ComeBack";
            this.ComeBack.Size = new System.Drawing.Size(133, 35);
            this.ComeBack.TabIndex = 1;
            this.ComeBack.Text = "返回主界面";
            this.ComeBack.UseVisualStyleBackColor = false;
            this.ComeBack.Click += new System.EventHandler(this.ComeBack_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Controls.Add(this.ComeBack, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TestName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 459);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TestName
            // 
            this.TestName.Controls.Add(this.tableLayoutPanel2);
            this.TestName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestName.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestName.Location = new System.Drawing.Point(1, 2);
            this.TestName.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.TestName.Name = "TestName";
            this.TestName.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.TestName.Size = new System.Drawing.Size(782, 409);
            this.TestName.TabIndex = 2;
            this.TestName.TabStop = false;
            // 
            // TestForm4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "TestForm4";
            this.Size = new System.Drawing.Size(784, 459);
            this.Load += new System.EventHandler(this.TestForm4_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TestName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Label Dut;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ComeBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox TestName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox model;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dutname;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label Tips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox checkfields;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.CheckBox SelectNG;
    }
}
