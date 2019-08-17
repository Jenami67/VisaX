using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VisaX
{
    public partial class frmRequests : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        Shift SelectedShift;
        SaveFileDialog sfd = new SaveFileDialog();

        public frmRequests()
        {
            InitializeComponent();
        }

        public frmRequests(Shift selectedShift) : this()
        {
            this.SelectedShift = selectedShift;
        }

        private void refreshGrid()
        {
            dgvPassengers.DataSource = (from r in ctx.Requests
                                        where r.ShiftID == SelectedShift.ID
                                        orderby r.ID
                                        select new
                                        {
                                            r.ID,
                                            r.PassengerID,
                                            r.Passenger.PassportNum,
                                            r.Passenger.FullName,
                                            r.Passenger.BornDate,
                                            r.Passenger.IssueDate,
                                            r.Passenger.ExpiryDate,
                                            r.Passenger.Gender
                                        }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvPassengers.DataSource = (from r in ctx.Requests
                                        where r.ShiftID == SelectedShift.ID
                                           && (r.Passenger.FullName.Contains(txtFilter.Text)
                                           || r.Passenger.PassportNum.Contains(txtFilter.Text))
                                        select new
                                        {
                                            r.ID,
                                            r.PassengerID,
                                            r.Passenger.PassportNum,
                                            r.Passenger.FullName,
                                            r.Passenger.BornDate,
                                            r.Passenger.IssueDate,
                                            r.Passenger.ExpiryDate
                                        }).ToList();
        }//btnSearch_Click

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = !SelectedShift.Sent;
            dgvPassengers_RowsRemoved(null, null);
            btnNew.Enabled = !SelectedShift.Sent;
            this.refreshGrid();
            this.Text = string.Format("متقاضیان ویزای تاریخ {0:yyyy/MM/dd} شیفت {1}", this.SelectedShift.Date, this.SelectedShift.ShiftNum);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selIndex = dgvPassengers.SelectedRows[0].Index;
            int id = (int)dgvPassengers.SelectedRows[0].Cells["colPassengerID"].Value;
            Passenger passenger = (from p in ctx.Passengers where p.ID == id select p).First();
            new frmAddPassenger(passenger, this.SelectedShift, true).ShowDialog();
            refreshGrid();

            dgvPassengers.ClearSelection();
            dgvPassengers.Rows[selIndex].Selected = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (new frmAddPassenger(this.SelectedShift).ShowDialog() == DialogResult.Cancel)
                refreshGrid();
            dgvPassengers.ClearSelection();
            if (dgvPassengers.RowCount > 0)
                dgvPassengers.Rows[dgvPassengers.RowCount - 1].Selected = true;
        }

        public void rowColor()
        {
            for (int i = 0; i < dgvPassengers.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvPassengers.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string absPath = Path.GetFullPath("./PassengerList.xls");

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = this.SelectedShift.Date.ToString("yyyy-MM-dd") + string.Format(" ({0:00})", this.SelectedShift.ShiftNum);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApllication = null;
                Excel.Workbook excelWorkBook = null;
                Excel.Worksheet excelWorkSheet = null;

                excelApllication = new Excel.Application();
                System.Threading.Thread.Sleep(2000);
                excelWorkBook = excelApllication.Workbooks.Open(absPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                //Fill Header
                excelWorkSheet.Cells[2, 2].Value2 = SelectedShift.Requests.Count;
                excelWorkSheet.Cells[2, 3].Value2 = DateTime.Now.Date;
                excelWorkSheet.Cells[2, 5].Value2 = SelectedShift.Date;
                excelWorkSheet.Cells[2, 7].Value2 = Properties.Settings.Default.RemoteUser.RealName;
                excelWorkSheet.Cells[2, 8].Value2 = SelectedShift.Description;

                int i = 1;
                if (sender == btnExportPDFAll)
                    foreach (DataGridViewRow row in dgvPassengers.Rows)
                    {
                        excelWorkSheet.Cells[i + 7, 8].Value = row.Cells["colFullName"].Value;
                        excelWorkSheet.Cells[i + 7, 7].Value = row.Cells["colPassportNum"].Value;
                        excelWorkSheet.Cells[i + 7, 6].Value2 = (byte)row.Cells["colGender"].Value == 0 ? "ذکر" : "انثی";

                        //format error: Exception from HRESULT: 0x800A03EC
                        excelWorkSheet.Cells[i + 7, 5].Value2 = row.Cells["colBornDate"].Value;
                        excelWorkSheet.Cells[i + 7, 4].Value2 = row.Cells["colIssueDate"].Value;
                        excelWorkSheet.Cells[i + 7, 3].Value2 = row.Cells["colExpiryDate"].Value;
                        i++;
                    }//foreach
                else
                {
                    List<DataGridViewRow> rows =
                        (from DataGridViewRow row in dgvPassengers.SelectedRows
                         where !row.IsNewRow
                         orderby row.Index
                         select row).ToList<DataGridViewRow>();

                    foreach (DataGridViewRow row in rows)
                    {
                        excelWorkSheet.Cells[i + 7, 8].Value = row.Cells["colFullName"].Value;
                        excelWorkSheet.Cells[i + 7, 7].Value = row.Cells["colPassportNum"].Value;
                        excelWorkSheet.Cells[i + 7, 6].Value2 = (byte)row.Cells["colGender"].Value == 0 ? "ذکر" : "انثی";

                        //format error: Exception from HRESULT: 0x800A03EC
                        excelWorkSheet.Cells[i + 7, 5].Value2 = row.Cells["colBornDate"].Value;
                        excelWorkSheet.Cells[i + 7, 4].Value2 = row.Cells["colIssueDate"].Value;
                        excelWorkSheet.Cells[i + 7, 3].Value2 = row.Cells["colExpiryDate"].Value;
                        i++;
                    }
                }//else
                excelWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal);
                excelWorkBook.Close();
                excelApllication.Quit();
                Marshal.FinalReleaseComObject(excelWorkSheet);
                Marshal.FinalReleaseComObject(excelWorkBook);
                Marshal.FinalReleaseComObject(excelApllication);
                excelApllication = null;
                excelWorkSheet = null;

                //Opens the created Excel file
                Process.Start(sfd.FileName);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";
            sfd.FileName = this.SelectedShift.Date.ToString("yyyy-MM-dd") + string.Format(" ({0:00})", this.SelectedShift.ShiftNum);

            Boolean xlsToo = MessageBox.Show("آیا مایلید فایل اکسل رکوردهای انتخاب شده هم تولید شود؟", "تولید همزمان اکسل", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes;
            List<string> files = new List<string>();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string dirPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\VisaX";
                Directory.CreateDirectory(dirPath);
                foreach (string file in Directory.GetFiles(dirPath))
                    File.Delete(file);

                if (sender == btnExportPDFAll)
                    for (int i = 0; i < dgvPassengers.Rows.Count; i++)
                        files.Add(generatePdf(dgvPassengers.Rows[i], i + 1));
                else //if selected
                {
                    List<DataGridViewRow> rows =
                         (from DataGridViewRow row in dgvPassengers.SelectedRows
                          where !row.IsNewRow
                          orderby row.Index
                          select row).ToList<DataGridViewRow>();

                    for (int i = 0; i < rows.Count; i++)
                        files.Add(generatePdf(rows[i], i + 1));
                }//else

                MergePDFs(files, sfd.FileName);
                Process.Start(sfd.FileName);
                if (xlsToo)
                    btnExportExcel_Click(sender, null);
                this.refreshGrid();
            }//if
        }//btnExportPDF_Click

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void dgvPassengers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnHistory.Enabled = dgvPassengers.Rows.Count > 0;

            btnDelete.Enabled = btnEdit.Enabled  =
                dgvPassengers.Rows.Count > 0 && !SelectedShift.Sent;

            btnExportExcel.Enabled = btnExportPDF.Enabled = btnExportPDFAll.Enabled =
                dgvPassengers.Rows.Count > 0 && SelectedShift.Sent;
            btnNew.Enabled = !SelectedShift.Sent;
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvPassengers_RowsRemoved(null, null);
        }

        private void llbSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private string generatePdf(DataGridViewRow r, int fileNum)
        {
            //Path to source file
            String source = ".\\VisaForm.pdf";
            //Create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);

            //PdfStamper object to modify the content of the PDF
            string fullPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + String.Format("\\VisaX\\{0:00}.pdf", fileNum);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(fullPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            Passenger p = new Passenger
            {
                FullName = r.Cells["colFullName"].Value.ToString(),
                BornDate = (DateTime?)r.Cells["colBornDate"].Value,
                ExpiryDate = (DateTime?)r.Cells["colExpiryDate"].Value,
                IssueDate = (DateTime?)r.Cells["colIssueDate"].Value,
                Gender = (byte)r.Cells["colGender"].Value,
                ID = (int)r.Cells["colPassengerID"].Value,
                PassportNum = r.Cells["colPassportNum"].Value.ToString()
            };

            form.SetField("form1[0].#subform[0].#field[0]", p.FullName);
            //Radio for Gender
            form.SetField("form1[0].#subform[0].RadioButtonList[0]", (2 - p.Gender).ToString());
            form.SetField("form1[0].#subform[0].#field[4]", p.Gender == 1 ? "ربه بیت/خانه دار" : "کاسب/کارگر");
            form.SetField("form1[0].#subform[0].#field[8]", p.BornDate.HasValue ? p.BornDate.Value.Year.ToString() : string.Empty);
            form.SetField("form1[0].#subform[0].#field[5]", p.BornDate.HasValue ? p.BornDate.Value.Month.ToString("00") : string.Empty);
            form.SetField("form1[0].#subform[0].#field[6]", p.BornDate.HasValue ? p.BornDate.Value.Day.ToString("00") : string.Empty);
            form.SetField("form1[0].#subform[0].#field[21]", p.PassportNum);

            //Issue Date
            form.SetField("form1[0].#subform[0].#field[25]", p.IssueDate.HasValue ? p.IssueDate.Value.Year.ToString() : string.Empty);
            form.SetField("form1[0].#subform[0].#field[22]", p.IssueDate.HasValue ? p.IssueDate.Value.Month.ToString("00") : string.Empty);
            form.SetField("form1[0].#subform[0].#field[23]", p.IssueDate.HasValue ? p.IssueDate.Value.Day.ToString("00") : string.Empty);

            //Expiry Date
            form.SetField("form1[0].#subform[0].#field[30]", p.ExpiryDate.HasValue ? p.ExpiryDate.Value.Year.ToString() : string.Empty);
            form.SetField("form1[0].#subform[0].#field[27]", p.ExpiryDate.HasValue ? p.ExpiryDate.Value.Month.ToString() : string.Empty);//Month
            form.SetField("form1[0].#subform[0].#field[28]", p.ExpiryDate.HasValue ? p.ExpiryDate.Value.Day.ToString() : string.Empty); ;//Day

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

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnNew_Click(null, null);
                    break;
                case Keys.F3:
                    txtFilter.Focus();
                    break;
                case Keys.F4:
                    btnEdit_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)dgvPassengers.SelectedRows[0].Cells["colRequestID"].Value;
            Request req = (from p in ctx.Requests where p.ID == id select p).First();
            if (MessageBox.Show("آیا مایل به حذف این درخواست هستید؟", req.Passenger.FullName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctx.Requests.Remove(req);
                ctx.SaveChanges();
                refreshGrid();
            }//if
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            int id = (int)dgvPassengers.SelectedRows[0].Cells["colPassengerID"].Value;
            Passenger p = (from ps in ctx.Passengers where ps.ID == id select ps).First();
            new frmHistory(p).ShowDialog();
        }

        private void dgvPassengers_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPassengers.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            this.rowColor();
        }

        private void dgvPassengers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void frmRequests_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Control && !SelectedShift.Sent)
                btnNew_Click(null, null);
            if (e.KeyCode == Keys.E && e.Control && btnEdit.Enabled)
                btnEdit_Click(null, null);
            if (e.KeyCode == Keys.D && e.Control && btnDelete.Enabled)
                btnDelete_Click(null, null);

            if (e.KeyCode == Keys.P && e.Control && SelectedShift.Sent)
                btnExportPDF_Click(btnExportPDFAll, null);
            if (e.KeyCode == Keys.P && e.Control && e.Shift && SelectedShift.Sent)
                btnExportPDF_Click(null, null);
            if (e.KeyCode == Keys.X && e.Control && SelectedShift.Sent)
                btnExportExcel_Click(null, null);

            if (e.KeyCode == Keys.H && e.Control && btnHistory.Enabled)
                btnHistory_Click(null, null);
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}