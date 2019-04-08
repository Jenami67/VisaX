using System;
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
    public partial class frmHistory : Form
    {
        Passenger passenger;
        public frmHistory(Passenger passenger)
        {
            InitializeComponent();
            this.passenger = passenger;
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "سابقه درخواست های ویزای " + this.passenger.FullName;
        }
    }
}
