using System;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
        }

        private void lblRestore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Properties.Settings.Default.User.ID == 1)
                new frmRestore().ShowDialog();
            else
                MessageBox.Show("تنها کاربر admin قادر به بازیابی پایگاه داده است.", "بازیابی", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
        }

        private void lblBackup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBackup().ShowDialog();
        }

        private void llbImportXls_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmImportXls().ShowDialog();
        }

        private void lblSetConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmConnectionString().ShowDialog();
        }
    }
}
