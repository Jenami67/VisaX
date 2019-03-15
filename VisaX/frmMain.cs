using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VisaX
{
    public partial class frmMain : Form
    {
        VisaXEntities ctx = new VisaXEntities();
        SaveFileDialog sfd = new SaveFileDialog();

        public frmMain()
        {
            InitializeComponent();
        }

        private void refreshGrid()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            dgvPassengers.AutoGenerateColumns = false;
            if (chkNotPrinted.Checked)
                if (rbToday.Checked)
                    dgvPassengers.DataSource = (from p in ctx.Passengers where p.EntryDate == DateTime.Today && p.Printed == false select p).ToList();
                else if (rbYesterday.Checked)
                    dgvPassengers.DataSource = (from p in ctx.Passengers where p.EntryDate == yesterday && p.Printed == false select p).ToList();
                else
                    dgvPassengers.DataSource = (from p in ctx.Passengers where p.Printed == false select p).ToList();
            else
            {
                if (rbToday.Checked)
                    dgvPassengers.DataSource = (from p in ctx.Passengers where p.EntryDate == DateTime.Today select p).ToList();
                else if (rbYesterday.Checked)
                    dgvPassengers.DataSource = (from p in ctx.Passengers where p.EntryDate == yesterday select p).ToList();
                else
                    dgvPassengers.DataSource = (from p in ctx.Passengers select p).ToList();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.refreshGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new frmAddPassenger((Passenger)dgvPassengers.CurrentRow.DataBoundItem, this.ctx).ShowDialog();
            this.refreshGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (new frmAddPassenger(ctx).ShowDialog() == DialogResult.Cancel)
                refreshGrid();
        }

        public void rowColor()
        {
            for (int i = 0; i < dgvPassengers.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvPassengers.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string path = "./PassengerList.xls";
            string absPath = Path.GetFullPath(path);

            Statistic st = (from s in ctx.Statistics where s.Day == DateTime.Today select s).FirstOrDefault();
            if (st != null)
                st.Times++;
            else
            {
                st = new Statistic { Day = DateTime.Today, Times = 1 };
                ctx.Statistics.Add(st);
            }
            ctx.SaveChanges();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = DateTime.Today.ToString("yyyy-MM-dd") + string.Format("({0:00})", st.Times);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApllication = null;
                Excel.Workbook excelWorkBook = null;
                Excel.Worksheet excelWorkSheet = null;

                excelApllication = new Excel.Application();
                System.Threading.Thread.Sleep(2000);
                excelWorkBook = excelApllication.Workbooks.Open(absPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                int i = 1;
                foreach (DataGridViewRow row in dgvPassengers.SelectedRows)
                {
                    excelWorkSheet.Cells[i + 7, 8].Value = row.Cells[1].Value;
                    excelWorkSheet.Cells[i + 7, 7].Value = row.Cells[2].Value;
                    excelWorkSheet.Cells[i + 7, 6].Value2 = (byte)row.Cells[6].Value == 0 ? "ذکر" : "انثی";

                    //format error: Exception from HRESULT: 0x800A03EC
                    excelWorkSheet.Cells[i + 7, 5].Value2 = row.Cells[3].Value;
                    excelWorkSheet.Cells[i + 7, 4].Value2 = row.Cells[4].Value;
                    excelWorkSheet.Cells[i + 7, 3].Value2 = row.Cells[5].Value;
                    i++;
                }

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
            //Statistic st = (from s in ctx.Statistics where s.Day == DateTime.Today select s).FirstOrDefault();
            //if (st != null)
            //    st.Times++;
            //else
            //{
            //    st = new Statistic { Day = DateTime.Today, Times = 1, xlsTimes=1 };
            //    ctx.Statistics.Add(st);
            //}
            //ctx.SaveChanges();

            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";
            sfd.FileName = DateTime.Today.ToString("yyyy-MM-dd"); //+ string.Format("({0:00})", st.Times);

            Boolean xlsToo = MessageBox.Show("آیا مایل فایل اکسل رکوردهای انتخاب شده هم تولید شود؟", "تولید همزمان اکسل", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes;
            List<string> files = new List<string>();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in Directory.GetFiles(Path.GetTempPath() + "VisaX"))
                    File.Delete(file);
                Directory.CreateDirectory(Path.GetTempPath() + "VisaX");

                for (int i = 0; i < dgvPassengers.SelectedRows.Count; i++)
                {
                    files.Add(generatePdf(dgvPassengers.SelectedRows[i], i + 1));
                    ((Passenger)dgvPassengers.SelectedRows[i].DataBoundItem).Printed = true;
                }//for
                MergePDFs(files, sfd.FileName);
                ctx.SaveChanges();
                Process.Start(sfd.FileName);
                if (xlsToo)
                    btnExportExcel_Click(null, null);
                this.refreshGrid();
            }//if
        }//btnExportPDF_Click

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbToday.Checked)
                dgvPassengers.DataSource = (from p in ctx.Passengers
                                            where (p.FullName.Contains(txtFilter.Text)
                                                || p.PassportNum.Contains(txtFilter.Text)) && p.EntryDate == DateTime.Today
                                            select p).ToList();
            else
                dgvPassengers.DataSource = (from p in ctx.Passengers
                                            where p.FullName.Contains(txtFilter.Text)
                                               || p.PassportNum.Contains(txtFilter.Text)
                                            select p).ToList();
        }//btnSearch_Click

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void dgvPassengers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = btnExportExcel.Enabled = btnExportPDF.Enabled =
               dgvPassengers.Rows.Count != 0;
            this.rowColor();
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = btnExportExcel.Enabled = btnExportPDF.Enabled =
               dgvPassengers.Rows.Count != 0;
            this.rowColor();
        }

        private void llbSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private string generatePdf(DataGridViewRow r, int i)
        {
            //Path to source file
            String source = ".\\VisaForm.pdf";
            //Create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);

            //PdfStamper object to modify the content of the PDF
            string fullPath = Path.GetTempPath() + String.Format("VisaX\\{0:00}.pdf", i);
            PdfStamper stamp = new PdfStamper(reader, new FileStream(fullPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;
            // stamp.FormFlattening = true;
            //form.GenerateAppearances = true;
            //stamp.FormFlattening = true;
            Passenger p = (Passenger)r.DataBoundItem;
            form.SetField("form1[0].#subform[0].#field[0]", p.FullName);
            //Radio for Gender
            form.SetField("form1[0].#subform[0].RadioButtonList[0]", (2 - p.Gender).ToString());
            //form.SetField("form1[0].#subform[0].#field[2]", "ایرانیه");
            //form.SetField("form1[0].#subform[0].#field[3]", "ایرانیه");
            //form.SetField("form1[0].#subform[0].#field[9]", "ایران");
            form.SetField("form1[0].#subform[0].#field[8]", p.BornDate.Year.ToString());
            form.SetField("form1[0].#subform[0].#field[5]", p.BornDate.Month.ToString("00"));
            form.SetField("form1[0].#subform[0].#field[6]", p.BornDate.Day.ToString("00"));
            form.SetField("form1[0].#subform[0].#field[21]", p.PassportNum);

            //Issue Date
            form.SetField("form1[0].#subform[0].#field[25]", p.IssueDate.Year.ToString());
            form.SetField("form1[0].#subform[0].#field[22]", p.IssueDate.Month.ToString("00"));
            form.SetField("form1[0].#subform[0].#field[23]", p.IssueDate.Day.ToString("00"));

            //Expiry Date
            form.SetField("form1[0].#subform[0].#field[30]", p.ExpiryDate.Year.ToString());
            form.SetField("form1[0].#subform[0].#field[27]", p.ExpiryDate.Month.ToString("00"));//Month
            form.SetField("form1[0].#subform[0].#field[28]", p.ExpiryDate.Day.ToString("00"));//Day
            //form.SetFieldProperty("form1[0].#subform[0].#field[0]", "textcolor", iTextSharp.text.BaseColor.RED, null);

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
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    if (document != null)
                    {
                        document.Close();
                    }
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

        private void rbToday_CheckedChanged(object sender, EventArgs e)
        {
            this.refreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Passenger p = (Passenger)dgvPassengers.CurrentRow.DataBoundItem;
            if (MessageBox.Show("آیا مایل به حذف این رکورد هستید؟", p.FullName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctx.Passengers.Remove(p);
                ctx.SaveChanges();
                refreshGrid();
            }//if
        }

        private void chkNotPrinted_CheckedChanged(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void rbYesterday_CheckedChanged(object sender, EventArgs e)
        {
            this.refreshGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
//TODO: 
//-Add Shortcuts
//-Export by day - grid just current day or one day
//-pdf in one page
//-passport num in first to check if exist
//-auto expiry date
//-login password
