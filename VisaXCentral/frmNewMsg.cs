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
    public partial class frmNewMsg : Form
    {
        VisaXCenterEntities ctx = new VisaXCenterEntities("ASAWARI");
        int curUsrID;
        public frmNewMsg()
        {
            InitializeComponent();
        }
        public frmNewMsg(int curUsrID) : this()
        {
            this.curUsrID = curUsrID;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (radCurrent.Checked)
                ctx.Messages.Add(new Message
                {
                    RegTime = DateTime.Now,
                    Title = txtTitle.Text,
                    Text = txtText.Text,
                    RemoteUserID = curUsrID,
                    Seen = false
                });
            else if (radAll.Checked)
                foreach (RemoteUser usr in ctx.RemoteUsers.Select(u => u))
                    ctx.Messages.Add(new Message
                    {
                        RegTime = DateTime.Now,
                        Title = txtTitle.Text,
                        Text = txtText.Text,
                        Seen = false,
                        RemoteUser = usr
                    });

            ctx.SaveChanges();
            MessageBox.Show("پیام ها با موفقیت ثبت شدند.", "ثبت پیام", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            DialogResult = DialogResult.OK;
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (txtText.Text.Length > 0 && txtTitle.Text.Length > 0)
                btnSendMsg.Enabled = true;
        }
    }
}
