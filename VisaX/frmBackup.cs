using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmBackup : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
                txtPath.Text = fbd.SelectedPath;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string destinationFileName = "\\" + DateTime.Now.ToString("dddd, yyyy-MMM-dd hh.mm tt", new System.Globalization.CultureInfo("en-us")) + ".bak";
            try
            {
                string dbName = "VisaX";
                if (ctx.Database.Connection.DataSource == "(LocalDB)\\MSSQLLocalDB")
                    dbName = Path.GetFullPath(".\\VisaX.mdf");

                ctx.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
                        @"BACKUP DATABASE {0} TO  DISK = {1} WITH NOFORMAT, NOINIT, NAME = {2}, SKIP, NOREWIND, NOUNLOAD, STATS = 10",
                        dbName, txtPath.Text + destinationFileName, "VisaX - Full Database Backup");
            }//try
            catch (Exception ex)
            {
                new frmMsgBox(ex.ToString(), "خطایی در عملیات پشتیبان گیری رخ داد.", MessageBoxButtons.OK , MsgBoxIcon.Error).ShowDialog();
                //MessageBox.Show("خطایی در عملیات پشتیبان گیری رخ داد." + ex.Message);
                return;
            }//catch
            new frmMsgBox("فایل پشتیبان تولید شد.", "پشتیبان گیری", MessageBoxButtons.OK, MsgBoxIcon.Success).ShowDialog();
            //MessageBox.Show("فایل پشتیبان تولید شد.", "پشتیبان گیری", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            Properties.Settings.Default.Save();
        }
    }
}
