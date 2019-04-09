using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmHistory : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        Passenger passenger;
        public frmHistory(Passenger passenger)
        {
            InitializeComponent();
            this.passenger = passenger;
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "سابقه درخواست های ویزای " + this.passenger.FullName;
            dgvRequests.DataSource = (from r in ctx.Requests
                                      where r.PassengerID == this.passenger.ID
                                      select new
                                      {
                                          r.User.RealName,
                                          r.ID,
                                          r.Shift.Date,
                                          r.Shift.ShiftNum
                                      }).ToList();

        }

        private void dgvRequests_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvRequests.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
