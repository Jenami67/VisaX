using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace VisaX
{
    public partial class frmConnectionString : Form
    {
        public frmConnectionString()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Exception ex;
            if (checkState(out ex) == ConnectionState.Open)
            {
                CsTools.SaveCs("VisaXEntities", txtConnectionString.Text);
                MessageBox.Show("اتصال به پایگاه داده تنظیم شد.", " اتصال به پایگاه داده...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                Application.Restart();
            }
            else
                MessageBox.Show("اتصال به پایگاه داده معتبر نیست.\n" + ex.Message);
        }

        private void frmConnectionString_Load(object sender, EventArgs e)
        {
            if (CsTools.LoadCs("VisaXEntities").DataSource == "(LocalDB)\\MSSQLLocalDB")
                cmbConnectionType.SelectedIndex = 0;
            else
                cmbConnectionType.SelectedIndex = 1;

            txtConnectionString.Text = CsTools.LoadCsWithMetadata("VisaXEntities");
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDataSource.Enabled = cmbConnectionType.SelectedIndex == 0 ? false : true;

            if (cmbConnectionType.SelectedIndex == 0)
                txtConnectionString.Text = CsTools.LoadCsWithMetadata("VisaXEntitiesLocal");
            if (cmbConnectionType.SelectedIndex == 1)
                txtConnectionString.Text = CsTools.LoadCsWithMetadata("VisaXEntitiesSQL");
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            Exception ex;
            if (checkState(out ex) == ConnectionState.Open)
                MessageBox.Show("اتصال به پایگاه داده صحیح است.", "تست اتصال به پایگاه داده...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            else
                MessageBox.Show("اتصال به پایگاه داده معتبر نیست.\n" + ex.Message);

        }

        private ConnectionState checkState(out Exception ex)
        {
            var entityCnxStringBuilder = new EntityConnectionStringBuilder(txtConnectionString.Text);

            using (SqlConnection conn = new SqlConnection(entityCnxStringBuilder.ProviderConnectionString))
            {
                ex = null;
                try
                {
                    conn.Open();
                }
                catch (Exception exx)
                {
                    ex = exx;
                }
                return conn.State;
            }
        }

        private void cmbDataSource_TextChanged(object sender, EventArgs e)
        {
            txtConnectionString.Text = CsTools.ChangeCsWithMetadata(txtConnectionString.Text, cmbDataSource.Text).ConnectionString;
        }

        private void frmConnectionString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }

    public static class CsTools
    {
        public static EntityConnectionStringBuilder ChangeCsWithMetadata(string connectionString, string dataSource = "", string initialCatalog = "",
            string userId = "", string password = "", bool integratedSecuity = true,
            string configConnectionStringName = "")
        {
            try
            {
                //// add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder(connectionString);

                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;
                // set the integrated security status
                sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

                entityCnxStringBuilder.ProviderConnectionString = sqlCnxStringBuilder.ConnectionString;
                return entityCnxStringBuilder;
            }
            catch (Exception)
            {
                throw;
                // set log item if required
            }
        }

        public static String LoadCsWithMetadata(string sectionName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            var entityCnxStringBuilder = new EntityConnectionStringBuilder(
                connectionStringsSection.ConnectionStrings[sectionName].ConnectionString);
            return entityCnxStringBuilder.ConnectionString;
        }

        public static String LoadCsWithoutMetadata(string sectionName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            var entityCnxStringBuilder = new EntityConnectionStringBuilder(
                connectionStringsSection.ConnectionStrings[sectionName].ConnectionString);
            return entityCnxStringBuilder.ProviderConnectionString;
        }

        public static SqlConnectionStringBuilder LoadCs(string sectionName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            var entityCnxStringBuilder = new EntityConnectionStringBuilder(
                connectionStringsSection.ConnectionStrings[sectionName].ConnectionString);
            var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

            return sqlCnxStringBuilder;
        }


        public static void SaveCs(string sectionName, string connectionstring)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            connectionStringsSection.ConnectionStrings[sectionName].ConnectionString = connectionstring;

            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
