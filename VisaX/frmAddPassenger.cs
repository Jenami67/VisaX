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
        private VisaXEntities ctx;
        private PersianCalendar pc = new PersianCalendar();
        private DateTime dt;
        private Passenger passenger;

        public frmAddPassenger()
        {
            InitializeComponent();
        }

        public frmAddPassenger( VisaXEntities ctx) : this()
        {
            this.ctx = ctx;
        }

        public frmAddPassenger(Passenger p, VisaXEntities ctx) : this(ctx)
        {
           // this.ctx = ctx;
            txtFullName.Text = p.FullName;
            txtPassportNum.Text = p.PassportNum;
            cmbGender.SelectedIndex = p.Gender;
            txtBornDate.Text = p.BornDate.ToShortDateString();
            txtIssueDate.Text = p.IssueDate.ToShortDateString();
            txtExpiryDate.Text = p.ExpiryDate.ToShortDateString();
            this.passenger = p;
        }

        private bool validateForm()
        {
            Control cntr = null;
            bool retVal = true;
            DateTime tempDate;

            erp.Clear();

            if (txtFullName.Text.Trim().Length < 3)
            {
                cntr = txtFullName;
                retVal = false;
            }
            else if (txtPassportNum.Text.Trim().Length != 8)
            {
                cntr = txtPassportNum;
                retVal = false;
            }
            else if (cmbGender.SelectedIndex == -1)
            {
                cntr = cmbGender;
                retVal = false;
            }
            else if (!DateTime.TryParse(txtBornDate.Text, out tempDate))
            {
                cntr = txtBornDate;
                retVal = false;
            }
            else if (!DateTime.TryParse(txtIssueDate.Text, out tempDate))
            {
                cntr = txtIssueDate;
                retVal = false;
            }
            else if (!DateTime.TryParse(txtExpiryDate.Text, out tempDate))
            {
                cntr = txtExpiryDate;
                retVal = false;
            }

            if (retVal == false)
                erp.SetError(cntr, "ورودی معتبر نیست!");
            return retVal;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sucMessage = string.Empty;
            if (validateForm())
            {
                if (this.passenger == null) //if Add mode
                {
                    Passenger p = new Passenger
                    {
                        FullName = txtFullName.Text,
                        PassportNum = txtPassportNum.Text,
                        Gender = (byte)cmbGender.SelectedIndex,
                        BornDate = DateTime.Parse(txtBornDate.Text),
                        IssueDate = DateTime.Parse(txtIssueDate.Text),
                        ExpiryDate = DateTime.Parse(txtExpiryDate.Text),
                        EntryDate = DateTime.Today,
                        Printed = false
                    };

                    ctx.Passengers.Add(p);
                    sucMessage = "رکورد جدید اضافه شد";
                    lblStatusMsg.ForeColor = Color.DarkGreen;
                    lblStatusMsg.Text = string.Format("{0} ({1})", sucMessage, p.FullName);
                }
                else //if edit mode
                {
                    this.passenger.FullName = txtFullName.Text;
                    this.passenger.PassportNum = txtPassportNum.Text;
                    this.passenger.Gender = (byte)cmbGender.SelectedIndex;
                    this.passenger.BornDate = DateTime.Parse(txtBornDate.Text);
                    this.passenger.IssueDate = DateTime.Parse(txtIssueDate.Text);
                    this.passenger.ExpiryDate = DateTime.Parse(txtExpiryDate.Text);

                    //ctx.Passengers.Attach(this.passenger);
                    //ctx.Entry(this.passenger).State = System.Data.Entity.EntityState.Modified;
                    sucMessage = "رکورد ویرایش شد";
                    lblStatusMsg.ForeColor = Color.DarkBlue;
                    lblStatusMsg.Text = string.Format("{0} ({1})", sucMessage, passenger.FullName);
                }//else

                ctx.SaveChanges();
                txtPassportNum.Focus();
                txtFullName.Text = txtPassportNum.Text = txtBornDate.Text = txtExpiryDate.Text = txtIssueDate.Text = string.Empty;
            }//if
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtIssueDate_Leave(object sender, EventArgs e)
        {
            txtExpiryDate.Text = DateTime.Parse(txtIssueDate.Text).AddYears(5).ToShortDateString();
        }

        private void txtPassportNum_TextChanged(object sender, EventArgs e)
        {
            if (txtPassportNum.Text.Length == 8 && this.passenger ==null)
            {
                lblStatusMsg.Text = string.Empty;
                this.passenger = (from p in ctx.Passengers
                                 where p.PassportNum == txtPassportNum.Text
                                 select p).FirstOrDefault();
                if (this.passenger != null)
                {
                    txtFullName.Text = this.passenger.FullName;
                    txtPassportNum.Text = this.passenger.PassportNum;
                    cmbGender.SelectedIndex = this.passenger.Gender;
                    txtBornDate.Text = this.passenger.BornDate.ToShortDateString();
                    txtIssueDate.Text = this.passenger.IssueDate.ToShortDateString();
                    txtExpiryDate.Text = this.passenger.ExpiryDate.ToShortDateString();
                    this.passenger.EntryDate = DateTime.Today;
                    this.passenger.Printed = false;
                }//if
            }
        }
    }
}
