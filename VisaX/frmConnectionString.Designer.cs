namespace VisaX
{
    partial class frmConnectionString
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDataSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(204, 152);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(120, 36);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "تست اتصال";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(13, 152);
            this.btnSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(120, 36);
            this.btnSet.TabIndex = 12;
            this.btnSet.Text = "تنظیم اتصال";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Items.AddRange(new object[] {
            "پایگاه داده محلی",
            "SQL Server"});
            this.cmbConnectionType.Location = new System.Drawing.Point(15, 25);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbConnectionType.Size = new System.Drawing.Size(309, 21);
            this.cmbConnectionType.TabIndex = 11;
            this.cmbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cmbConnectionType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "نوع اتصال:";
            // 
            // cmbDataSource
            // 
            this.cmbDataSource.FormattingEnabled = true;
            this.cmbDataSource.Items.AddRange(new object[] {
            "."});
            this.cmbDataSource.Location = new System.Drawing.Point(15, 68);
            this.cmbDataSource.Name = "cmbDataSource";
            this.cmbDataSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDataSource.Size = new System.Drawing.Size(309, 21);
            this.cmbDataSource.TabIndex = 16;
            this.cmbDataSource.Text = ".";
            this.cmbDataSource.TextChanged += new System.EventHandler(this.cmbDataSource_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "آدرس و نام پایگاه داده:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.BackColor = System.Drawing.SystemColors.Control;
            this.txtConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConnectionString.Location = new System.Drawing.Point(15, 95);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ReadOnly = true;
            this.txtConnectionString.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConnectionString.Size = new System.Drawing.Size(309, 51);
            this.txtConnectionString.TabIndex = 17;
            // 
            // frmConnectionString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 200);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.cmbDataSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cmbConnectionType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionString";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.Text = "تنظیم اتصال به پایگاه داده ";
            this.Load += new System.EventHandler(this.frmConnectionString_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConnectionString_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.ComboBox cmbConnectionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDataSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionString;
    }
}