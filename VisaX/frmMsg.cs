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
    public partial class frmMsg : Form
    {
        Message message;
        public frmMsg()
        {
            InitializeComponent();
        }

        public frmMsg(Message msg) : this()
        {
            message = msg;
        }
        private void frmMsg_Load(object sender, EventArgs e)
        {
            lblTitle.Text = message.Title;
            lblText.Text = message.Text;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (chkSeen.Checked)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No;
        }
    }
}
