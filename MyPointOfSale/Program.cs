using MyPointOfSale.Models;
using System;
using System.Windows.Forms;

namespace MyPointOfSale
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Shop store = new Shop();
            Application.Run(new frmMain(store));
        }
    }
}
