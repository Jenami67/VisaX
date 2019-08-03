using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace VisaXCentral
{
    public partial class frmChangePassword : Form
    {
        VisaXCenterNew ctx = new VisaXCenterNew("ASAWARI");
        int UserID;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;//  Text += Properties.Settings.Default.RemoteUser.RealName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string cryptedPass = StringUtil.Crypt(txtNewPass.Text);

            if (txtNewPass.Text == txtRepPass.Text)
            {
                ctx.RemoteUsers.Select(u => u).Where(u => u.ID == this.UserID).FirstOrDefault().Password = cryptedPass;
                ctx.SaveChanges();
                MessageBox.Show("رمز عبور جدید تنظیم شد");
                Close();
            }//if
            else
                MessageBox.Show("رمز عبور جدید با تکرار آن تطابق ندارد");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
