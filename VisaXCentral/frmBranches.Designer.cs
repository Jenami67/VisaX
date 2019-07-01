namespace VisaXCentral
{
    partial class frmBranches
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvBranches = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbGeneratePDF = new System.Windows.Forms.LinkLabel();
            this.btnNewBranch = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnShowShifts = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvBranches, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 367);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvBranches
            // 
            this.dgvBranches.AllowUserToAddRows = false;
            this.dgvBranches.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            this.dgvBranches.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBranches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colID,
            this.colCount,
            this.colUser,
            this.colLastSeen,
            this.colEnabled});
            this.dgvBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBranches.Location = new System.Drawing.Point(3, 3);
            this.dgvBranches.Name = "dgvBranches";
            this.dgvBranches.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBranches.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBranches.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBranches.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBranches.Size = new System.Drawing.Size(676, 297);
            this.dgvBranches.TabIndex = 3;
            this.dgvBranches.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBranches_RowPostPaint);
            this.dgvBranches.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvBranches_RowsAdded);
            this.dgvBranches.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvBranches_RowsRemoved);
            this.dgvBranches.SelectionChanged += new System.EventHandler(this.dgvBranches_SelectionChanged);
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
            // colCount
            // 
            this.colCount.DataPropertyName = "Count";
            this.colCount.HeaderText = "شیفت ها";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "RealName";
            this.colUser.HeaderText = "نام کاربری";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colLastSeen
            // 
            this.colLastSeen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastSeen.DataPropertyName = "LastSeen";
            this.colLastSeen.HeaderText = "آخرین اتصال";
            this.colLastSeen.Name = "colLastSeen";
            this.colLastSeen.ReadOnly = true;
            // 
            // colEnabled
            // 
            this.colEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "فعال";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.Width = 53;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llbGeneratePDF);
            this.panel1.Controls.Add(this.btnNewBranch);
            this.panel1.Controls.Add(this.btnChangePass);
            this.panel1.Controls.Add(this.btnDisable);
            this.panel1.Controls.Add(this.btnShowShifts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 58);
            this.panel1.TabIndex = 4;
            // 
            // llbGeneratePDF
            // 
            this.llbGeneratePDF.AutoSize = true;
            this.llbGeneratePDF.Location = new System.Drawing.Point(10, 38);
            this.llbGeneratePDF.Name = "llbGeneratePDF";
            this.llbGeneratePDF.Size = new System.Drawing.Size(50, 13);
            this.llbGeneratePDF.TabIndex = 16;
            this.llbGeneratePDF.TabStop = true;
            this.llbGeneratePDF.Text = "&تولید PDF";
            this.llbGeneratePDF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbGeneratePDF_LinkClicked);
            // 
            // btnNewBranch
            // 
            this.btnNewBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewBranch.Location = new System.Drawing.Point(109, 7);
            this.btnNewBranch.Name = "btnNewBranch";
            this.btnNewBranch.Size = new System.Drawing.Size(135, 45);
            this.btnNewBranch.TabIndex = 15;
            this.btnNewBranch.Text = "&شعبه جدید";
            this.btnNewBranch.UseVisualStyleBackColor = true;
            this.btnNewBranch.Click += new System.EventHandler(this.btnNewBranch_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePass.Enabled = false;
            this.btnChangePass.Location = new System.Drawing.Point(391, 7);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(135, 45);
            this.btnChangePass.TabIndex = 14;
            this.btnChangePass.Text = "&تغییر رمز";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisable.Location = new System.Drawing.Point(250, 7);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(135, 45);
            this.btnDisable.TabIndex = 13;
            this.btnDisable.Text = "&غیرفعال کردن";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnShowShifts
            // 
            this.btnShowShifts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowShifts.Enabled = false;
            this.btnShowShifts.Location = new System.Drawing.Point(532, 7);
            this.btnShowShifts.Name = "btnShowShifts";
            this.btnShowShifts.Size = new System.Drawing.Size(135, 45);
            this.btnShowShifts.TabIndex = 12;
            this.btnShowShifts.Text = "&نمایش شیفت ها";
            this.btnShowShifts.UseVisualStyleBackColor = true;
            this.btnShowShifts.Click += new System.EventHandler(this.btnShowShifts_Click);
            // 
            // frmBranches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 367);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmBranches";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لیست شعب ...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBranches_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvBranches;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnShowShifts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnabled;
        private System.Windows.Forms.Button btnNewBranch;
        private System.Windows.Forms.LinkLabel llbGeneratePDF;
    }
}

