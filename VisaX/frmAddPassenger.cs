using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace VisaX
{
    public partial class frmAddPassenger : Form
    {
        private PersianCalendar pc = new PersianCalendar();
        private DateTime dt;

        public frmAddPassenger()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void txtBornDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (e.IsValidInput)
            {
                dt = DateTime.Parse(txtBornDate.Text);
                lblBornDate.Text = string.Format("{0}/{1:00}/{2:00}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                erp.Clear();
            }//if
            else
            {
                erp.SetError(txtBornDate, "تاریخ معتبر نیست!");
                e.Cancel = true;
            }//else
        }

        private void txtIssueDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (e.IsValidInput)
            {
                dt = DateTime.Parse(txtIssueDate.Text);
                lblIssueDate.Text = string.Format("{0}/{1:00}/{2:00}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                erp.Clear();
            }//if
            else
            {
                erp.SetError(txtIssueDate, "تاریخ معتبر نیست!");
                e.Cancel = true;
            }//else
        }

        private void txtExpiryDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (e.IsValidInput)
            {
                dt = DateTime.Parse(txtExpiryDate.Text);
                lblExpiryDate.Text = string.Format("{0}/{1:00}/{2:00}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                erp.Clear();
            }//if
            else
            {
                erp.SetError(txtExpiryDate, "تاریخ معتبر نیست!");
                e.Cancel = true;
            }//else
        }
    }
}
