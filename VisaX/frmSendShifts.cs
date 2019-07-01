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
    public partial class frmSendShifts : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        VisaXCenteralEntities ctxCentral = new VisaXCenteralEntities("ASAWARI");

        public frmSendShifts()
        {
            InitializeComponent();
        }

        private void SendShifts_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void refreshGrid()
        {
            dgvShifts.DataSource = (from s in ctx.Shifts
                                    where !s.Sent
                                    select new
                                    {
                                        s.ID,
                                        s.Date,
                                        s.ShiftNum,
                                        s.User.RealName,
                                        s.Description,
                                        s.Requests.Count
                                    }).ToList();
        }

        private void btnSendShifts_Click(object sender, EventArgs e)
        {
            RemoteUser remoteUserID = 
            List<RemoteShift> ls = (from s in ctx.Shifts
                                    where !s.Sent
                                    select new RemoteShift
                                    {
                                        Date = s.Date,
                                        ShiftNum = s.ShiftNum,
                                        RemoteUserID = 2,
                                        Description = s.Description,
                                        RemoteRequests = (from r in s.Requests
                                                          select new RemoteRequest
                                                          {
                                                              FullName = r.Passenger.FullName,
                                                              Gender = r.Passenger.Gender,
                                                              PassportNum = r.Passenger.PassportNum,
                                                              BornDate = r.Passenger.BornDate,
                                                              IssueDate = r.Passenger.IssueDate,
                                                              ExpiryDate = r.Passenger.ExpiryDate
                                                          }).ToList<RemoteRequest>()
                                    }).ToList<RemoteShift>();
            ctxCentral.RemoteShifts.AddRange(ls);
            
            try
            {
                ctxCentral.SaveChanges();
            }
            catch (System.Data.Entity.Core.EntityException ex)
            {
                if (ex.InnerException.HResult == -2146232060)
                    MessageBox.Show("اتصال به پایگاه داده برقرار نشد. لطفا از اتصال به اینترنت مطمئن شوید...\n" + ex.ToString());
                ctxCentral = new VisaXCenteralEntities("ASAWARI");
                return;
            }

            foreach (var shift in ctx.Shifts.Select(s => s).Where(ss => ss.Sent == false))
                shift.Sent = true;
            ctx.SaveChanges();

            MessageBox.Show("شیفت ها با موفقیت به مرکز ارسال شدند.", "ارسال شیفت ها", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            refreshGrid();
        }

        private void dgvShifts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
             btnSendShifts.Enabled = dgvShifts.Rows.Count > 0;
        }

        private void dgvShifts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvShifts_RowsAdded(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
    }
}
