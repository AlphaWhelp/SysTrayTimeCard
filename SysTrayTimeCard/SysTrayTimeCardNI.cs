using System;
using System.Windows.Forms;
using System.Threading;

namespace SysTrayTimeCard
{
    // I'm really bad with names, okay?
    // It has nothing to do with Monty Python.
    class SysTrayTimeCardNI : ApplicationContext
    {
        private NotifyIcon _ni;
        private NotifyIcon ni
        {
            get
            {
                if (_ni == null) _ni = CreateNI();
                return _ni;
            }
        }

        private static SysTrayTimeCardNI sttc; // See Start() method below.
        private static ContextMenu cm;

        private SysTrayTimeCardDialog sttcd;

        // The Meaning of Life is better than The Holy Grail anyway.
        private NotifyIcon CreateNI()
        {
            NotifyIcon newNI = new NotifyIcon();
            newNI.Icon = SysTrayTimeCard.Properties.Resources.icon;
            cm = new ContextMenu();
#if DEBUG
            cm.MenuItems.Add(new MenuItem("Alert", new EventHandler(btnAlert)));
#endif
            MenuItem addTime = new MenuItem("AddTime", new EventHandler(btnAddTime));
            addTime.DefaultItem = true;
            cm.MenuItems.Add(addTime);
            cm.MenuItems.Add("-"); // Divider
            cm.MenuItems.Add(new MenuItem("Close", new EventHandler(btnExit)));
            newNI.ContextMenu = cm;
            newNI.DoubleClick += new EventHandler(btnAddTime);
            return newNI;
        }

        /// <summary>
        /// The getter for ni property will create
        /// the notification icon if it doesn't exist.
        /// </summary>
        private SysTrayTimeCardNI()
        {
            ni.Visible = true;
            sttcd = null;
        }

        // I chose to set this up as a singleton because I don't know.
        // I think I may have had some vision for this application that
        // is lost to the mists.
        public static SysTrayTimeCardNI Start()
        {
            if (sttc == null)
            {
                sttc = new SysTrayTimeCardNI();
                return sttc;
            }
            else return sttc;
        }

#if DEBUG
        /// <summary>
        /// Test method. No real reason to remove it.
        /// Won't compile in release.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlert(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
#endif

        /// <summary>
        /// Exits the whole application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit(object sender, EventArgs e)
        {
            // If you don't do this, the icon will linger
            // in the sys tray after exiting until it's moused over.
            ni.Visible = false; 
            Application.Exit();
        }

        /// <summary>
        /// Opens the dialog to add time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTime(object sender, EventArgs e)
        {
            if (sttcd == null)
            {
                sttcd = new SysTrayTimeCardDialog();
                sttcd.ShowDialog();
                sttcd = null;
                return;
            }
            else
            {
                sttcd.Focus();
                return;
            }
        }
    }
}
