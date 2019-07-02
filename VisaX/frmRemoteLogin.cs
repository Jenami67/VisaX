using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
//using VisaX;

namespace VisaX
{
    public partial class frmRemoteLogin : Form
    {
        VisaXCenteralEntities ctx = new VisaXCenteralEntities("ASAWARI");

        public frmRemoteLogin()
        {
            InitializeComponent();
        }//frmRemoteLogin

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                lblMsg.Text = "نام کاربری را وارد کنید.";
                return;
            }//if

            string cryptedPass = StringUtil.Crypt(txtPassword.Text);
            try
            {
                RemoteUser usr = (from u in ctx.RemoteUsers
                                  where u.UserName == txtUserName.Text
                                  && u.Password == cryptedPass
                                  select u).FirstOrDefault();

                if (usr != null)
                {
                    if (!usr.Enabled)
                    {
                        MessageBox.Show("ورود شما به سیستم از طریق مدیریت غیرفعال شده.\nامکان ورود به برنامه وجود ندارد لطفاً با مدیر سیستم تماس بگیرید.", "کاربر غیرفعال شده", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                        return;
                    }
                    Properties.Settings.Default.RemoteUserName = txtUserName.Text;
                    Properties.Settings.Default.RemotePassword = StringUtil.Crypt(txtPassword.Text);
                    Properties.Settings.Default.Save();
                    RemoteUserID = usr.ID;

                    Hide();
                    new frmLogin().ShowDialog();
                    Close();
                }//if
                else
                {
                    txtPassword.Text = string.Empty;
                    lblMsg.Text = "نام کاربری یا رمز عبور اشتباه است.";
                }
            }
            catch (System.Data.Entity.Core.EntityException ex)
            {
                if (ex.InnerException.HResult == -2146232060)
                    MessageBox.Show("اتصال به پایگاه داده برقرار نشد. لطفا از اتصال به اینترنت مطمئن شوید...\n" + ex.ToString());
            }

        }

        private void frmRemoteLogin_Load(object sender, EventArgs e)
        {
            //Login Automaticaly if there is a user saved in settings
            if (Properties.Settings.Default.RemoteUserName != string.Empty)
            {
                txtUserName.Text = Properties.Settings.Default.RemoteUserName;
                txtPassword.Text = StringUtil.Decrypt(Properties.Settings.Default.RemotePassword);
                string cryptedPass = StringUtil.Crypt(txtPassword.Text);

                try
                {
                    RemoteUser usr = (from u in ctx.RemoteUsers
                                      where u.UserName == txtUserName.Text
                                      && u.Password == cryptedPass
                                      select u).FirstOrDefault();
                    if (usr != null)
                    {
                        if (!usr.Enabled)
                        {
                            MessageBox.Show("ورود شما به سیستم از طریق مدیریت غیرفعال شده.\nامکان ورود به برنامه وجود ندارد لطفاً با مدیر سیستم تماس بگیرید.", "کاربر غیرفعال شده", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                            return;
                        }
                        RemoteUserID = usr.ID;
                        Hide();
                        new frmLogin().ShowDialog();
                        Close();
                    }//if
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    if (ex.InnerException.HResult == -2146232060)
                        MessageBox.Show("اتصال به پایگاه داده برقرار نشد. لطفا از اتصال به اینترنت مطمئن شوید...\n\n" + ex.ToString());
                    return;
                }
            }//if
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static int RemoteUserID { get; set; }
    }

    public partial class VisaXCenteralEntities : DbContext
    {
        public VisaXCenteralEntities(string user, string pwd)
            : base("name=VisaXCenterEntities")
        {
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, pwd);
        }

        public VisaXCenteralEntities(string user)
             : base("name=VisaXCenterEntities")
        {
            if (user == "ASAWARI")
                Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, "3Pg^gf81");
        }
    }
}
