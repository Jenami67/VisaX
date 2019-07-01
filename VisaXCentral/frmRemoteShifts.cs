using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace VisaXCentral
{
    public partial class frmShifts : Form
    {
        VisaXCenterEntities ctx = new VisaXCenterEntities("ASAWARI");
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
            string path = "./PassengerList.xls";
            string absPath = Path.GetFullPath(path);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            int shiftID = (int)dgvShifts.SelectedRows[0].Cells["colID"].Value;
            RemoteShift selectedShift = ctx.RemoteShifts.Where(s => s.ID == shiftID).First<RemoteShift>();
            sfd.FileName = this.user.UserName + " - " + selectedShift.Date.ToString("yyyy-MM-dd") + string.Format(" ({0:00})", selectedShift.ShiftNum);
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
                foreach (RemoteRequest r in selectedShift.RemoteRequests)
                {
                    excelWorkSheet.Cells[i + 7, 8].Value = r.FullName;
                    excelWorkSheet.Cells[i + 7, 7].Value = r.PassportNum;
                    excelWorkSheet.Cells[i + 7, 6].Value2 = (byte)r.Gender == 0 ? "ذکر" : "انثی";

                    //format error: Exception from HRESULT: 0x800A03EC
                    if (r.BornDate.HasValue)
                    {
                        excelWorkSheet.Cells[i + 7, 5].Value2 = r.BornDate;
                        excelWorkSheet.Cells[i + 7, 4].Value2 = r.IssueDate;
                        excelWorkSheet.Cells[i + 7, 3].Value2 = r.ExpiryDate;
                    }//if
                    i++;
                }//foreach

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

        private void dtpTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        //private void dgvShifts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    btnList_Click(null, null);
        //}
    }
    public partial class VisaXCenteralEntities : DbContext
    {
        public VisaXCenteralEntities(string user, string pwd)
            : base("name=VisaXCenterEntities")
        {
            Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, pwd);
        }

        public VisaXCenteralEntities(string user)
             : base("name=VisaXCenterEntities")
        {
            if (user == "ASAWARI")
                Database.Connection.ConnectionString = string.Format(this.Database.Connection.ConnectionString, user, "3Pg^gf81");
        }
    }

}
