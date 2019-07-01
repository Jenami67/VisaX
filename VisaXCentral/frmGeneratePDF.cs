using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;

namespace VisaXCentral
{
    public partial class frmGeneratePDF : Form
    {
        public frmGeneratePDF()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                txtFileName.Text = ofd.FileName;
        }

        private void btnExportXls_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == string.Empty)
            {
                MessageBox.Show("ابتدا فایل اکسل را انتخاب کنید");
                btnBrowse_Click(null, null);
            }//if

            string path = txtFileName.Text;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Adobe Acrobat Documents (*.pdf)|*.pdf";
            sfd.FileName = Path.GetFileNameWithoutExtension(ofd.FileName);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApllication = null;
                Excel.Workbook excelWorkBook = null;
                Excel.Worksheet excelWorkSheet = null;

                excelApllication = new Excel.Application();
                System.Threading.Thread.Sleep(2000);
                excelWorkBook = excelApllication.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

                List<RemoteRequest> rr = new List<RemoteRequest>();
                int i = 1;
                while (excelWorkSheet.Cells[i + 7, 8].Value != null)
                {
                    rr.Add(new RemoteRequest());
                    rr[i - 1].FullName = excelWorkSheet.Cells[i + 7, 8].Value;
                    rr[i - 1].PassportNum = excelWorkSheet.Cells[i + 7, 7].Value.ToString();
                    rr[i - 1].Gender = (byte)(excelWorkSheet.Cells[i + 7, 6].Value2 == "ذکر" ? 0 : 1);

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

                ExportPDF(rr, sfd.FileName);
            }//if
        }

        private void ExportPDF(List<RemoteRequest> reqList, string destFile)
        {
            List<string> files = new List<string>();
            string dirPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\VisaX";
            Directory.CreateDirectory(dirPath);
            foreach (string file in Directory.GetFiles(dirPath))
                File.Delete(file);

            for (int i = 0; i < reqList.Count; i++)
                files.Add(generatePdf(reqList[i], i + 1));

            MergePDFs(files, destFile);
            Process.Start(destFile);
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
            //to Detect Fields...................................................................
            //for (int i = 0; i < 30; i++)
            //    form.SetField(string.Format("form1[0].#subform[0].#field[{0}]",i), i.ToString());
            //to Detect Fields...................................................................
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
    }
}
