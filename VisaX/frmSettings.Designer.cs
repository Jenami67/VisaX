namespace VisaX
{
    partial class frmSettings
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
            this.fbdPdf = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblBackup = new System.Windows.Forms.LinkLabel();
            this.lblRestore = new System.Windows.Forms.LinkLabel();
            this.llbImportXls = new System.Windows.Forms.LinkLabel();
            this.lblSetConnection = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtExportDestinationPath = new System.Windows.Forms.TextBox();
            this.chkDatesDisabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(294, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(11, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 45);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblBackup
            // 
            this.lblBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackup.AutoSize = true;
            this.lblBackup.LinkArea = new System.Windows.Forms.LinkArea(0, 11);
            this.lblBackup.Location = new System.Drawing.Point(258, 94);
            this.lblBackup.Margin = new System.Windows.Forms.Padding(0);
            this.lblBackup.Name = "lblBackup";
            this.lblBackup.Size = new System.Drawing.Size(80, 19);
            this.lblBackup.TabIndex = 18;
            this.lblBackup.TabStop = true;
            this.lblBackup.Text = "پشیبان گیری |";
            this.lblBackup.UseCompatibleTextRendering = true;
            this.lblBackup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBackup_LinkClicked);
            // 
            // lblRestore
            // 
            this.lblRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestore.AutoSize = true;
            this.lblRestore.LinkArea = new System.Windows.Forms.LinkArea(0, 7);
            this.lblRestore.Location = new System.Drawing.Point(335, 94);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(48, 19);
            this.lblRestore.TabIndex = 19;
            this.lblRestore.TabStop = true;
            this.lblRestore.Text = "بازیابی |";
            this.lblRestore.UseCompatibleTextRendering = true;
            this.lblRestore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRestore_LinkClicked);
            // 
            // llbImportXls
            // 
            this.llbImportXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llbImportXls.AutoSize = true;
            this.llbImportXls.LinkArea = new System.Windows.Forms.LinkArea(0, 14);
            this.llbImportXls.Location = new System.Drawing.Point(158, 94);
            this.llbImportXls.Name = "llbImportXls";
            this.llbImportXls.Size = new System.Drawing.Size(101, 19);
            this.llbImportXls.TabIndex = 20;
            this.llbImportXls.TabStop = true;
            this.llbImportXls.Text = "وارد سازی اکسل |";
            this.llbImportXls.UseCompatibleTextRendering = true;
            this.llbImportXls.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbImportXls_LinkClicked);
            // 
            // lblSetConnection
            // 
            this.lblSetConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetConnection.AutoSize = true;
            this.lblSetConnection.Location = new System.Drawing.Point(24, 94);
            this.lblSetConnection.Name = "lblSetConnection";
            this.lblSetConnection.Size = new System.Drawing.Size(134, 14);
            this.lblSetConnection.TabIndex = 21;
            this.lblSetConnection.TabStop = true;
            this.lblSetConnection.Text = "تنظیم اتصال به پایگاه داده";
            this.lblSetConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetConnection_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "پوشه فایل های اکسل را انتخاب کنید:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(24, 57);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 23);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtExportDestinationPath
            // 
            this.txtExportDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportDestinationPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VisaX.Properties.Settings.Default, "ExportDestinationPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtExportDestinationPath.Location = new System.Drawing.Point(60, 58);
            this.txtExportDestinationPath.Name = "txtExportDestinationPath";
            this.txtExportDestinationPath.ReadOnly = true;
            this.txtExportDestinationPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExportDestinationPath.Size = new System.Drawing.Size(304, 22);
            this.txtExportDestinationPath.TabIndex = 22;
            this.txtExportDestinationPath.Text = global::VisaX.Properties.Settings.Default.ExportDestinationPath;
            // 
            // chkDatesDisabled
            // 
            this.chkDatesDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDatesDisabled.AutoSize = true;
            this.chkDatesDisabled.Checked = global::VisaX.Properties.Settings.Default.DatesDisabled;
            this.chkDatesDisabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VisaX.Properties.Settings.Default, "DatesDisabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkDatesDisabled.Location = new System.Drawing.Point(211, 13);
            this.chkDatesDisabled.Name = "chkDatesDisabled";
            this.chkDatesDisabled.Size = new System.Drawing.Size(172, 18);
            this.chkDatesDisabled.TabIndex = 12;
            this.chkDatesDisabled.Text = "فیلدهای تاریخ غیرفعال شوند.";
            this.chkDatesDisabled.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(410, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtExportDestinationPath);
            this.Controls.Add(this.lblSetConnection);
            this.Controls.Add(this.lblBackup);
            this.Controls.Add(this.lblRestore);
            this.Controls.Add(this.llbImportXls);
            this.Controls.Add(this.chkDatesDisabled);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.Text = "تنظیمات";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog fbdPdf;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkDatesDisabled;
        private System.Windows.Forms.LinkLabel lblBackup;
        private System.Windows.Forms.LinkLabel lblRestore;
        private System.Windows.Forms.LinkLabel llbImportXls;
        private System.Windows.Forms.LinkLabel lblSetConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtExportDestinationPath;
    }
}