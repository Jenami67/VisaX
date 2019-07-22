using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisaXCentral;

namespace VisaXCentral
{
    public partial class frmMessages : Form
    {
        VisaXCenterEntities ctxCenter = new VisaXCenterEntities("ASAWARI");
        int curUsrID;
        public frmMessages()
        {
            InitializeComponent();
            dgvShifts.AutoGenerateColumns = false;
        }
        public frmMessages(int curUsrID) : this()
        {
            this.curUsrID = curUsrID;
        }
        private void SendShifts_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void refreshGrid()
        {
            dgvShifts.DataSource = (from m in ctxCenter.Messages
                                    where m.RemoteUserID == curUsrID
                                    select m).ToList();
        }

        private void dgvShifts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnDelMsg.Enabled = btnNewMsg.Enabled = dgvShifts.Rows.Count > 0;
        }

        private void dgvShifts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvShifts_RowsAdded(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        private void btnNewMsg_Click(object sender, EventArgs e)
        {
            if (new frmNewMsg(this.curUsrID).ShowDialog() == DialogResult.OK)
                refreshGrid();
        }

        private void btnDelMsg_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به حذف این پیام هستید؟", "حذف پیام ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                ctxCenter.Messages.Remove((Message)dgvShifts.SelectedRows[0].DataBoundItem);
                ctxCenter.SaveChanges();
                refreshGrid();
            }
        }

    }
}
