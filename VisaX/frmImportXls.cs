using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace VisaX
{
    public partial class frmImportXls : Form
    {
        public frmImportXls()
        {
            InitializeComponent();
        }

        private void btnImportPDF_Click(object sender, EventArgs e)
        {
            pb.Visible = true;
            bgw.RunWorkerAsync();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
                txtFileName.Text = fbd.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgw.CancelAsync();
            DialogResult = DialogResult.Cancel;
        }

        private void import()
        {
            int invalidDates = 0;
            if (txtFileName.Text == string.Empty)
            {
                MessageBox.Show("ابتدا پوشه حاوی فایل های اکسل را انتخاب کنید.", "وارد کردن متقاضیان به دیتابیس", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                btnBrowse_Click(null, null);
            }//if

            List<Passenger> allPassengers = new List<Passenger>();
            DirectoryInfo info = new DirectoryInfo(txtFileName.Text);
            var files = info.GetFiles("*.xls");

            Excel.Application excelApllication = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;
            excelApllication = new Excel.Application();
            System.Threading.Thread.Sleep(2000);
            double fileNum = 0;
            foreach (var file in files)
            {
                fileNum++;
                excelWorkBook = excelApllication.Workbooks.Open(file.FullName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
                int rowNum = 1;
                while (excelWorkSheet.Cells[rowNum + 7, 8].Value != null)
                {
                    string passportNum = excelWorkSheet.Cells[rowNum + 7, 7].Value.ToString();
                    if (allPassengers.Select(r => r.PassportNum).Contains(passportNum) || passportNum.Length != 8)
                    {

                        rowNum++;
                        continue;
                    }//if

                    Passenger p = new Passenger()
                    {
                        PassportNum = passportNum,
                        FullName = excelWorkSheet.Cells[rowNum + 7, 8].Value,
                        Gender = (byte)(excelWorkSheet.Cells[rowNum + 7, 6].Value2 == "ذکر" ? 0 : 1),
                        UserID = Properties.Settings.Default.User.ID
                    };

                    if (excelWorkSheet.Cells[rowNum + 7, 5].Value != null)
                    {
                        var bornDate = excelWorkSheet.Cells[rowNum + 7, 5].Value2;
                        var issueDate = excelWorkSheet.Cells[rowNum + 7, 4].Value2;
                        var expiryDate = excelWorkSheet.Cells[rowNum + 7, 3].Value2;

                        if (bornDate is double && issueDate is double && expiryDate is double)
                        {
                            p.BornDate = DateTime.FromOADate(bornDate);
                            p.IssueDate = DateTime.FromOADate(issueDate);
                            p.ExpiryDate = DateTime.FromOADate(expiryDate);
                        }//if
                        else
                            invalidDates++;
                    }//if

                    allPassengers.Add(p);
                    rowNum++;
                }//while
                int pr = (int)(fileNum / files.Count() * 100);
                bgw.ReportProgress(pr);
            }//foreach

            excelWorkBook.Close();
            excelApllication.Quit();
            Marshal.FinalReleaseComObject(excelWorkSheet);
            Marshal.FinalReleaseComObject(excelWorkBook);
            Marshal.FinalReleaseComObject(excelApllication);
            excelApllication = null;
            excelWorkSheet = null;

            VisaXEntities ctx = new VisaXEntities();
            var dbPassengers = ctx.Passengers.Select(pp => pp.PassportNum).ToList();
            var uniquePassengers = new List<Passenger>();

            foreach (var p in allPassengers)
                if (!dbPassengers.Contains(p.PassportNum))
                    uniquePassengers.Add(p);

            if (uniquePassengers.Count == 0)
            {
                MessageBox.Show("هیچ رکورد جدیدِی برای وارد کردن وجود ندارد.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }//if

            StringBuilder msg = new StringBuilder();
            msg.AppendLine("تعداد رکوردهای با تاریخ نامعتبر " + invalidDates.ToString());
            msg.AppendLine((allPassengers.Count - uniquePassengers.Count) > 0 ? string.Format("تعداد {0} متقاضی قبلا وارد شده اند.\n", allPassengers.Count - uniquePassengers.Count) : "");
            foreach (var p in uniquePassengers)
                msg.AppendLine(string.Format("- {0}\t ش.پ: {1}", p.FullName, p.PassportNum));

            if (new frmMsgBox(msg.ToString(), " متقاضیانی که وارد خواهند شد به شرح ذیل هستند؛ آیا مایل به وارد کردن آنها هستید؟", MessageBoxButtons.YesNo, MsgBoxIcon.Question).ShowDialog() == DialogResult.Yes)
            {
                ctx.Passengers.AddRange(uniquePassengers);
                ctx.SaveChanges();
            }//if

            Properties.Settings.Default.Save();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            import();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (bgw.IsBusy)
            //    busyState();
            pb.Value = e.ProgressPercentage;
        }

        private void initialState()
        {
            btnBrowse.Enabled = true;
            btnExportPDF.Enabled = true;
            pb.Visible = true;
        }

        private void busyState()
        {
            btnBrowse.Enabled = false;
            btnExportPDF.Enabled = false;
            pb.Visible = false;
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // initialState();
        }
    }
}

