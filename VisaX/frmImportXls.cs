using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

            foreach (var file in files)
            {
                string path = file.FullName;

                excelWorkBook = excelApllication.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                int i = 1;
                while (excelWorkSheet.Cells[i + 7, 8].Value != null)
                {
                    string passportNum = excelWorkSheet.Cells[i + 7, 7].Value.ToString();
                    if (allPassengers.Select(r => r.PassportNum).Contains(passportNum))
                    {
                        i++;
                        continue;
                    }//if

                    Passenger p = new Passenger()
                    {
                        FullName = excelWorkSheet.Cells[i + 7, 8].Value,
                        PassportNum = excelWorkSheet.Cells[i + 7, 7].Value.ToString(),
                        Gender = (byte)(excelWorkSheet.Cells[i + 7, 6].Value2 == "ذکر" ? 0 : 1),
                        UserID = Properties.Settings.Default.User.ID
                    };

                    if (excelWorkSheet.Cells[i + 7, 5].Value != null)
                    {
                        p.BornDate = DateTime.FromOADate(excelWorkSheet.Cells[i + 7, 5].Value2);
                        p.IssueDate = DateTime.FromOADate(excelWorkSheet.Cells[i + 7, 4].Value2);
                        p.ExpiryDate = DateTime.FromOADate(excelWorkSheet.Cells[i + 7, 3].Value2);
                    }//if

                    allPassengers.Add(p);
                    i++;
                }//while
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
            msg.Append(allPassengers.Count - uniquePassengers.Count > 0 ? string.Format("تعداد {0} متقاضی قبلا وارد شده اند.\n", allPassengers.Count - uniquePassengers.Count) : "");
            msg.Append(" متقاضیانی که وارد خواهند شد به شرح ذیل هستند:\n");
            foreach (var p in uniquePassengers)
                msg.AppendLine(string.Format("- {0}\t ش.پ: {1}", p.FullName, p.PassportNum));
            msg.AppendLine("آیا مایل به وارد کردن آنها هستید؟");

            if (new frmMsgBox(msg.ToString(), "وارد کردن متقاضیان به دیتابیس", MessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
                MessageBox.Show("Test");

            if (MessageBox.Show(msg.ToString(), "وارد کردن متقاضیان به دیتابیس", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctx.Passengers.AddRange(uniquePassengers);
                ctx.SaveChanges();
            }//if
            Properties.Settings.Default.Save();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
                txtFileName.Text = fbd.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

