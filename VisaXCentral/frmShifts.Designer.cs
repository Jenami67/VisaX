namespace VisaXCentral
{
    partial class frmShifts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvShifts = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassportNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbUser = new System.Windows.Forms.LinkLabel();
            this.btnList = new System.Windows.Forms.Button();
            this.llbSettings = new System.Windows.Forms.LinkLabel();
            this.btnSearchRequest = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.llbAbout = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvShifts, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvShifts
            // 
            this.dgvShifts.AllowUserToAddRows = false;
            this.dgvShifts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(2);
            this.dgvShifts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvShifts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShifts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShifts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colID,
            this.colPassportNum,
            this.colFullName,
            this.colUser,
            this.colDescription,
            this.colCount,
            this.colSent});
            this.dgvShifts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShifts.Location = new System.Drawing.Point(3, 60);
            this.dgvShifts.Name = "dgvShifts";
            this.dgvShifts.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShifts.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvShifts.RowHeadersWidth = 20;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvShifts.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvShifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShifts.Size = new System.Drawing.Size(794, 335);
            this.dgvShifts.TabIndex = 2;
            this.dgvShifts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShifts_CellDoubleClick);
            this.dgvShifts.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvShifts_RowPostPaint);
            this.dgvShifts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPassengers_RowsAdded);
            this.dgvShifts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPassengers_RowsRemoved);
            // 
            // colNumber
            // 
            this.colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colNumber.HeaderText = "ردیف";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Width = 54;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.FillWeight = 50F;
            this.colID.HeaderText = "کد";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colPassportNum
            // 
            this.colPassportNum.DataPropertyName = "Date";
            this.colPassportNum.HeaderText = "تاریخ";
            this.colPassportNum.Name = "colPassportNum";
            this.colPassportNum.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "ShiftNum";
            this.colFullName.HeaderText = "شیفت";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "RealName";
            this.colUser.HeaderText = "کاربر";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "توضیحات";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colCount
            // 
            this.colCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colCount.DataPropertyName = "Count";
            this.colCount.HeaderText = "تعداد متقاضیان";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colSent
            // 
            this.colSent.DataPropertyName = "Sent";
            this.colSent.HeaderText = "وضعیت ارسال";
            this.colSent.Name = "colSent";
            this.colSent.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Controls.Add(this.btnSearchRequest);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 61);
            this.panel1.TabIndex = 0;
            // 
            // llbUser
            // 
            this.llbUser.AutoSize = true;
            this.llbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llbUser.LinkArea = new System.Windows.Forms.LinkArea(0, 6);
            this.llbUser.Location = new System.Drawing.Point(172, 0);
            this.llbUser.Name = "llbUser";
            this.llbUser.Size = new System.Drawing.Size(33, 18);
            this.llbUser.TabIndex = 12;
            this.llbUser.TabStop = true;
            this.llbUser.Text = "کاربر |";
            this.llbUser.UseCompatibleTextRendering = true;
            this.llbUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbUser_LinkClicked);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Enabled = false;
            this.btnList.Location = new System.Drawing.Point(519, 7);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(130, 45);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "متقاضیان";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // llbSettings
            // 
            this.llbSettings.AutoSize = true;
            this.llbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llbSettings.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.llbSettings.Location = new System.Drawing.Point(115, 0);
            this.llbSettings.Name = "llbSettings";
            this.llbSettings.Size = new System.Drawing.Size(51, 18);
            this.llbSettings.TabIndex = 10;
            this.llbSettings.TabStop = true;
            this.llbSettings.Text = "تنظیمات |";
            this.llbSettings.UseCompatibleTextRendering = true;
            this.llbSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSettings_LinkClicked);
            // 
            // btnSearchRequest
            // 
            this.btnSearchRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchRequest.Location = new System.Drawing.Point(247, 7);
            this.btnSearchRequest.Name = "btnSearchRequest";
            this.btnSearchRequest.Size = new System.Drawing.Size(130, 45);
            this.btnSearchRequest.TabIndex = 9;
            this.btnSearchRequest.Text = "جستجو";
            this.btnSearchRequest.UseVisualStyleBackColor = true;
            this.btnSearchRequest.Click += new System.EventHandler(this.btnSearchRequest_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(383, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 45);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(655, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(130, 45);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "شیفت جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // llbAbout
            // 
            this.llbAbout.AutoSize = true;
            this.llbAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llbAbout.Location = new System.Drawing.Point(3, 0);
            this.llbAbout.Name = "llbAbout";
            this.llbAbout.Size = new System.Drawing.Size(106, 18);
            this.llbAbout.TabIndex = 13;
            this.llbAbout.TabStop = true;
            this.llbAbout.Text = "ارسال شیفت ها (55)";
            this.llbAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAbout_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 51);
            this.panel2.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.CustomFormat = "yyyy/MM/dd";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(431, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(121, 21);
            this.dtpTo.TabIndex = 9;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.CustomFormat = "yyyy/MM/dd";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(620, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(121, 21);
            this.dtpFrom.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "تا تاریخ:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(344, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = ">>>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(743, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "از تاریخ:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.llbAbout, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.llbUser, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.llbSettings, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 37);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 18);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // frmShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(816, 503);
            this.Name = "frmShifts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "شرکه زهره البصره ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShifts_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.LinkLabel llbSettings;
        private System.Windows.Forms.Button btnSearchRequest;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShifts;
        private System.Windows.Forms.LinkLabel llbUser;
        private System.Windows.Forms.LinkLabel llbAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassportNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}