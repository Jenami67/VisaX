﻿using System;
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
            Text = " کاربر محلی: " + Properties.Settings.Default.User.RealName + " - نام شعبه: " + Properties.Settings.Default.RemoteUserName;
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
                                        s.Requests.Count,
                                        Sent = s.Sent ? "✓" : "✗"
                                    }).ToList();

            int cnt = ctx.Shifts.Where(s => s.Sent == false).Where(s => s.Requests.Any()).Count();
            if (cnt == 0)
                llbSendShifts.Text = "ارسال شیفت ها";
            else
                llbSendShifts.Text = string.Format("ارسال شیفت ها ({0})", cnt);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            byte max = ctx.Shifts.Where(s => s.Date == DateTime.Today).Select(s => s.ShiftNum).DefaultIfEmpty<byte>(0).Max();
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
            int id = (int)dgvShifts.SelectedRows[0].Cells["colID"].Value;
            Shift shift = (from s in ctx.Shifts where s.ID == id select s).First();
            if (new frmMsgBox("آیا مایل به حذف این شیفت هستید؟", "حذف شیفت", MessageBoxButtons.YesNo, MsgBoxIcon.Question).ShowDialog() == DialogResult.Yes)
            {
                ctx.Shifts.Remove(shift);
                try
                {
                    ctx.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    new frmMsgBox(ex.ToString(), "امکان حذف شیفتی که متقاضی در آن ثبت شده وجود ندارد.", MessageBoxButtons.OK, MsgBoxIcon.Error).ShowDialog();
                    ctx.Entry(shift).Reload();
                }
                refreshGrid();
            }//if
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ctx = new VisaXEntities();
            int id = (int)dgvShifts.SelectedRows[0].Cells["colID"].Value;
            Shift shift = (from s in ctx.Shifts where s.ID == id select s).First();
            string message = string.Format("ویرایش توضیحات شیفت شماره {0} با تاریخ {1} توسط {2}؟", shift.ShiftNum, shift.Date.ToShortDateString(), shift.User.RealName);
            frmNewShift frmNewShift = new frmNewShift(message);
            frmNewShift.txtDescription.Text = shift.Description;
            if (frmNewShift.ShowDialog() == DialogResult.Yes)
                shift.Description = frmNewShift.txtDescription.Text;

            ctx.SaveChanges();
            refreshGrid();

            dgvShifts.ClearSelection();
            dgvShifts.Rows[dgvShifts.RowCount - 1].Selected = true;
        }//btnEdit

        private void btnList_Click(object sender, EventArgs e)
        {
            ctx = new VisaXEntities();
            int id = int.Parse(dgvShifts.SelectedRows[0].Cells["colID"].Value.ToString());
            Shift shift = (from s in ctx.Shifts where s.ID == id select s).First();
            new frmRequests(shift).ShowDialog();
            int selShift = dgvShifts.SelectedRows[0].Index;
            refreshGrid();
            dgvShifts.Rows[selShift].Selected = true;
        }

        private void dgvPassengers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnEdit.Enabled = btnDelete.Enabled = btnList.Enabled = dgvShifts.Rows.Count != 0;
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvPassengers_RowsRemoved(null, null);
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

        private void llbUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.User.ID == 1)
                    new frmManageUsers().ShowDialog();
                else
                    new frmChangePassword().ShowDialog();
            }
            catch (System.NullReferenceException ex)
            {
                new frmMsgBox(ex.Message, "لطفاً برنامه را مجدداً کنید.", MessageBoxButtons.OK, MsgBoxIcon.Error).ShowDialog();
            }
        }

        private void llbSendShifts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSendShifts().ShowDialog();
            refreshGrid();
        }

        private void dtpTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void frmShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Control)
                btnNew_Click(null, null);
            if (e.KeyCode == Keys.D && e.Control && btnDelete.Enabled)
                btnDelete_Click(null, null);
            if (e.KeyCode == Keys.E && e.Control && btnEdit.Enabled)
                btnEdit_Click(null, null);
            if (e.KeyCode == Keys.L && e.Control && btnList.Enabled)
                btnList_Click(null, null);
            if (e.KeyCode == Keys.F && e.Control)
                btnSearchRequest_Click(null, null);

            if (e.KeyCode == Keys.U && e.Control)
                llbUser_LinkClicked(null, null);
            if (e.KeyCode == Keys.S && e.Control)
                llbSendShifts_LinkClicked(null, null);
        }
    }
}
