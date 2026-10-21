using System;
using System.Windows.Forms;

namespace MenusBarras
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Show a dialog so the user can see startup exceptions instead of the app exiting silently.
                MessageBox.Show($"Error al iniciar la aplicación:\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}