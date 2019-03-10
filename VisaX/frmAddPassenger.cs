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
        private VisaXEntities ctx = new VisaXEntities();
        private PersianCalendar pc = new PersianCalendar();
        private DateTime dt;
        private Passenger passenger;

        public frmAddPassenger()
        {
            InitializeComponent();
        }

        public frmAddPassenger(Passenger p) : this()
        {
            txtName.Text = p.Name;
            txtFamily.Text = p.Family;
            txtFather.Text = p.Father;
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

            if (txtName.Text.Trim().Length < 1)
            {
                cntr = txtName;
                retVal = false;
            }
            else if (txtFamily.Text.Trim().Length < 1)
            {
                cntr = txtFamily;
                retVal = false;
            }
            else if (txtFather.Text.Trim().Length < 1)
            {
                cntr = txtFather;
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
                if (this.passenger == null)
                {
                    Passenger p = new Passenger
                    {
                        Name = txtName.Text,
                        Family = txtFamily.Text,
                        Father = txtFather.Text,
                        PassportNum = txtPassportNum.Text,
                        Gender = (byte)cmbGender.SelectedIndex,
                        BornDate = DateTime.Parse(txtBornDate.Text),
                        IssueDate = DateTime.Parse(txtIssueDate.Text),
                        ExpiryDate = DateTime.Parse(txtExpiryDate.Text)
                    };

                    ctx.Passengers.Add(p);
                    sucMessage = "رکورد جدید اضافه شد";
                    lblStatusMsg.ForeColor = Color.DarkGreen;
                    lblStatusMsg.Text = string.Format("{0} ({1} {2})", sucMessage, p.Name, p.Family);
                }
                else //if edit mode
                {
                    this.passenger.Name = txtName.Text;
                    this.passenger.Family = txtFamily.Text;
                    this.passenger.Father = txtFather.Text;
                    this.passenger.PassportNum = txtPassportNum.Text;
                    this.passenger.Gender = (byte)cmbGender.SelectedIndex;
                    this.passenger.BornDate = DateTime.Parse(txtBornDate.Text);
                    this.passenger.IssueDate = DateTime.Parse(txtIssueDate.Text);
                    this.passenger.ExpiryDate = DateTime.Parse(txtExpiryDate.Text);

                    ctx.Passengers.Attach(this.passenger);
                    ctx.Entry(this.passenger).State = System.Data.Entity.EntityState.Modified;
                    sucMessage = "رکورد ویرایش شد";
                    lblStatusMsg.ForeColor = Color.DarkBlue;
                    lblStatusMsg.Text = string.Format("{0} ({1} {2})", sucMessage, passenger.Name, passenger.Family);
                }//else

                ctx.SaveChanges();
                //MessageBox.Show(sucMessage);

                txtPassportNum.Focus();
                txtName.Text = txtFamily.Text = txtFather.Text = txtPassportNum.Text = txtBornDate.Text =
                    txtExpiryDate.Text = txtIssueDate.Text = string.Empty;

                //this.DialogResult = DialogResult.OK;
                // InitializeComponent();

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
            if (txtPassportNum.Text.Length == 8)
            {
                lblStatusMsg.Text = string.Empty;
                Passenger pas = (from p in ctx.Passengers
                                 where p.PassportNum == txtPassportNum.Text
                                 select p).FirstOrDefault();
                if (pas !=null)
                {

                    txtName.Text = pas.Name;
                    txtFamily.Text = pas.Family;
                    txtFather.Text = pas.Father;
                    txtPassportNum.Text = pas.PassportNum;
                    cmbGender.SelectedIndex = pas.Gender;
                    txtBornDate.Text = pas.BornDate.ToShortDateString();
                    txtIssueDate.Text = pas.IssueDate.ToShortDateString();
                    txtExpiryDate.Text = pas.ExpiryDate.ToShortDateString();
                }
            }
        }
    }
}
