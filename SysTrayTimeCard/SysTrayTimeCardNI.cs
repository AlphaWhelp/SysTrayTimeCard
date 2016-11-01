using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SysTrayTimeCard
{
    // I'm really bad with names, ok.
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

        // The Meaning of Life is better than The Holy Grail anyway.
        private NotifyIcon CreateNI()
        {
            NotifyIcon newNI = new NotifyIcon();
            newNI.Icon = SysTrayTimeCard.Properties.Resources.icon;
            cm = new ContextMenu();
#if DEBUG
            cm.MenuItems.Add(new MenuItem("Alert", new EventHandler(btnAlert)));
#endif
            cm.MenuItems.Add(new MenuItem("Close", new EventHandler(btnExit)));
            cm.MenuItems.Add(new MenuItem("AddTime", new EventHandler(btnAddTime)));
            
            newNI.ContextMenu = cm;
            return newNI;
        }

        private SysTrayTimeCardNI()
        {
            ni.Visible = true;
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
        private void btnAlert(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
#endif

        private void btnExit(object sender, EventArgs e)
        {
            ni.Visible = false;
            Application.Exit();
        }

        private void btnAddTime(object sender, EventArgs e)
        {
            new SysTrayTimeCardDialog().ShowDialog();
        }
    }
}
