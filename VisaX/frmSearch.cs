using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaXCentral
{
    public partial class frmSearch : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        public frmSearch()
        {
            InitializeComponent();
        }

        private void getData()
        {
            dgvPassengers.DataSource = (from r in ctx.Requests
                                        where r.Shift.Date >= dtpFrom.Value.Date && r.Shift.Date <= dtpTo.Value
                                          && (r.Passenger.FullName.Contains(txtFilter.Text)
                                             || r.Passenger.PassportNum.Contains(txtFilter.Text))
                                        select new
                                        {
                                            r.ID,
                                            r.PassengerID,
                                            r.Shift.Date,
                                            r.Shift.ShiftNum,
                                            r.Passenger.FullName,
                                            r.Passenger.PassportNum,
                                            r.Passenger.BornDate,
                                            r.Passenger.IssueDate,
                                            r.Passenger.ExpiryDate
                                        }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getData();
        }
        private void dgvPassengers_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPassengers.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            //paint rows odd and even
            for (int i = 0; i < dgvPassengers.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvPassengers.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
        }
    }
}
