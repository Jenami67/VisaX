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
    public partial class frmAddUser : Form
    {
        VisaXCenterEntities ctx = new VisaXCenterEntities("ASAWARI");
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            erp.Clear();
            if (txtUserName.Text.Trim() == string.Empty)
            {
                erp.SetError(txtUserName, "نام کاربری را وارد کنید");
                return;
            }

            if (txtFullName.Text.Trim().Length < 2)
            {
                erp.SetError(txtFullName, "نام کامل کاربر را وارد کنید");
                return;
            }

            RemoteUser usr = new RemoteUser
            {
                UserName = txtUserName.Text,
                RealName = txtFullName.Text,
                LastSeen= DateTime.Now,
                Password = string.Empty
            };

            ctx.RemoteUsers.Add(usr);
            if (ctx.SaveChanges() > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }//if
        }
    }
}
