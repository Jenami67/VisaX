using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaX
{
    public partial class frmEditPassenger : Form
    {
        private VisaXEntities ctx = new VisaXEntities();
        private PersianCalendar pc = new PersianCalendar();
        private DateTime dt;
        private Passenger passenger;
        Shift selectedShift;
        private bool justEdit;

        public frmEditPassenger()
        {
            InitializeComponent();
        }
    }
}
