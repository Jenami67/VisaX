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
    public partial class frmManageUsers : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        public frmManageUsers()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
            getData();
        }

        private void getData()
        {
            dgvUsers.DataSource = (from u in ctx.Users select u).ToList();
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
                return;

            User usr = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            if (usr.ID == 1)
            {
                btnChangePass.Visible = true;
                btnDelete.Enabled = btnResetPass.Enabled = false;
            }//if
            else
            {
                btnChangePass.Visible = false;
                btnDelete.Enabled = btnResetPass.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (new frmAddUser().ShowDialog() == DialogResult.OK)
            {
                this.getData();
                // set third row's back color to yellow
                dgvUsers.Rows[dgvUsers.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                // set glow interval to 2000 milliseconds
                GlowTimer.Interval = 2000;
                GlowTimer.Enabled = true;
            }
        }

        private void GlowTimer_Tick(object sender, EventArgs e)
        {
            // disable timer and set the color back to white
            GlowTimer.Enabled = false;
            dgvUsers.Rows[dgvUsers.Rows.Count - 1].DefaultCellStyle.BackColor = Color.White;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            new frmChangePassword().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            User usr = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("آیا مایل به حذف این کاربر هستید؟", "حذف " + usr.RealName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctx.Users.Remove(usr);
                try
                {
                    ctx.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    new frmMsgBox(ex.ToString(), "امکان حذف کاربری که عملیات انجام داده وجود ندارد.").ShowDialog();
                    //MessageBox.Show("امکان حذف کاربری که عملیات انجام داده وجود ندارد.\n\n" + .Remove(500) + "...", "خطا در حذف کاربر", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ctx.Entry(usr).Reload();
                    return;
                }
                getData();
            }//if
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            User usr = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("آیا مایل به پاک کردن رمز این کاربر هستید؟", "پاکسازی رمز " + usr.RealName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctx.Users.Select(u => u).Where(u => u.ID == usr.ID).FirstOrDefault().Password = StringUtil.Crypt(string.Empty);
                try
                {
                    ctx.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    MessageBox.Show("خطایی رخ داده.\n\n" + ex.ToString().Remove(500) + "...", "خطا در ثبت اطلاعات");
                    ctx.Entry(usr).Reload();
                    return;
                }
            }//if
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            User usr = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            if (new frmRenameUser(usr, ctx).ShowDialog() == DialogResult.OK)
                getData();
        }

        private void frmManageUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
