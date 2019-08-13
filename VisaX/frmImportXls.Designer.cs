namespace VisaX
{
    partial class frmImportXls
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(19, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 45);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.Location = new System.Drawing.Point(224, 66);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(135, 45);
            this.btnExportPDF.TabIndex = 20;
            this.btnExportPDF.Text = "&وارد سازی متقاضیان";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnImportPDF_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "پوشه فایل های اکسل را انتخاب کنید:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(19, 26);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 23);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VisaX.Properties.Settings.Default, "XlsPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtFileName.Location = new System.Drawing.Point(55, 27);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFileName.Size = new System.Drawing.Size(304, 21);
            this.txtFileName.TabIndex = 17;
            this.txtFileName.Text = global::VisaX.Properties.Settings.Default.XlsPath;
            // 
            // bgw
            // 
            this.bgw.WorkerReportsProgress = true;
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(55, 27);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(304, 21);
            this.pb.TabIndex = 22;
            this.pb.Visible = false;
            // 
            // frmImportXls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(374, 123);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportXls";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "وارد سازی متقاضیان از اکسل";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.ProgressBar pb;
    }
}