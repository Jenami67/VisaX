namespace VisaX
{
    partial class frmAddPassenger
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassportNum = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtBornDate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIssueDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBornDate = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(219, 31);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(177, 27);
            this.txtFullName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "شماره پاسپورت";
            // 
            // txtPassportNum
            // 
            this.txtPassportNum.Location = new System.Drawing.Point(18, 31);
            this.txtPassportNum.Mask = "00000000";
            this.txtPassportNum.Name = "txtPassportNum";
            this.txtPassportNum.Size = new System.Drawing.Size(119, 27);
            this.txtPassportNum.TabIndex = 0;
            this.txtPassportNum.TextChanged += new System.EventHandler(this.txtPassportNum_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "جنسیت";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "مرد",
            "زن"});
            this.cmbGender.Location = new System.Drawing.Point(419, 31);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 27);
            this.cmbGender.TabIndex = 2;
            // 
            // txtBornDate
            // 
            this.txtBornDate.Location = new System.Drawing.Point(18, 101);
            this.txtBornDate.Mask = "00/00/0000";
            this.txtBornDate.Name = "txtBornDate";
            this.txtBornDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBornDate.Size = new System.Drawing.Size(119, 27);
            this.txtBornDate.TabIndex = 3;
            this.txtBornDate.ValidatingType = typeof(System.DateTime);
            this.txtBornDate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtBornDate_TypeValidationCompleted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "تاریخ تولد";
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Location = new System.Drawing.Point(219, 101);
            this.txtIssueDate.Mask = "00/00/0000";
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIssueDate.Size = new System.Drawing.Size(119, 27);
            this.txtIssueDate.TabIndex = 4;
            this.txtIssueDate.ValidatingType = typeof(System.DateTime);
            this.txtIssueDate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtIssueDate_TypeValidationCompleted);
            this.txtIssueDate.Leave += new System.EventHandler(this.txtIssueDate_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(110, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = " صدور پاسپورت";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(18, 167);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(119, 42);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "ثبت";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Location = new System.Drawing.Point(419, 101);
            this.txtExpiryDate.Mask = "00/00/0000";
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExpiryDate.Size = new System.Drawing.Size(119, 27);
            this.txtExpiryDate.TabIndex = 5;
            this.txtExpiryDate.ValidatingType = typeof(System.DateTime);
            this.txtExpiryDate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtExpiryDate_TypeValidationCompleted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "انقضاء پاسپورت";
            // 
            // lblBornDate
            // 
            this.lblBornDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBornDate.AutoSize = true;
            this.lblBornDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBornDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBornDate.Location = new System.Drawing.Point(12, 137);
            this.lblBornDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBornDate.Name = "lblBornDate";
            this.lblBornDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBornDate.Size = new System.Drawing.Size(0, 14);
            this.lblBornDate.TabIndex = 16;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIssueDate.Location = new System.Drawing.Point(210, 137);
            this.lblIssueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIssueDate.Size = new System.Drawing.Size(0, 14);
            this.lblIssueDate.TabIndex = 17;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblExpiryDate.Location = new System.Drawing.Point(410, 137);
            this.lblExpiryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExpiryDate.Size = new System.Drawing.Size(0, 14);
            this.lblExpiryDate.TabIndex = 18;
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            this.erp.RightToLeft = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(164, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 42);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 228);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // frmAddPassenger
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 250);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.lblBornDate);
            this.Controls.Add(this.txtExpiryDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBornDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtPassportNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddPassenger";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.Text = "افزودن متقاضی";
            this.Load += new System.EventHandler(this.frmAddPassenger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtPassportNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.MaskedTextBox txtBornDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtIssueDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.MaskedTextBox txtExpiryDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBornDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.ErrorProvider erp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMsg;
    }
}