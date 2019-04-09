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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == Properties.Settings.Default.Pass)
            {
                Hide();
                new frmRequests().ShowDialog();
                Close();
            }//if
            else
                lblMsg.Text = "رمز عبور اشتباه است.";
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
}
