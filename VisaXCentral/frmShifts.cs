using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace VisaXCentral
{
    public partial class frmShifts : Form
    {
        VisaXCenteralEntities ctx = new VisaXCenteralEntities("ASAWARI");
        
        public frmShifts()
        {
            InitializeComponent();
        }

        private void frmShifts_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpTo.Value.AddMonths(-1);
            refreshGrid();
        }

        private void refreshGrid()
        {
            dgvShifts.DataSource = (from s in 
                                    where s.Date >= dtpFrom.Value.Date && s.Date <= dtpTo.Value
                                    select new
                                    {
                                        s.ID,
                                        s.Date,
                                        s.ShiftNum,
                                        s.User.RealName,
                                        s.Description,
                                        s.Requests.Count,
                                        Sent = s.Sent ? "✓" : "✗"
                                    }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void dgvPassengers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            button1.Enabled = btnList.Enabled = dgvShifts.Rows.Count != 0;
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            button1.Enabled = btnList.Enabled = dgvShifts.Rows.Count != 0;
        }

        public void rowColor()
        {
            for (int i = 0; i < dgvShifts.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvShifts.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void dgvShifts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvShifts.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            rowColor();
        }

        //private void dgvShifts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    btnList_Click(null, null);
        //}
    }
    public partial class VisaXCenteralEntities:DbContext
    {
        public VisaXCenteralEntities(string user, string pwd)
            : base("name=VisaXCenterEntities")
        {
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, pwd);
        }

        public VisaXCenteralEntities(string user)
             : base("name=VisaXCenterEntities")
        {
            if (user == "ASAWARI")
                Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, "3Pg^gf81");
        }
    }

}
