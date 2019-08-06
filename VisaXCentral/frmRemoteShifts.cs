using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;

namespace VisaXCentral
{
    public partial class frmShifts : Form
    {
        VisaXCenterNew ctx = new VisaXCenterNew("ASAWARI");
        RemoteUser user;

        public frmShifts(RemoteUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void frmShifts_Load(object sender, EventArgs e)
        {
            Text = "شیفت های شعبه " + user.RealName;
            dtpFrom.Value = dtpTo.Value.AddMonths(-1);
            refreshGrid();
        }

        private void refreshGrid()
        {
            dgvShifts.DataSource = (from s in ctx.RemoteShifts
                                    where s.Date >= dtpFrom.Value.Date && s.Date <= dtpTo.Value
                                    && s.RemoteUserID == user.ID
                                    && s.Exported != chkJustNotPrinted.Checked
                                    select new
                                    {
                                        s.ID,
                                        s.Date,
                                        s.ShiftNum,
                                        s.RemoteRequests.Count,
                                        s.Description,
                                    }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void dgvPassengers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnExportPDF.Enabled = btnList.Enabled = dgvShifts.Rows.Count != 0;
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvPassengers_RowsRemoved(null, null);
        }

        public void rowColor()
        {
            for (int i = 0; i < dgvShifts.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvShifts.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void dgvShifts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvShifts.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            rowColor();
        }

        private void btnExportXls_Click(object sender, EventArgs e)
        {
            string absPath = Path.GetFullPath("./PassengerList.xls");

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Excel Documents (*.xls)|*.xls";

            FolderBrowserDialog sfd = new FolderBrowserDialog();
            sfd.SelectedPath = Properties.Settings.Default.ExportDestinationPath;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApllication = null;
                Excel.Workbook excelWorkBook = null;
                Excel.Worksheet excelWorkSheet = null;
                excelApllication = new Excel.Application();
                System.Threading.Thread.Sleep(2000);

                foreach (DataGridViewRow item in dgvShifts.SelectedRows)
                {
                    int shiftID = (int)item.Cells["colID"].Value;
                    RemoteShift selectedShift = ctx.RemoteShifts.Where(s => s.ID == shiftID).First<RemoteShift>();

                    excelWorkBook = excelApllication.Workbooks.Open(absPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                    int i = 1;
                    foreach (RemoteRequest r in selectedShift.RemoteRequests)
                    {
                        excelWorkSheet.Cells[i + 7, 8].Value = r.FullName;
                        excelWorkSheet.Cells[i + 7, 7].Value = r.PassportNum;
                        excelWorkSheet.Cells[i + 7, 6].Value2 = (byte)r.Gender == 0 ? "ذکر" : "انثی";

                        if (r.BornDate.HasValue)
                        {
                            excelWorkSheet.Cells[i + 7, 5].Value2 = r.BornDate;
                            excelWorkSheet.Cells[i + 7, 4].Value2 = r.IssueDate;
                            excelWorkSheet.Cells[i + 7, 3].Value2 = r.ExpiryDate;
                        }//if
                        i++;
                    }//foreach

                    string fileName = user.UserName + " - " + selectedShift.Date.ToString("yyyy-MM-dd") + string.Format(" ({0:00})", selectedShift.ShiftNum);
                    excelWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal);
                    selectedShift.Exported = true;
                }//foreach

                excelWorkBook.Close();
                excelApllication.Quit();
                Marshal.FinalReleaseComObject(excelWorkSheet);
                Marshal.FinalReleaseComObject(excelWorkBook);
                Marshal.FinalReleaseComObject(excelApllication);
                excelApllication = null;
                excelWorkSheet = null;

                //Opens the created Excel file
                Process.Start(sfd.SelectedPath);

                ctx.SaveChanges();
            }//if
        }

        private void dtpTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";

            int shiftID = (int)dgvShifts.SelectedRows[0].Cells["colID"].Value;
            RemoteShift selectedShift = ctx.RemoteShifts.Where(s => s.ID == shiftID).First<RemoteShift>();

            Boolean xlsToo = MessageBox.Show("آیا مایلید فایل اکسل هم تولید شود؟", "تولید همزمان اکسل", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes;
            List<string> files = new List<string>();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string dirPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\VisaX";
                Directory.CreateDirectory(dirPath);
                foreach (string file in Directory.GetFiles(dirPath))
                    File.Delete(file);

                List<RemoteRequest> reqList = selectedShift.RemoteRequests.ToList<RemoteRequest>();
                for (int i = 0; i < reqList.Count; i++)
                    files.Add(generatePdf(reqList[i], i + 1));

                MergePDFs(files, sfd.FileName);
                Process.Start(sfd.FileName);
                if (xlsToo)
                    btnExportXls_Click(null, null);
                this.refreshGrid();
            }//if
        }//btnExportPDF_Click

        private string generatePdf(RemoteRequest r, int fileNum)
        {
            //Path to source file
            String source = ".\\VisaForm.pdf";
            //Create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);

            //PdfStamper object to modify the content of the PDF
            string fullPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + String.Format("\\VisaX\\{0:00}.pdf", fileNum);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(fullPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            form.SetField("form1[0].#subform[0].#field[0]", r.FullName);
            //Radio for Gender
            form.SetField("form1[0].#subform[0].RadioButtonList[0]", (2 - r.Gender).ToString());
            form.SetField("form1[0].#subform[0].#field[4]", r.Gender == 1 ? "ربه بیت/خانه دار" : "کاسب/کارگر");
            form.SetField("form1[0].#subform[0].#field[8]", r.BornDate.HasValue ? r.BornDate.Value.Year.ToString() : string.Empty);
            form.SetField("form1[0].#subform[0].#field[5]", r.BornDate.HasValue ? r.BornDate.Value.Month.ToString("00") : string.Empty);
            form.SetField("form1[0].#subform[0].#field[6]", r.BornDate.HasValue ? r.BornDate.Value.Day.ToString("00") : string.Empty);
            form.SetField("form1[0].#subform[0].#field[21]", r.PassportNum);

            //Issue Date
            form.SetField("form1[0].#subform[0].#field[25]", r.IssueDate.HasValue ? r.IssueDate.Value.Year.ToString() : string.Empty);
            form.SetField("form1[0].#subform[0].#field[22]", r.IssueDate.HasValue ? r.IssueDate.Value.Month.ToString("00") : string.Empty);
            form.SetField("form1[0].#subform[0].#field[23]", r.IssueDate.HasValue ? r.IssueDate.Value.Day.ToString("00") : string.Empty);

            //Expiry Date
            form.SetField("form1[0].#subform[0].#field[30]", r.ExpiryDate.HasValue ? r.ExpiryDate.Value.Year.ToString() : string.Empty);
            form.SetField("form1[0].#subform[0].#field[27]", r.ExpiryDate.HasValue ? r.ExpiryDate.Value.Month.ToString() : string.Empty);//Month
            form.SetField("form1[0].#subform[0].#field[28]", r.ExpiryDate.HasValue ? r.ExpiryDate.Value.Day.ToString() : string.Empty); ;//Day

            stamp.Close();
            reader.Close();
            return fullPath;
        }

        public static bool MergePDFs(IEnumerable<string> fileNames, string targetPdf)
        {
            bool merged = true;
            using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
            {
                Document document = new Document();
                PdfCopy pdf = new PdfCopy(document, stream);
                PdfReader reader = null;
                try
                {
                    document.Open();
                    foreach (string file in fileNames)
                    {
                        reader = new PdfReader(file);
                        pdf.AddDocument(reader);
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    merged = false;
                    if (reader != null)
                        reader.Close();
                }
                finally
                {
                    if (document != null)
                        document.Close();
                }
            }
            return merged;
        }

        private void btnList_Click(object sender, EventArgs e)
        {

        }
    }

    public partial class VisaXCenterNew : DbContext
    {
        public VisaXCenterNew(string user, string pwd)
            : base("name=VisaXCenterNew")
        {
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, pwd);
        }

        public VisaXCenterNew(string user)
             : base("name=VisaXCenterNew")
        {
            if (user == "ASAWARI")
                Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, "3Pg^gf81");
        }
    }

}
