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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvPassengers.AutoGenerateColumns = false;
            dgvPassengers.DataSource = (from p in ctx.Passengers select p).ToList();
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

            if (new frmAddPassenger().ShowDialog() == DialogResult.OK)
                frmMain_Load(null, null);
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

                for (int i = MinIndex(); i < dgvPassengers.SelectedRows.Count; i++)
                {
                    excelWorkSheet.Cells[i + 8, 8].Value = string.Format("{0} {1} {2}", dgvPassengers[1, i].Value, dgvPassengers[3, i].Value, dgvPassengers[2, i].Value);
                    excelWorkSheet.Cells[i + 8, 7].Value = dgvPassengers[4, i].Value;
                    excelWorkSheet.Cells[i + 8, 6].Value2 = (byte)dgvPassengers[8, i].Value == 0 ? "ذکر" : "انثی";

                    //format error: Exception from HRESULT: 0x800A03EC
                    excelWorkSheet.Cells[i + 8, 5].Value2 = dgvPassengers[5, i].Value;
                    excelWorkSheet.Cells[i + 8, 4].Value2 = dgvPassengers[6, i].Value;
                    excelWorkSheet.Cells[i + 8, 3].Value2 = dgvPassengers[7, i].Value;
                }//for

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
            // path to source file
            String source = ".\\VisaForm.pdf";
            //create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";
            sfd.FileName = "VisaApply.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //PdfStamper object to modify the content of the PDF
                PdfStamper stamp = new PdfStamper(reader, new FileStream(sfd.FileName, FileMode.Create));
                AcroFields form = stamp.AcroFields;

                Passenger p = (Passenger)dgvPassengers.CurrentRow.DataBoundItem;
                form.SetField("form1[0].#subform[0].#field[0]", string.Format("{0} {1} {2}", p.Name, p.Father, p.Family));
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

                stamp.Close();
                Process.Start(sfd.FileName);
            }//if
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            this.rowColor();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var l = from p in ctx.Passengers
                    where p.Family.Contains(txtFilter.Text) || p.Name.Contains(txtFilter.Text) ||
                    p.Father.Contains(txtFilter.Text) || p.PassportNum.Contains(txtFilter.Text)
                    select p;
            dgvPassengers.DataSource = l.ToList();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";
            sfd.FileName = "VisaApply.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int i = 1;
                foreach (DataGridViewRow r in dgvPassengers.SelectedRows)
                {
                    generatePdf(r);
                    i++;
                }
            }//if
        }

        private void generatePdf(DataGridViewRow r)
        {
            //Path to source file
            String source = ".\\VisaForm.pdf";
            //Create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);
            //PdfStamper object to modify the content of the PDF
            string fullPath = sfd.FileName.Insert(sfd.FileName.LastIndexOf(".pdf"), string.Format(" - {0:00}", i));
            PdfStamper stamp = new PdfStamper(reader, new FileStream(fullPath, FileMode.Create));
            AcroFields form = stamp.AcroFields;

            Passenger p = (Passenger)r.DataBoundItem;
            form.SetField("form1[0].#subform[0].#field[0]", string.Format("{0} {1} {2}", p.Name, p.Father, p.Family));
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
            stamp.Close();
        }
    }
}
