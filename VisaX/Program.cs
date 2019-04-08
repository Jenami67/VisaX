
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

            //if (DateTime.Now < new DateTime(2019, 4, 28))
            VisaXEntities ctx = new VisaXEntities();
            Properties.Settings.Default.User = (from u in ctx.Users where u.ID == 1 select u).FirstOrDefault();
            Application.Run(new frmShifts());
        }
    }
}
