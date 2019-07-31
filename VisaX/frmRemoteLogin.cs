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
        VisaXEntities ctxLocal = new VisaXEntities();

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
                    }//if
                    if (NewUserWithDirtyApp(usr))
                    {
                        MessageBox.Show(String.Format("شما قبلاً با نام شعبه {0} شیفت ثبت کرده اید؛ لطفاً: \n  - با شعبه {0} وارد شوید.\n  - یا برنامه خام را دریافت کرده و با نام شعبه {1} وارد شوید.\n", Properties.Settings.Default.RemoteUserName, usr.UserName), "کاربر غیرفعال شده", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                        return;
                    }
                    Properties.Settings.Default.RemoteUserName = txtUserName.Text;
                    Properties.Settings.Default.RemotePassword = StringUtil.Crypt(txtPassword.Text);
                    Properties.Settings.Default.Save();
                    RemoteUserID = usr.ID;
                    Properties.Settings.Default.RemoteUser = usr;

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
                RemoteUser usr;
                try
                {
                    usr = (from u in ctx.RemoteUsers
                           where u.UserName == txtUserName.Text
                           && u.Password == cryptedPass
                           select u).FirstOrDefault();
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    if (ex.InnerException.HResult == -2146232060)
                        MessageBox.Show("اتصال به پایگاه داده برقرار نشد. لطفا از اتصال به اینترنت مطمئن شوید...\n\n" + ex.ToString());
                    return;
                }//catch

                if (usr != null)
                {
                    if (!usr.Enabled)
                    {
                        MessageBox.Show("ورود شما به سیستم از طریق مدیریت غیرفعال شده.\nامکان ورود به برنامه وجود ندارد لطفاً با مدیر سیستم تماس بگیرید.", "کاربر غیرفعال شده", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                        return;
                    }

                    if (NewUserWithDirtyApp(usr))
                    {
                        MessageBox.Show("شما قبلاً با نام شعبه دیگری شیفت ثبت کرده اید؛ لطفاً \t- با شعبه قبلی وارد شوید.\t- یا برنامه خام را دریافت کرده و با نام شعبه مورد نظر وارد شوید.\n", "کاربر غیرفعال شده", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                        return;
                    }
                    Properties.Settings.Default.RemoteUser = usr;
                    RemoteUserID = usr.ID;
                    Hide();
                    new frmLogin().ShowDialog();
                    Close();
                }//if
            }//if
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool NewUserWithDirtyApp(RemoteUser usr)
        {
            return usr.UserName.ToLower() != Properties.Settings.Default.RemoteUserName.ToLower() && ctxLocal.Shifts.Count() > 0 && Properties.Settings.Default.RemoteUserName.ToLower() != string.Empty;
        }

        //User info all over the program
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
