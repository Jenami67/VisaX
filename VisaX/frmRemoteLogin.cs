using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace VisaXCentral
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
                    Hide();
                    Properties.Settings.Default.RemoteUser = usr;
                    Properties.Settings.Default.RemoteUserName = txtUserName.Text;
                    Properties.Settings.Default.RemotePassword = StringUtil.Crypt(txtPassword.Text);

                    Properties.Settings.Default.Save();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRemoteLogin_Load(object sender, EventArgs e)
        {
            //Login Automaticaly if there is a user saved in settings
            if (Properties.Settings.Default.RemoteUserName != string.Empty)
            {
                try
                {
                    RemoteUser usr = (from u in ctx.RemoteUsers
                                      where u.UserName == Properties.Settings.Default.RemoteUserName
                                      && u.Password == Properties.Settings.Default.RemotePassword
                                      select u).FirstOrDefault();

                    if (usr != null)
                    {
                        Hide();
                        new frmLogin().ShowDialog();
                        Close();
                    }//if
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    if (ex.InnerException.HResult == -2146232060)
                        MessageBox.Show("اتصال به پایگاه داده برقرار نشد. لطفا از اتصال به اینترنت مطمئن شوید..\n" + ex.ToString());
                }

            }//if
        }
    }

    public partial class VisaXCenteralEntities
    {
        public VisaXCenteralEntities(string user, string pwd)
            : base("name=VisaXCenterEntities")
        {
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, pwd);
        }

       public VisaXCenteralEntities(string user)
            : base("name=VisaXCenterEntities")
        {
            if(user == "ASAWARI")
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, "3Pg^gf81");
        } 
    }
}
