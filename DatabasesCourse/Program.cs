using System;
using System.Windows.Forms;

namespace DatabasesCourse
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(AppGlobals.MainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect to database. Please contact your IT administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
