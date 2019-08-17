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
    public partial class frmChangeAppPath : Form
    {
        public frmChangeAppPath()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string cryptedPass = StringUtil.Crypt(txtNewPass.Text);

            if (StringUtil.Crypt(txtCurPass.Text) == Properties.Settings.Default.Ram)
                if (txtNewPass.Text == txtRepPass.Text)
                {
                    Properties.Settings.Default.Ram = cryptedPass;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("رمز عبور جدید تنظیم شد.");
                    Close();
                }//if
                else
                    MessageBox.Show("رمز عبور جدید با تکرار آن تطابق ندارد.");
            else
                MessageBox.Show("رمز عبور معتبر نیست.");
        }
    }
}
