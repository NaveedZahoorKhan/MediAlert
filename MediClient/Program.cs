using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediClient
{
    static class Program
    {
        public static AlertOnGreenClick gr;
        public static AlertOnRedClick re;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            gr = new AlertOnGreenClick();
            re = new AlertOnRedClick();
            Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerSelector());
        }
    }
}
