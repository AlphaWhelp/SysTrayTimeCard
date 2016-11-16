using System;
using System.Windows.Forms;
using System.Linq;

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

        private STTCBaseForm sttcActiveWindow;

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
            MenuItem config = new MenuItem("Config");
            MenuItem roamingEnabled = new MenuItem("Roaming Enabled", new EventHandler(toggleRoaming));
            roamingEnabled.Checked = Program.regKey.roamingEnabled;
            config.MenuItems.Add(roamingEnabled);
            cm.MenuItems.Add(config);
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
            sttcActiveWindow = null;
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
            Application.Exit(StageLeft);
        }

        /// <summary>
        /// Opens the dialog to add time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTime(object sender, EventArgs e)
        {
            if (sttcActiveWindow == null)
            {
                sttcActiveWindow = new SysTrayTimeCardDialog();
                sttcActiveWindow.ShowDialog();
                sttcActiveWindow = null;
                return;
            }
            else
            {
                sttcActiveWindow.Focus();
                sttcActiveWindow.displayMsg(
                    sttcActiveWindow.GetType() == typeof(SysTrayTimeCardDialog) ? "Please enter time" : null
                    );
                return;
            }
        }

        /// <summary>
        /// Toggle Roaming / Local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void toggleRoaming(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            mi.Checked = !mi.Checked;
            Program.regKey.roamingEnabled = mi.Checked;
        }

        // Not currently in use, but I'm sure that will change.
        /// <summary>
        /// Uncheck other menu items
        /// Requires they all have the same Tag
        /// </summary>
        /// <param name="item">The sender from the onClick event handler</param>
        public void uncheckOtherItems(MenuItem item)
        {
            var query = from MenuItem x in item.Parent.MenuItems
                        where x.Tag.ToString() == item.Tag.ToString()
                        select x;

            foreach (MenuItem mi in query) mi.Checked = false;
            item.Checked = true;
        }

        // Don't judge me
#pragma warning disable CS0649
        System.ComponentModel.CancelEventArgs StageLeft;
#pragma warning restore CS0649
    }
}
