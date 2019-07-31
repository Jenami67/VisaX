using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity;

namespace VisaX
{
    public partial class frmRestore : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        public frmRestore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                cmbBackupFile.Items.Clear();
                foreach (string file in Directory.GetFiles(fbd.SelectedPath, "*.bak"))
                    cmbBackupFile.Items.Add(Path.GetFileNameWithoutExtension(file));
                cmbBackupFile.SelectedIndex = cmbBackupFile.Items.Count - 1;
                cmbBackupFile.Tag = fbd.SelectedPath;

                if (cmbBackupFile.Items.Count == 0)
                {
                    MessageBox.Show("هیچ فایل پشتیبانی در این پوشه یافت نشد.", "بازیابی", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    frmRestore_Load(null, null);
                }//if
            }//if
        }

        private void frmRestore_Load(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(Properties.Settings.Default.BackupPath);
            var files = info.GetFiles("*.bak").OrderBy(p => p.CreationTime);

            foreach (var file in files)
                cmbBackupFile.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            cmbBackupFile.SelectedIndex = cmbBackupFile.Items.Count - 1;
            cmbBackupFile.Tag = Properties.Settings.Default.BackupPath;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string dbName = "VisaX";
            if (ctx.Database.Connection.DataSource == "(LocalDB)\\MSSQLLocalDB")
                dbName = Path.GetFullPath(".\\VisaX.mdf");
            else
                ctx.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE {0} SET Single_User WITH Rollback Immediate", dbName);

            string fileName = string.Format("{0}\\{1}.bak", cmbBackupFile.Tag.ToString(), cmbBackupFile.SelectedItem);
            ctx.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
                @"USE [master]
                RESTORE DATABASE {0} FROM  DISK = {1} WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5",
                dbName, fileName);

            if (ctx.Database.Connection.DataSource != "(LocalDB)\\MSSQLLocalDB")
                ctx.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE {0} SET Multi_User", dbName);

            MessageBox.Show("بازیابی انجام شد. برای اعمال تغیرات برنامه ریستارت می شود.", "بازیابی", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            Application.Restart();
        }
    }
}