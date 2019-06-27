using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace VisaXCentral
{
    public partial class frmChangePassword : Form
    {
        VisaXCenteralEntities ctx = new VisaXCenteralEntities();
        public frmChangePassword()
        {
            InitializeComponent();
          //  Text += Properties.Settings.Default.RemoteUser.RealName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string cryptedPass = StringUtil.Crypt(txtNewPass.Text);

            if (StringUtil.Crypt(txtCurPass.Text) == Properties.Settings.Default.User.Password)
                if (txtNewPass.Text == txtRepPass.Text)
                {
                   // Properties.Settings.Default.User.Password = cryptedPass;
                    ctx.RemoteUsers.Select(u => u).Where(u => u.ID == Properties.Settings.Default.User.ID).FirstOrDefault().Password = cryptedPass;
                    ctx.SaveChanges();
                    MessageBox.Show("رمز عبور جدید تنظیم شد");
                    Close();
                }//if
                else
                    MessageBox.Show("رمز عبور جدید با تکرار آن تطابق ندارد");
            else
                MessageBox.Show("رمز عبور معتبر نیست.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
