using System;
using System.Linq;
using Microsoft.Win32;
using System.Windows.Forms;

namespace SysTrayTimeCard
{
    /// <summary>
    /// Registry Key helper class
    /// </summary>
    class STTCRegKey
    {
        // This variable will take care of everything under the hood
        private RegistryKey regKey;

        // Assists with determining if the registry was initialized properly
        private bool initialized = false;

        /// <summary>
        /// Easy way to check to see if we have registry access.
        /// Code for contingencies if we don't.
        /// Setup with nonstatic references to insure that the object exists.
        /// </summary>
        /// <param name="obj">The registry key helper object</param>
        public static implicit operator bool(STTCRegKey obj)
        {
            if (obj == null) return false;
            return obj.initialized;
        }

        public STTCRegKey()
        {
            // Vanilla registry access to HKEY_CURRENT_USER\Software
            // Application settings will be stored in HKEY_CURRENT_USER\Software\SysTrayTimeCard
            try
            {
                RegistryKey currentUser = Registry.CurrentUser.OpenSubKey("Software", true);
                if (currentUser.GetSubKeyNames().Contains("SysTrayTimeCard"))
                {
                    // Open the Sub Key if it exists
                    regKey = currentUser.OpenSubKey("SysTrayTimeCard", true);
                }
                else
                {
                    // Otherwise create the Sub Key and perform some initial configuration
                    regKey = currentUser.CreateSubKey("SysTrayTimeCard");
                    regKey.SetValue("RoamingEnabled", "Disabled", RegistryValueKind.String);
                }
                // Set to true as a last step, it's our way of knowing it worked.
                initialized = true;
            }
            catch
            {
                // if it didn't work for any reason, make sure we set this bool to false
                initialized = false;
                MessageBox.Show("Error reading or writing to registry.\r\nConfiguration changes will not be saved.", "SysTrayTimeCard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This property identifies if we've chosen to save as a Local or Roaming user
        /// The only difference is that Roaming data is synchronized within a domain
        /// while Local data never leaves the machine, even on the same domain.
        /// Strong logical preference for enabled, but disabled by default.
        /// 
        /// Might be useful if someone wishes to use this application on multiple PCs in the same domain.
        /// </summary>
        public bool roamingEnabled
        {
            get
            {
                if (!this) return false;
                return !(regKey.GetValue("RoamingEnabled").ToString() == "Disabled");
            }
            set
            {
                if (!this) return;
                regKey.SetValue("RoamingEnabled", value ? "Enabled" : "Disabled");
            }
        }
    }
}
