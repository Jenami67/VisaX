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
    public partial class frmShift : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        public frmShift()
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
            dgvShifts.DataSource = (from s in ctx.Shifts
                                    where s.Date >= dtpFrom.Value.Date && s.Date <= dtpTo.Value
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            byte max = ctx.Shifts.Where(s => s.Date == DateTime.Today).Select(s => s.ShiftNum).DefaultIfEmpty<byte>(0).Max();
            //(from s in ctx.Shifts where s.Date == DateTime.Today select s.ShiftNum).ma
            max++;
            string message = string.Format("تولید شیفت شماره {0} به تاریخ {1} توسط {2}؟", max, DateTime.Today.ToShortDateString(), Properties.Settings.Default.User.RealName);
            frmNewShift frmNewShift = new frmNewShift(message);
            if (frmNewShift.ShowDialog() == DialogResult.Yes)
            {
                ctx.Shifts.Add(new Shift
                {
                    Date = DateTime.Today,
                    UserID = Properties.Settings.Default.User.ID,
                    ShiftNum = max,
                    Description = frmNewShift.txtDescription.Text
                });
                ctx.SaveChanges();
                refreshGrid();

                dgvShifts.ClearSelection();
                dgvShifts.Rows[dgvShifts.RowCount - 1].Selected = true;
            }//if
        }//btnNew

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)dgvShifts.SelectedRows[0].Cells[0].Value;
            Shift shift = (from s in ctx.Shifts where s.ID == id select s).First();
            if (MessageBox.Show("آیا مایل به حذف این شیفت هستید؟", "حذف شیفت", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctx.Shifts.Remove(shift);
                try
                {
                    ctx.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    MessageBox.Show("امکان حذف شیفتی که متقاضی در آن ثبت شده وجود ندارد.\n" + ex.ToString());
                    ctx.Entry(shift).Reload();
                }
                refreshGrid();
            }//if
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvShifts.SelectedRows[0].Cells["colID"].Value.ToString());
            Shift shift = (from s in ctx.Shifts where s.ID == id select s).First();
            new frmRequests(shift).ShowDialog();
        }

        private void dgvPassengers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnDelete.Enabled = btnList.Enabled = dgvShifts.Rows.Count != 0;
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnDelete.Enabled = btnList.Enabled = dgvShifts.Rows.Count != 0;
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

        private void btnSearchRequest_Click(object sender, EventArgs e)
        {
            new frmSearch().ShowDialog();
        }

        private void llbSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void dgvShifts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnList_Click(null, null);
        }

        private void llbAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void llbUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Properties.Settings.Default.User.ID == 1)
                new frmManageUsers().ShowDialog();
            else
                new frmChangePassword().ShowDialog();
        }
    }
}
