﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbdPdf.ShowDialog() == DialogResult.OK)
            {
                txtPdfPath.Text = fbdPdf.SelectedPath;
                Properties.Settings.Default.PdfPath = fbdPdf.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtPdfPath.Text = Properties.Settings.Default.PdfPath;
            fbdPdf.SelectedPath = Properties.Settings.Default.PdfPath;
        }
    }
}