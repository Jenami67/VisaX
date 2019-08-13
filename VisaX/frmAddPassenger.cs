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
        Shift selectedShift;
        private bool justEdit;

        public frmAddPassenger()
        {
            InitializeComponent();
        }

        public frmAddPassenger(VisaXEntities ctx, Shift shift) : this()
        {
            this.ctx = ctx;
            this.selectedShift = shift;
            if (passenger == null)
                txtBornDate.Enabled = txtIssueDate.Enabled = txtExpiryDate.Enabled = !Properties.Settings.Default.DatesDisabled;
            //TODO: may need revise and in enter value
        }

        public frmAddPassenger(Passenger p, VisaXEntities ctx, Shift shift, bool justEdit = false) : this(ctx, shift)
        {
            txtFullName.Text = p.FullName;
            txtPassportNum.Text = p.PassportNum;
            cmbGender.SelectedIndex = p.Gender;
            txtBornDate.Text = p.BornDate.HasValue ? p.BornDate.Value.ToShortDateString() : string.Empty;
            txtIssueDate.Text = p.IssueDate.HasValue ? p.IssueDate.Value.ToShortDateString() : string.Empty;
            txtExpiryDate.Text = p.ExpiryDate.HasValue ? p.ExpiryDate.Value.ToShortDateString() : string.Empty;
            this.passenger = p;
            this.justEdit = justEdit;
            //if (passenger != null && passenger.BornDate.HasValue)
            //    txtBornDate.Enabled = txtIssueDate.Enabled = txtExpiryDate.Enabled = true;
            if (passenger != null)
                txtBornDate.Enabled = txtIssueDate.Enabled = txtExpiryDate.Enabled = passenger.BornDate.HasValue;
        }

        private bool validateForm()
        {
            Control cntr = null;
            DateTime tempDate;//just to avoid syntax error
            erp.Clear();

            if (txtPassportNum.Text.Trim().Length != 8)
                cntr = txtPassportNum;
            else if (txtFullName.Text.Trim().Length < 3)
                cntr = txtFullName;
            else if (cmbGender.SelectedIndex == -1)
                cntr = cmbGender;
            else if (!Properties.Settings.Default.DatesDisabled && txtBornDate.Enabled)
                if (!DateTime.TryParse(txtBornDate.Text, out tempDate))
                    cntr = txtBornDate;
                else if (!DateTime.TryParse(txtIssueDate.Text, out tempDate))
                    cntr = txtIssueDate;
                else if (!DateTime.TryParse(txtExpiryDate.Text, out tempDate))
                    cntr = txtExpiryDate;

            if (cntr == null)
                return true;
            else
            {
                erp.SetError(cntr, "ورودی معتبر نیست!");
                cntr.Focus();
                return false;
            }//else
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
                        UserID = Properties.Settings.Default.User.ID
                    };

                    DateTime tempDate;
                    if (DateTime.TryParse(txtBornDate.Text, out tempDate))
                        p.BornDate = tempDate;
                    if (DateTime.TryParse(txtIssueDate.Text, out tempDate))
                        p.IssueDate = tempDate;
                    if (DateTime.TryParse(txtExpiryDate.Text, out tempDate))
                        p.ExpiryDate = tempDate;

                    p.Requests.Add(new Request
                    {
                        ShiftID = this.selectedShift.ID,
                        UserID = Properties.Settings.Default.User.ID,
                    });

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
                    DateTime tempDate;

                    if (DateTime.TryParse(txtBornDate.Text, out tempDate))
                        passenger.BornDate = tempDate;
                    if (DateTime.TryParse(txtIssueDate.Text, out tempDate))
                        passenger.IssueDate = tempDate;
                    if (DateTime.TryParse(txtExpiryDate.Text, out tempDate))
                        passenger.ExpiryDate = tempDate;

                    this.passenger.UserID = Properties.Settings.Default.User.ID;

                    sucMessage = "رکورد ویرایش شد";
                    lblStatusMsg.ForeColor = Color.DarkBlue;
                    lblStatusMsg.Text = string.Format("{0} ({1})", sucMessage, passenger.FullName);
                    if (!this.justEdit)
                        this.passenger.Requests.Add(new Request
                        {
                            ShiftID = this.selectedShift.ID,
                            UserID = Properties.Settings.Default.User.ID,
                        });
                }//else

                try
                {
                    ctx.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    if (ex.InnerException.InnerException.Message.Contains("AK_Date_PassengerID"))
                        new frmMsgBox(ex.ToString(), "متقاضی مورد نظر قبلاً در این روز ثبت شده.", MessageBoxButtons.OK, MsgBoxIcon.Stop).ShowDialog();
                    ctx= new VisaXEntities();
                }
                this.passenger = null;
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
            DateTime tempDate;
            if (DateTime.TryParse(txtIssueDate.Text, out tempDate))
                txtExpiryDate.Text = tempDate.AddYears(5).ToShortDateString();
        }

        private void txtPassportNum_TextChanged(object sender, EventArgs e)
        {
            if (txtPassportNum.Text.Length == 8 && this.passenger == null)
            {
                lblStatusMsg.Text = string.Empty;
                this.passenger = (from p in ctx.Passengers
                                  where p.PassportNum == txtPassportNum.Text
                                  select p).FirstOrDefault();
                if (this.passenger != null)
                {
                    txtBornDate.Enabled = txtIssueDate.Enabled = txtExpiryDate.Enabled = passenger.BornDate.HasValue;

                    txtFullName.Text = this.passenger.FullName;
                    txtPassportNum.Text = this.passenger.PassportNum;
                    cmbGender.SelectedIndex = this.passenger.Gender;
                    txtBornDate.Text = this.passenger.BornDate.HasValue ? this.passenger.BornDate.Value.ToShortDateString() : string.Empty;
                    txtIssueDate.Text = this.passenger.IssueDate.HasValue ? this.passenger.IssueDate.Value.ToShortDateString() : string.Empty;
                    txtExpiryDate.Text = this.passenger.ExpiryDate.HasValue ? this.passenger.ExpiryDate.Value.ToShortDateString() : string.Empty;
                }//if
            }//if
        }
    }
}
