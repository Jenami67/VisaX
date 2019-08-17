using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaXCentral
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Crypt() == Properties.Settings.Default.Ram)
            {
                new frmBranches().ShowDialog();
                Close();
            }
            else
                lblMsg.Text = "رمز صحیح نیست.";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
