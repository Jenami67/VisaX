using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmLogin : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        public frmLogin()
        {
            InitializeComponent();
            txtUserName.Text = Properties.Settings.Default.LastUserName;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                lblMsg.Text = "نام کاربری را وارد کنید.";
                return;
            }//if

            string cryptedPass = StringUtil.Crypt(txtPassword.Text);

            User usr = (from u in ctx.Users
                        where u.UserName == txtUserName.Text
                        && u.Password == cryptedPass
                        select u).FirstOrDefault();

            if (usr != null)
            {
                Hide();
                Properties.Settings.Default.User = usr;
                Properties.Settings.Default.LastUserName = txtUserName.Text;
                Properties.Settings.Default.Save();
                new frmShift().ShowDialog();
                Close();
            }//if
            else
            {
                txtPassword.Text = string.Empty;
                lblMsg.Text = "نام کاربری یا رمز عبور اشتباه است.";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
}
