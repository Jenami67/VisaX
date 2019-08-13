using System;
using System.Linq;
using System.Windows.Forms;

namespace VisaX
{
    public enum MsgBoxIcon
    {
        Error,
        Success,
        Question,
        Stop,
        None
    }

    public partial class frmMsgBox : Form
    {
        MessageBoxButtons buttons;
        public frmMsgBox()
        {
            InitializeComponent();
        }

        public frmMsgBox(string message, string title = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MsgBoxIcon icon = MsgBoxIcon.None) : this()
        {
            txtMessage.Text = message;
            lblTitle.Text = title;
            this.buttons = buttons;
            if (this.buttons == MessageBoxButtons.YesNo)
            {
                btnNo.Visible = true;
                btnOK.Text = "بله";
            }//if

            switch (icon)
            {
                case MsgBoxIcon.Error:
                    picIcon.Image = imageList1.Images[0];
                    break;
                case MsgBoxIcon.Success:
                    picIcon.Image = imageList1.Images[1];
                    break;
                case MsgBoxIcon.Question:
                    picIcon.Image = imageList1.Images[2];
                    break;
                case MsgBoxIcon.Stop:
                    picIcon.Image = imageList1.Images[2];
                    break;
                default:
                    break;
            }//switch
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
