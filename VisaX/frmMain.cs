using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            frmAddPassenger.ShowDialog();
            if (frmAddPassenger.DialogResult == DialogResult.OK)
            {
                dgvPassengers.Refresh();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddPassenger frmAddPassenger = new frmAddPassenger();
            frmAddPassenger.ShowDialog();
            if (frmAddPassenger.DialogResult == DialogResult.OK)
            {
                dgvPassengers.Update();
                dgvPassengers.Refresh();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Visa_Export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                //Excel.Application excel = new Excel.Application();
                //Excel.Workbook wb = excel.Workbooks.Open(@"C:\Users\Mahmood\Desktop\Visa_Export3.xls");
                //Excel.Worksheet xlMainWorkSheet = wb.Worksheets[1];
                //xlMainWorkSheet.Cells.Range[1, 1].Value2 = "OK";

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                //Add workbook and worksheet
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Shapes.AddPicture(@"D:\Programing\VisaX\Files\Logo.jpg", MsoTriState.msoFalse, MsoTriState.msoCTrue, 50, 50, 300, 45);

                // Format column D as text before pasting results, this was required for my data
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range - Cells(row,col) and based on 1
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 2];
                CR.Select();
                // xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                xlWorkSheet.Paste(CR, Type.Missing);

                Excel.Range yy = (Excel.Range)xlWorkSheet.Cells[2, 1];
                yy.Value2 = "ردیف";

                for (int j = 3; j < dgvPassengers.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)xlWorkSheet.Cells[j, 1];
                    myRange.Value2 = j;
                }


                //// For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                //// Delete blank column A and select cell A1
                //Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                //delRng.Delete(Type.Missing);
                //xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dgvPassengers.ClearSelection();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void copyAlltoClipboard()
        {
            dgvPassengers.SelectAll();
            DataObject dataObj = dgvPassengers.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public void rowColor()
        {
            for (int i = 0; i < dgvPassengers.Rows.Count; i++)
                if (i % 2 != 0)
                    dgvPassengers.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void testExport(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            int j = 0, i = 0;

            //Write Headers
            for (j = 0; j < dgvPassengers.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dgvPassengers.Columns[j].HeaderText;
            }

            StartRow++;

            //Write datagridview content
            for (i = 0; i < dgvPassengers.Rows.Count; i++)
                for (j = 0; j < dgvPassengers.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dgvPassengers[j, i].Value == null ? "" : dgvPassengers[j, i].Value;
                }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            dgvPassengers.DataSource = (dgvPassengers.DataSource as List<Passenger>).Where(p => p.Name.Contains(txtFilter.Text)).ToList<Passenger>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"D:\Programing\VisaX\Documentation\test.xls";
            Excel.Application excelApllication = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;

            excelApllication = new Excel.Application();
            System.Threading.Thread.Sleep(2000);
            excelWorkBook = excelApllication.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i < dgvPassengers.Rows.Count; i++)
            {
                excelWorkSheet.Cells[i + 8, 8].Value = string.Format("{0} {1} {2}", dgvPassengers[1, i].Value, dgvPassengers[3, i].Value, dgvPassengers[2, i].Value);
                excelWorkSheet.Cells[i + 8, 7].Value = dgvPassengers[4, i].Value;
                excelWorkSheet.Cells[i + 8, 6].Value2 = (byte)dgvPassengers[8, i].Value == 0 ? "ذکر" : "انثی";

                //format error: Exception from HRESULT: 0x800A03EC
                excelWorkSheet.Cells[i + 8, 5].Value2 = dgvPassengers[5, i].Value;
                excelWorkSheet.Cells[i + 8, 4].Value2 = dgvPassengers[6, i].Value;
                excelWorkSheet.Cells[i + 8, 3].Value2 = dgvPassengers[7, i].Value;
            }//for

            path = @"D:\Programing\VisaX\Documentation\test2.xls";
            excelWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal);

            excelWorkBook.Close();
            excelApllication.Quit();

            Marshal.FinalReleaseComObject(excelWorkSheet);
            Marshal.FinalReleaseComObject(excelWorkBook);
            Marshal.FinalReleaseComObject(excelApllication);
            excelApllication = null;
            excelWorkSheet = null;
            //opens the created and saved Excel file
            Process.Start(path);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            // path to source file
            String source = @"D:\Programing\VisaX\Documentation\InstaVisa.pdf";
            //create PdfReader object to read the source file
            PdfReader reader = new PdfReader(source);
            //PdfStamper object to modify the content of the PDF
            PdfStamper stamp = new PdfStamper(reader, new FileStream("d:/formfilled.pdf", FileMode.Create));
            AcroFields form = stamp.AcroFields;
            IDictionary<string, AcroFields.Item> fs = form.Fields;
            /*
            StringBuilder sb = new StringBuilder();
            sb.Append("Possible values for form1[0].#subform[0].RadioButtonList[0]:");
            sb.Append(Environment.NewLine);
            string[] states = form.GetAppearanceStates("form1[0].#subform[0].RadioButtonList[0]");

            for (int i = 0; i < states.Length - 1; i++)
            {
                sb.Append(states[i]);
                sb.Append(", ");
            }
            sb.Append(states[states.Length - 1]);
            MessageBox.Show(sb.ToString());
            */

            Passenger p = (Passenger)dgvPassengers.CurrentRow.DataBoundItem;

            form.SetField("form1[0].#subform[0].#field[0]", string.Format("{0} {1} {2}", p.Name, p.Father, p.Family));

            form.SetField("form1[0].#subform[0].#field[1]", "اسلام");
            //Radio for Gender
            form.SetField("form1[0].#subform[0].RadioButtonList[0]", (2- p.Gender).ToString());
            form.SetField("form1[0].#subform[0].#field[2]", "ایرانیه");
            form.SetField("form1[0].#subform[0].#field[3]", "ایرانیه");
            form.SetField("form1[0].#subform[0].#field[9]", "ایران");
            form.SetField("form1[0].#subform[0].#field[8]", p.BornDate.Year.ToString());
            form.SetField("form1[0].#subform[0].#field[5]", p.BornDate.Month.ToString());
            form.SetField("form1[0].#subform[0].#field[6]", p.BornDate.Day.ToString());
            form.SetField("form1[0].#subform[0].#field[21]", p.PassportNum);
            //Issue Date
            form.SetField("form1[0].#subform[0].#field[25]", p.IssueDate.Year.ToString());
            form.SetField("form1[0].#subform[0].#field[22]", p.IssueDate.Month.ToString());
            form.SetField("form1[0].#subform[0].#field[23]", p.IssueDate.Day.ToString());
            //Expiry Date
            form.SetField("form1[0].#subform[0].#field[30]", p.ExpiryDate.Year.ToString());
            form.SetField("form1[0].#subform[0].#field[27]", p.ExpiryDate.Month.ToString());
            form.SetField("form1[0].#subform[0].#field[28]", p.ExpiryDate.Day.ToString());

            //for (int i = 0; i < 40; i++)
            //    form.SetField(string.Format("form1[0].#subform[0].#field[{0}]", i), i.ToString());
            stamp.Close();
            System.Diagnostics.Process.Start("d:/formfilled.pdf");
        }
    }
}
