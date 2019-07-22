namespace VisaXCentral
{
    partial class frmMessages
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvShifts = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelMsg = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewMsg = new System.Windows.Forms.Button();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassportNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvShifts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 347);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvShifts
            // 
            this.dgvShifts.AllowUserToAddRows = false;
            this.dgvShifts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            this.dgvShifts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvShifts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShifts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShifts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colID,
            this.colFullName,
            this.colPassportNum,
            this.colUser,
            this.colDescription});
            this.dgvShifts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShifts.Location = new System.Drawing.Point(3, 3);
            this.dgvShifts.Name = "dgvShifts";
            this.dgvShifts.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShifts.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvShifts.RowHeadersWidth = 20;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvShifts.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvShifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShifts.Size = new System.Drawing.Size(617, 277);
            this.dgvShifts.TabIndex = 3;
            this.dgvShifts.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvShifts_RowPostPaint);
            this.dgvShifts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvShifts_RowsAdded);
            this.dgvShifts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvShifts_RowsRemoved);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelMsg);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNewMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 58);
            this.panel1.TabIndex = 4;
            // 
            // btnDelMsg
            // 
            this.btnDelMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMsg.Enabled = false;
            this.btnDelMsg.Location = new System.Drawing.Point(312, 7);
            this.btnDelMsg.Name = "btnDelMsg";
            this.btnDelMsg.Size = new System.Drawing.Size(145, 45);
            this.btnDelMsg.TabIndex = 14;
            this.btnDelMsg.Text = "حذف پیام";
            this.btnDelMsg.UseVisualStyleBackColor = true;
            this.btnDelMsg.Click += new System.EventHandler(this.btnDelMsg_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(9, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 45);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewMsg
            // 
            this.btnNewMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewMsg.Location = new System.Drawing.Point(463, 7);
            this.btnNewMsg.Name = "btnNewMsg";
            this.btnNewMsg.Size = new System.Drawing.Size(145, 45);
            this.btnNewMsg.TabIndex = 12;
            this.btnNewMsg.Text = "ثبت پیام جدید";
            this.btnNewMsg.UseVisualStyleBackColor = true;
            this.btnNewMsg.Click += new System.EventHandler(this.btnNewMsg_Click);
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
            // colFullName
            // 
            this.colFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colFullName.DataPropertyName = "Seen";
            this.colFullName.HeaderText = "خوانده شده";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 86;
            // 
            // colPassportNum
            // 
            this.colPassportNum.DataPropertyName = "RegTime";
            this.colPassportNum.FillWeight = 71.28215F;
            this.colPassportNum.HeaderText = "تاریخ";
            this.colPassportNum.Name = "colPassportNum";
            this.colPassportNum.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "Title";
            this.colUser.FillWeight = 71.28215F;
            this.colUser.HeaderText = "عنوان";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Text";
            this.colDescription.FillWeight = 71.28215F;
            this.colDescription.HeaderText = "متن";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // frmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 347);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "frmMessages";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پیام های شعبه منتخب";
            this.Load += new System.EventHandler(this.SendShifts_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShifts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvShifts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewMsg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassportNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}