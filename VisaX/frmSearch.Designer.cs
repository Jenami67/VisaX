namespace VisaXCentral
{
    partial class frmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPassengers = new System.Windows.Forms.DataGridView();
            this.colPassengerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassportNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShiftDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShiftNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBornDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassengers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPassengers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 505);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvPassengers
            // 
            this.dgvPassengers.AllowUserToAddRows = false;
            this.dgvPassengers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            this.dgvPassengers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPassengers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPassengers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassengers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPassengerID,
            this.colRequestID,
            this.colID,
            this.colPassportNum,
            this.colFullName,
            this.colShiftDate,
            this.colShiftNum,
            this.colBornDate,
            this.colIssueDate,
            this.colExpiryDate});
            this.dgvPassengers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPassengers.Location = new System.Drawing.Point(3, 59);
            this.dgvPassengers.Name = "dgvPassengers";
            this.dgvPassengers.ReadOnly = true;
            this.dgvPassengers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassengers.Size = new System.Drawing.Size(946, 373);
            this.dgvPassengers.TabIndex = 0;
            this.dgvPassengers.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPassengers_RowPostPaint);
            // 
            // colPassengerID
            // 
            this.colPassengerID.DataPropertyName = "PassengerID";
            this.colPassengerID.HeaderText = "PassengerID";
            this.colPassengerID.Name = "colPassengerID";
            this.colPassengerID.ReadOnly = true;
            this.colPassengerID.Visible = false;
            // 
            // colRequestID
            // 
            this.colRequestID.DataPropertyName = "ID";
            this.colRequestID.HeaderText = "RequestID";
            this.colRequestID.Name = "colRequestID";
            this.colRequestID.ReadOnly = true;
            this.colRequestID.Visible = false;
            // 
            // colID
            // 
            this.colID.FillWeight = 33F;
            this.colID.HeaderText = "ردیف";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colPassportNum
            // 
            this.colPassportNum.DataPropertyName = "PassportNum";
            this.colPassportNum.FillWeight = 73F;
            this.colPassportNum.HeaderText = "شماره پاسپورت";
            this.colPassportNum.Name = "colPassportNum";
            this.colPassportNum.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.FillWeight = 85.38796F;
            this.colFullName.HeaderText = "نام";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colShiftDate
            // 
            this.colShiftDate.DataPropertyName = "Date";
            this.colShiftDate.FillWeight = 85.38796F;
            this.colShiftDate.HeaderText = "تاریخ ثبت";
            this.colShiftDate.Name = "colShiftDate";
            this.colShiftDate.ReadOnly = true;
            // 
            // colShiftNum
            // 
            this.colShiftNum.DataPropertyName = "ShiftNum";
            this.colShiftNum.FillWeight = 33F;
            this.colShiftNum.HeaderText = "شیفت";
            this.colShiftNum.Name = "colShiftNum";
            this.colShiftNum.ReadOnly = true;
            // 
            // colBornDate
            // 
            this.colBornDate.DataPropertyName = "BornDate";
            this.colBornDate.FillWeight = 85.38796F;
            this.colBornDate.HeaderText = "ت.تولد";
            this.colBornDate.Name = "colBornDate";
            this.colBornDate.ReadOnly = true;
            // 
            // colIssueDate
            // 
            this.colIssueDate.DataPropertyName = "IssueDate";
            this.colIssueDate.FillWeight = 85.38796F;
            this.colIssueDate.HeaderText = "صدور پاسپورت";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.DataPropertyName = "ExpiryDate";
            this.colExpiryDate.FillWeight = 85.38796F;
            this.colExpiryDate.HeaderText = "انقضاء پاسپورت";
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.btnExportPDF);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 64);
            this.panel1.TabIndex = 16;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Enabled = false;
            this.btnHistory.Location = new System.Drawing.Point(43, 9);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(142, 45);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "سابقه";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Visible = false;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPDF.Enabled = false;
            this.btnExportPDF.Location = new System.Drawing.Point(342, 9);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(142, 45);
            this.btnExportPDF.TabIndex = 4;
            this.btnExportPDF.Text = "تولید pdf";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Visible = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Location = new System.Drawing.Point(193, 9);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(142, 45);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "تولید اکسل";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(492, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 45);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(642, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(142, 45);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(792, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(142, 45);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 50);
            this.panel2.TabIndex = 17;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.CustomFormat = "yyyy/MM/dd";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(576, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(121, 21);
            this.dtpTo.TabIndex = 9;
            this.dtpTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.CustomFormat = "yyyy/MM/dd";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(764, 13);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(121, 21);
            this.dtpFrom.TabIndex = 8;
            this.dtpFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(703, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "تا تاریخ:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(891, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "از تاریخ:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(273, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = ">>>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "جستجو";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(354, 16);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(159, 21);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 505);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.Text = "جستجو";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassengers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPassengers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassengerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassportNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShiftDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShiftNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBornDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiryDate;
    }
}