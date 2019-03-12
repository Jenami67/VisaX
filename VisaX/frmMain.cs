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

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvPassengers.AutoGenerateColumns = false;
            rbToday_CheckedChanged(null, null);
            // dgvPassengers.DataSource = (from p in ctx.Passengers where p.EntryDate == DateTime.Today select p).ToList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddPassenger frmAddPassenger = new frmAddPassenger((Passenger)dgvPassengers.CurrentRow.DataBoundItem);
            if (frmAddPassenger.ShowDialog() == DialogResult.OK)
                frmMain_Load(null, null);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //frmAddPassenger frmAddPassenger = new frmAddPassenger();
            //frmAddPassenger.ShowDialog();
            //if (frmAddPassenger.DialogResult == DialogResult.OK)
            //    frmMain_Load(null, null);

            // new frmAddPassenger().ShowDialog();
            if (new frmAddPassenger().ShowDialog() == DialogResult.Cancel)
                frmMain_Load(null, null);

            //    new frmAddPassenger().ShowDialog();
            //else
            //    frmMain_Load(null, null);
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

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Visa_Export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApllication = null;
                Excel.Workbook excelWorkBook = null;
                Excel.Worksheet excelWorkSheet = null;

                excelApllication = new Excel.Application();
                System.Threading.Thread.Sleep(2000);
                excelWorkBook = excelApllication.Workbooks.Open(absPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                //for (int i = MinIndex() + 1; i <= dgvPassengers.SelectedRows.Count; i++)
                //{
                //    excelWorkSheet.Cells[i + 7, 8].Value = dgvPassengers[1, i - 1].Value;
                //    excelWorkSheet.Cells[i + 7, 7].Value = dgvPassengers[2, i - 1].Value;
                //    excelWorkSheet.Cells[i + 7, 6].Value2 = (byte)dgvPassengers[6, i - 1].Value == 0 ? "ذکر" : "انثی";

                //    //format error: Exception from HRESULT: 0x800A03EC
                //    excelWorkSheet.Cells[i + 7, 5].Value2 = dgvPassengers[3, i - 1].Value;
                //    excelWorkSheet.Cells[i + 7, 4].Value2 = dgvPassengers[4, i - 1].Value;
                //    excelWorkSheet.Cells[i + 7, 3].Value2 = dgvPassengers[5, i - 1].Value;
                //}//for

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
            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";
            sfd.FileName = "VisaApply.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
                for (int i = 0; i < dgvPassengers.SelectedRows.Count; i++)
                    generatePdf(dgvPassengers.SelectedRows[i], i + 1);
            if (dgvPassengers.SelectedRows.Count > 1)
                Process.Start(Path.GetDirectoryName(sfd.FileName));
            else
                Process.Start(sfd.FileName.Insert(sfd.FileName.LastIndexOf(".pdf"), string.Format(" - {0:00}", 1)));
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
            btnNew.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnExportExcel.Enabled = btnExportPDF.Enabled =
                dgvPassengers.Rows.Count != 0;
        }

        private void dgvPassengers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnNew.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnExportExcel.Enabled = btnExportPDF.Enabled =
                dgvPassengers.Rows.Count != 0;
        }

        private void llbSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private int MinIndex()
        {
            int min = int.MaxValue;
            foreach (DataGridViewRow r in dgvPassengers.SelectedRows)
                if (min > r.Index)
                    min = r.Index;
            return min;
        }

        private void generatePdf(DataGridViewRow r, int i)
        {
            //Path to source file
            String source = ".\\VisaForm.pdf";
            //Create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);

            //PdfStamper object to modify the content of the PDF
            string fullPath = sfd.FileName.Insert(sfd.FileName.LastIndexOf(".pdf"), string.Format(" - {0:00}", i));
            PdfStamper stamp = new PdfStamper(reader, new FileStream(fullPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;
            // stamp.FormFlattening = true;
            //form.GenerateAppearances = true;
            //stamp.FormFlattening = true;
            Passenger p = (Passenger)r.DataBoundItem;
            //form.
            //  form.SetField("form1[0].#subform[0].#field[0]", "کفتا");
            // form.SetField("form1[0].#subform[0].#field[0]", string.Format("{0} {1} {2}", p.Name, p.Father, p.Family));
            // form.SetFieldProperty("form1[0].#subform[0].#field[0]", "setfflags", PdfFormField.FF_READ_ONLY, null);
            form.SetField("form1[0].#subform[0].#field[0]", p.FullName);
            //form.SetField("form1[0].#subform[0].#field[1]", "اسلام");
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
            //form.SetFieldProperty("form1[0].#subform[0].#field[0]", "bgcolor", iTextSharp.text.BaseColor.BLACK, null);

            stamp.Close();
            reader.Close();
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

        private void frmMain_Enter(object sender, EventArgs e)
        {
            this.rowColor();
        }

        private void rbToday_CheckedChanged(object sender, EventArgs e)
        {
            if (rbToday.Checked)
                dgvPassengers.DataSource = (from p in ctx.Passengers where p.EntryDate == DateTime.Today select p).ToList();
            else
                dgvPassengers.DataSource = (from p in ctx.Passengers select p).ToList();
        }
    }
}

//-Add Shortcuts
//Export by day - grid just current day or one day
//pdf in one page
//-passport num in first to check if exist
//-auto expiry date
//-login password

