namespace 工具集合
{
    partial class TestForm3
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ComeBack = new System.Windows.Forms.Button();
            this.TestName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ExcelPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarTenderPath = new System.Windows.Forms.TextBox();
            this.PrinterList = new System.Windows.Forms.ComboBox();
            this.Excel_Button = new System.Windows.Forms.Button();
            this.BarTender_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Test = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FirstCase = new System.Windows.Forms.TextBox();
            this.LastCase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CaseCodePrefix = new System.Windows.Forms.TextBox();
            this.CaseCodeLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CaseNumber = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.TestName.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Controls.Add(this.ComeBack, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TestName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1176, 688);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ComeBack
            // 
            this.ComeBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ComeBack.BackColor = System.Drawing.SystemColors.Control;
            this.ComeBack.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComeBack.Location = new System.Drawing.Point(973, 627);
            this.ComeBack.Name = "ComeBack";
            this.ComeBack.Size = new System.Drawing.Size(200, 53);
            this.ComeBack.TabIndex = 1;
            this.ComeBack.Text = "返回主界面";
            this.ComeBack.UseVisualStyleBackColor = false;
            this.ComeBack.Click += new System.EventHandler(this.ComeBack_Click);
            // 
            // TestName
            // 
            this.TestName.Controls.Add(this.tableLayoutPanel2);
            this.TestName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestName.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestName.Location = new System.Drawing.Point(2, 3);
            this.TestName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TestName.Name = "TestName";
            this.TestName.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TestName.Size = new System.Drawing.Size(1172, 613);
            this.TestName.TabIndex = 2;
            this.TestName.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ExcelPath, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BarTenderPath, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.PrinterList, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.Excel_Button, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BarTender_Button, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.CaseCodePrefix, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.CaseCodeLength, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.CaseNumber, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 49);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1168, 561);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "打印模板";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "打印机";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcelPath
            // 
            this.ExcelPath.BackColor = System.Drawing.SystemColors.Window;
            this.ExcelPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelPath.Location = new System.Drawing.Point(350, 0);
            this.ExcelPath.Margin = new System.Windows.Forms.Padding(0);
            this.ExcelPath.Name = "ExcelPath";
            this.ExcelPath.ReadOnly = true;
            this.ExcelPath.Size = new System.Drawing.Size(584, 53);
            this.ExcelPath.TabIndex = 4;
            this.ExcelPath.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel文件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarTenderPath
            // 
            this.BarTenderPath.BackColor = System.Drawing.SystemColors.Window;
            this.BarTenderPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarTenderPath.Location = new System.Drawing.Point(350, 69);
            this.BarTenderPath.Margin = new System.Windows.Forms.Padding(0);
            this.BarTenderPath.Name = "BarTenderPath";
            this.BarTenderPath.ReadOnly = true;
            this.BarTenderPath.Size = new System.Drawing.Size(584, 53);
            this.BarTenderPath.TabIndex = 5;
            this.BarTenderPath.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // PrinterList
            // 
            this.PrinterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrinterList.FormattingEnabled = true;
            this.PrinterList.Location = new System.Drawing.Point(350, 138);
            this.PrinterList.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterList.Name = "PrinterList";
            this.PrinterList.Size = new System.Drawing.Size(584, 48);
            this.PrinterList.TabIndex = 8;
            this.PrinterList.TextChanged += new System.EventHandler(this.PrinterList_TextChanged);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Location = new System.Drawing.Point(936, 3);
            this.Excel_Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(123, 51);
            this.Excel_Button.TabIndex = 11;
            this.Excel_Button.Text = "选择";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // BarTender_Button
            // 
            this.BarTender_Button.Location = new System.Drawing.Point(936, 72);
            this.BarTender_Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarTender_Button.Name = "BarTender_Button";
            this.BarTender_Button.Size = new System.Drawing.Size(123, 51);
            this.BarTender_Button.TabIndex = 12;
            this.BarTender_Button.Text = "选择";
            this.BarTender_Button.UseVisualStyleBackColor = true;
            this.BarTender_Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.Test, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Start, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(352, 486);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(580, 72);
            this.tableLayoutPanel4.TabIndex = 14;
            // 
            // Test
            // 
            this.Test.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Test.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Test.Location = new System.Drawing.Point(43, 7);
            this.Test.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(245, 58);
            this.Test.TabIndex = 10;
            this.Test.Text = "测试打印";
            this.Test.UseVisualStyleBackColor = false;
            this.Test.Click += new System.EventHandler(this.Test_Click);
            // 
            // Start
            // 
            this.Start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Start.BackColor = System.Drawing.Color.SpringGreen;
            this.Start.Location = new System.Drawing.Point(292, 7);
            this.Start.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(245, 58);
            this.Start.TabIndex = 13;
            this.Start.Text = "开始打印";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.FirstCase, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.LastCase, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(352, 417);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(580, 63);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // FirstCase
            // 
            this.FirstCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstCase.Location = new System.Drawing.Point(0, 0);
            this.FirstCase.Margin = new System.Windows.Forms.Padding(0);
            this.FirstCase.Name = "FirstCase";
            this.FirstCase.Size = new System.Drawing.Size(269, 53);
            this.FirstCase.TabIndex = 0;
            this.FirstCase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstCase.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // LastCase
            // 
            this.LastCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastCase.Location = new System.Drawing.Point(310, 0);
            this.LastCase.Margin = new System.Windows.Forms.Padding(0);
            this.LastCase.Name = "LastCase";
            this.LastCase.Size = new System.Drawing.Size(270, 53);
            this.LastCase.TabIndex = 1;
            this.LastCase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LastCase.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 40);
            this.label5.TabIndex = 2;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 207);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 40);
            this.label6.TabIndex = 15;
            this.label6.Text = "箱号前缀";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 276);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 40);
            this.label7.TabIndex = 16;
            this.label7.Text = "箱号长度";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 414);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "箱号范围";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CaseCodePrefix
            // 
            this.CaseCodePrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaseCodePrefix.Location = new System.Drawing.Point(352, 210);
            this.CaseCodePrefix.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CaseCodePrefix.Name = "CaseCodePrefix";
            this.CaseCodePrefix.Size = new System.Drawing.Size(580, 53);
            this.CaseCodePrefix.TabIndex = 17;
            this.CaseCodePrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CaseCodePrefix.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // CaseCodeLength
            // 
            this.CaseCodeLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaseCodeLength.Location = new System.Drawing.Point(352, 279);
            this.CaseCodeLength.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CaseCodeLength.Name = "CaseCodeLength";
            this.CaseCodeLength.Size = new System.Drawing.Size(580, 53);
            this.CaseCodeLength.TabIndex = 18;
            this.CaseCodeLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CaseCodeLength.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 345);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 40);
            this.label8.TabIndex = 19;
            this.label8.Text = "箱子容量";
            // 
            // CaseNumber
            // 
            this.CaseNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaseNumber.Location = new System.Drawing.Point(352, 348);
            this.CaseNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CaseNumber.Name = "CaseNumber";
            this.CaseNumber.Size = new System.Drawing.Size(580, 53);
            this.CaseNumber.TabIndex = 20;
            this.CaseNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CaseNumber.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // TestForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TestForm3";
            this.Size = new System.Drawing.Size(1176, 688);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TestName.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ComeBack;
        private System.Windows.Forms.GroupBox TestName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ExcelPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BarTenderPath;
        private System.Windows.Forms.ComboBox PrinterList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox FirstCase;
        private System.Windows.Forms.TextBox LastCase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Test;
        private System.Windows.Forms.Button Excel_Button;
        private System.Windows.Forms.Button BarTender_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CaseCodePrefix;
        private System.Windows.Forms.TextBox CaseCodeLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CaseNumber;
    }
}
