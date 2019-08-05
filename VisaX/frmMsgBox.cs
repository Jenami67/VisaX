using System;
using System.Linq;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmMsgBox : Form
    {
        MessageBoxButtons buttons;
        public frmMsgBox()
        {
            InitializeComponent();
        }
        public frmMsgBox(string message, string title = "", MessageBoxButtons buttons = MessageBoxButtons.OK) : this()
        {
            txtMessage.Text = message;
            lblTitle.Text = title;
            this.buttons = buttons;
            if (this.buttons == MessageBoxButtons.YesNo)
            {
                btnNo.Visible = true;
                btnOK.Text = "بله";
            }//if
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (buttons == MessageBoxButtons.YesNo)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        public static bool IsEnglish(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (IsEnglish(txtMessage.Text.First()))
                txtMessage.TextAlign = HorizontalAlignment.Right;
        }
    }
}
