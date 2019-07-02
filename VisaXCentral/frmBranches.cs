using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Drawing;

namespace VisaXCentral
{
    public partial class frmBranches : Form
    {
        VisaXCenterEntities ctx = new VisaXCenterEntities("ASAWARI");
        public frmBranches()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            new frmChangePassword((int)dgvBranches.SelectedRows[0].Cells["colID"].Value).ShowDialog();
        }

        private void btnShowShifts_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBranches.SelectedRows[0].Cells["colID"].Value;
            RemoteUser user = ctx.RemoteUsers.Select(u => u).Where(u => u.ID == id).First<RemoteUser>();
            new frmShifts(user).ShowDialog();
        }

        private void refreshGrid()
        {
            dgvBranches.DataSource = (from b in ctx.RemoteUsers
                                      select new
                                      {
                                          b.ID,
                                          b.RealName,
                                          b.UserName,
                                          b.LastSeen,
                                          b.RemoteShifts.Count,
                                          Enabled = b.Enabled ? "✓" : "✗"
                                      }).ToList();
        }

        private void frmBranches_Load(object sender, EventArgs e)
        {
            refreshGrid();

        }

        private void dgvBranches_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnShowShifts.Enabled = btnDisable.Enabled = btnChangePass.Enabled = dgvBranches.Rows.Count != 0;
        }

        private void dgvBranches_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvBranches_RowsRemoved(null, null);
        }

        public void rowColor()
        {
            for (int i = 0; i < dgvBranches.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvBranches.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void dgvBranches_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvBranches.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            rowColor();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBranches.SelectedRows[0].Cells["colID"].Value;
            if (dgvBranches.SelectedRows[0].Cells["colEnabled"].Value.ToString() == "✓")
            {
                if (MessageBox.Show("آیا مایل به غیرفعال کردن این شعبه هستید؟\nدر صورت غیرفعال سازی، کاربران این شعبه دیگر قادر به اجرای برنامه نخواهند بود.", "غیرفعال کردن شعبه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) == DialogResult.Yes)
                    ctx.RemoteUsers.Select(u => u).Where(u => u.ID == id).First<RemoteUser>().Enabled = false;
            }//if
            else if (MessageBox.Show("آیا مایل به فعال کردن این شعبه هستید؟", "فعال سازی شعبه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign) == DialogResult.Yes)
                ctx.RemoteUsers.Select(u => u).Where(u => u.ID == id).First<RemoteUser>().Enabled = true;
            ctx.SaveChanges();

            int selShift = dgvBranches.SelectedRows[0].Index;
            refreshGrid();
            dgvBranches.Rows[selShift].Selected = true;
        }

        private void dgvBranches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBranches.SelectedRows.Count > 0)
                btnDisable.Text = dgvBranches.SelectedRows[0].Cells["colEnabled"].Value.ToString() == "✓" ? "غیرفعال کردن" : "فعال سازی";
        }

        private void btnNewBranch_Click(object sender, EventArgs e)
        {
            new frmAddUser().ShowDialog();
            refreshGrid();
            dgvBranches.ClearSelection();
            dgvBranches.Rows[dgvBranches.RowCount - 1].Selected = true;
        }

        private void llbGeneratePDF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmGeneratePDF().ShowDialog();
        }

        private void dgvBranches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnShowShifts_Click(null, null);
        }
    }
    public static class StringUtil
    {
        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static string Crypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }

    public partial class VisaXCenterEntities : DbContext
    {
        public VisaXCenterEntities(string user, string pwd)
            : base("name=VisaXCenterEntities")
        {
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, pwd);
        }

        public VisaXCenterEntities(string user)
             : base("name=VisaXCenterEntities")
        {
            if (user == "ASAWARI")
                Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, "3Pg^gf81");
        }
    }
}
