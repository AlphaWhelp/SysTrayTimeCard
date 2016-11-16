using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Linq;

namespace SysTrayTimeCard
{
    static class Program
    {
        public static STTCRegKey regKey = new STTCRegKey();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(SysTrayTimeCardNI.Start());
        }
    }
}
#if DEBUG
#warning YOU ARE COMPILING AS DEBUG
#endif