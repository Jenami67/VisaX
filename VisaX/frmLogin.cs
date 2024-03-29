﻿using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmLogin : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        VisaXCenteralEntities ctxCentral = new VisaXCenteralEntities("ASAWARI");
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Properties.Settings.Default.LastUserName;
            if (txtUserName.Text.Length > 0)
                this.ActiveControl = txtPassword;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                lblMsg.Text = "نام کاربری را وارد کنید.";
                return;
            }//if

            string cryptedPass = StringUtil.Crypt(txtPassword.Text);
            User usr;
            try
            {
                usr = (from u in ctx.Users
                       where u.UserName == txtUserName.Text
                       && u.Password == cryptedPass
                       select u).FirstOrDefault();
            }
            catch (System.Data.Entity.Core.EntityException ex)
            {
                if (ex.Message == "The underlying provider failed on Open.")
                    new frmMsgBox(ex.ToString(), "اتصال به پایگاه داده محلی برقرار نشد...", MessageBoxButtons.OK, MsgBoxIcon.Error).ShowDialog();
                return;
            }

            if (usr != null)
            {
                Hide();
                Properties.Settings.Default.User = usr;
                Properties.Settings.Default.LastUserName = txtUserName.Text;
                Properties.Settings.Default.Save();

                foreach (Message msg in ctxCentral.Messages.Where(m => m.RemoteUserID == frmRemoteLogin.RemoteUserID).Where(mm => mm.Seen == false))
                    if (new frmMsg(msg).ShowDialog() == DialogResult.Yes)
                        msg.Seen = true;
                    else
                        msg.Seen = false;

                ctxCentral.SaveChanges();

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

        private void lblSetConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmConnectionString().ShowDialog();
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
