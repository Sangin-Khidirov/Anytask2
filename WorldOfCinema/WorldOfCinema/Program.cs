using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfCinema
{
    static class Program
    {
        static public bool checker = true;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (checker)
            {
                Application.Run(new Avt());
                if (Avt.status == "user")
                {
                    Application.Run(new Form1());
                    Avt.status = "done";
                }
                if (Avt.status == "admin")
                {
                    Application.Run(new ADmin());
                    Avt.status = "done";
                }
            }
        }
    }
}
