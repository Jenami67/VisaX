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

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == string.Empty)
            {
                MessageBox.Show("ابتدا فایل اکسل را انتخاب کنید");
                btnBrowse_Click(null, null);
            }//if

            string path = txtFileName.Text;

            if (true)
            {
                Excel.Application excelApllication = null;
                Excel.Workbook excelWorkBook = null;
                Excel.Worksheet excelWorkSheet = null;

                excelApllication = new Excel.Application();
                System.Threading.Thread.Sleep(2000);
                excelWorkBook = excelApllication.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                List<Passenger> rr = new List<Passenger>();
                int i = 1;
                while (excelWorkSheet.Cells[i + 7, 8].Value != null)
                {
                    rr.Add(new Passenger());
                    rr[i - 1].FullName = excelWorkSheet.Cells[i + 7, 8].Value;
                    rr[i - 1].PassportNum = excelWorkSheet.Cells[i + 7, 7].Value.ToString();
                    rr[i - 1].Gender = (byte)(excelWorkSheet.Cells[i + 7, 6].Value2 == "ذکر" ? 0 : 1);
                    rr[i - 1].UserID = Properties.Settings.Default.User.ID; 
                    //format error: Exception from HRESULT: 0x800A03EC
                    if (excelWorkSheet.Cells[i + 7, 5].Value != null)
                    {
                        rr[i - 1].BornDate = DateTime.FromOADate(excelWorkSheet.Cells[i + 7, 5].Value2);
                        rr[i - 1].IssueDate = DateTime.FromOADate(excelWorkSheet.Cells[i + 7, 4].Value2);
                        rr[i - 1].ExpiryDate = DateTime.FromOADate(excelWorkSheet.Cells[i + 7, 3].Value2);
                    }//if
                    i++;
                }//while

                excelWorkBook.Close();
                excelApllication.Quit();
                Marshal.FinalReleaseComObject(excelWorkSheet);
                Marshal.FinalReleaseComObject(excelWorkBook);
                Marshal.FinalReleaseComObject(excelApllication);
                excelApllication = null;
                excelWorkSheet = null;

                VisaXEntities ctx = new VisaXEntities();
                var passNums = ctx.Passengers.Select(p => p.PassportNum);
                var uniquePassengers = new List<Passenger>();
                foreach (var p in rr)
                    if (!passNums.Contains(p.PassportNum))
                        uniquePassengers.Add(p);
                if (uniquePassengers.Count == 0)
                {
                    MessageBox.Show("هیچ رکورد جدیدِی برای وارد کردن وجود ندارد.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    return;
                }

                StringBuilder msg = new StringBuilder();
                msg.Append(rr.Count - uniquePassengers.Count > 0 ? string.Format("تعداد {0} متقاضی قبلا وارد شده اند.\n", rr.Count - uniquePassengers.Count) : "");
                msg.Append(" متقاضیانی که وارد خواهند شد به شرح ذیل هستند:\n");
                foreach (var p in uniquePassengers)
                    msg.AppendLine(string.Format("- {0}\t ش.پ: {1}", p.FullName, p.PassportNum));
                msg.AppendLine("آیا مایل به وارد کردن آنها هستید؟");
                if (MessageBox.Show(msg.ToString(), "وارد کردن متقاضیان به دیتابیس", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    ctx.Passengers.AddRange(uniquePassengers);
                    ctx.SaveChanges();
                }//if
            }//if
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                txtFileName.Text = ofd.FileName;
        }
    }
}

