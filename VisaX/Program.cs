
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisaX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            VisaXEntities ctx = new VisaX.VisaXEntities();
            var pa = (from p in ctx.Passengers where p.ID == 1 select p).First();
            //Application.Run(new frmAddPassenger((Passenger)pa));
            Application.Run(new frmMain());
#endif
        }
    }
}
