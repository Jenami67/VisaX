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
    public partial class frmRenameUser : Form
    {
        VisaXEntities ctx ;
        User CurrentUser;
        public frmRenameUser()
        {
            InitializeComponent();
        }

        public frmRenameUser(User usr, VisaXEntities ctx) :this()
        {
            CurrentUser = usr;
            this.ctx = ctx;
            txtUserName.Text = CurrentUser.UserName;
            txtFullName.Text = CurrentUser.RealName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            erp.Clear();
            if (txtFullName.Text.Trim().Length < 2)
            {
                erp.SetError(txtFullName, "نام کامل کاربر را وارد کنید");
                return;
            }

            CurrentUser.RealName = txtFullName.Text.Trim();
            if (ctx.SaveChanges() > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }//if
        }
    }
}
