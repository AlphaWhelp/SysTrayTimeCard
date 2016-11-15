using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq;

namespace SysTrayTimeCard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool regFailed = false;
            try
            {
                RegistryKey hkcu = Registry.CurrentUser;
                RegistryKey saveData;
                if (hkcu.GetSubKeyNames().Contains("SysTrayTimeCard"))
                {
                    saveData = hkcu.OpenSubKey("SysTrayTimeCard");
                }
                else
                {
                    saveData = hkcu.CreateSubKey("SysTrayTimeCard");
                }

            }
            catch
            {
                MessageBox.Show("Error reading or writing to registry.\r\nConfiguration changes will not be saved.", "SysTrayTimeCard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regFailed = true;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(SysTrayTimeCardNI.Start(regFailed));
        }
    }
}
#if DEBUG
#warning YOU ARE COMPILING AS DEBUG
#endif