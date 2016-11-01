using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SysTrayTimeCard
{
    public partial class SysTrayTimeCardDialog : Form
    {
        private TimeSpan ts; // This is the timespan that we use to keep track of how much time we're adding
        private readonly TimeSpan zerots = new TimeSpan(0, 0, 0); // 0 Time to make sure we don't add negative time.
        private readonly string mTitle = "SysTrayTimeCard";

        // Store save data in the Local Appdata. This means we won't need Admin privileges.
        private static readonly string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\SysTrayTimeCard";
        private readonly string xmlPath = appDataPath + "\\TimeData.xml";

        // Create the dialog and initialize it to 0.
        // Initialize the date to today.
        public SysTrayTimeCardDialog()
        {
            InitializeComponent();
            datePicker.SetDate(DateTime.Now);
            ts = new TimeSpan(0, 0, 0); 
            lblTime.Text = ts.ToString(@"hh\:mm");
        }

        /// <summary>
        /// Adds time to the TimeSpan to track your time.
        /// </summary>
        /// <param name="sender">This must be a Button class.</param>
        /// <param name="e">EventArgs are irrelevent for this function.</param>
        private void addTime(object sender, EventArgs e)
        {
            // Get the time to add from a button click
            // All 6 buttons call this handler
            // The time to add is determined by the button's tag property in minutes
            #region debug code, could potentially be replaced with int timeToAdd = int.Parse(((Button)sender).Tag.ToString());
            int timeToAdd = 0;
            bool success = int.TryParse(((Button)sender).Tag.ToString(), out timeToAdd);
            if (!success) 
            {
                MessageBox.Show("This application has thrown a LiterallyCantEvenException", mTitle, MessageBoxButtons.OK);
                return;
            }
            #endregion

            // call the integer based overload
            addTime(timeToAdd);
        }

        /// <summary>
        /// This adds time by adding the integer in minutes.
        /// </summary>
        /// <param name="timeToAdd">Integer representing the minutes to add.</param>
        private void addTime(int timeToAdd)
        {
            // Here we add the times together and check to see if we've somehow ended up with negative time. If we did, we zero it out.
            ts += new TimeSpan(0, timeToAdd, 0);
            if (ts < zerots)
            {
                MessageBox.Show("Cannot be lower than 0 time.", mTitle, MessageBoxButtons.OK);
                ts += ts.Negate();
            }

            // Update the label text to reflect the new time.
            lblTime.Text = ts.ToString(@"hh\:mm");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Slacker
        }

        private void prepareXmlDoc(XmlDocument doc)
        {
            // Set up a basic XML file
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(declaration);
            XmlElement rootNode = doc.CreateElement("SysTrayTimeCard");
            doc.AppendChild(rootNode);
            doc.Save(xmlPath);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Grab the text data from the Dialog.
            string description = txtDesc.Text;
            string desc = description.ToLower();
#if RELEASE
            // A little bit of form validation.
            if ((desc == "asdf") || (desc == "test"))
            {
                MessageBox.Show("You know what you did.", mTitle, MessageBoxButtons.OK);
                txtDesc.Focus();
                return;
            }

            if ((desc == "done") || (desc == "complete") || (desc == "completed") || (desc == "finished"))
            {
                MessageBox.Show("Stop it.", mTitle, MessageBoxButtons.OK);
                txtDesc.Focus();
                return;
            }

            if (desc.Length < 8)
            {
                MessageBox.Show("Please enter a description of what you were doing.", mTitle, MessageBoxButtons.OK);
                txtDesc.Focus();
                return;
            }
#endif

#if DEBUG
            // Less validation on Debug
            if (desc.Length < 2)
            {
                MessageBox.Show("Please enter a description of what you were doing.", mTitle, MessageBoxButtons.OK);
                txtDesc.Focus();
                return;
            }
#endif
            // Validate the user knows they're adding 0 time so they don't go back
            // in two weeks and have no idea how long they worked on anything
            if (ts == ts.Negate())
            {
                if (
                    MessageBox.Show("You are inputting 0 time. Continue?", mTitle, MessageBoxButtons.OKCancel) 
                    == 
                    DialogResult.Cancel)
                    return;
            }


            #region This saves the time in the XML
            XmlDocument doc = new XmlDocument();
            XmlNode root;
            try
            {
                // There is no need to check anything here.
                // This method does nothing if it already exists.
                Directory.CreateDirectory(appDataPath);

                // Create the file if it doesn't exist, otherwise load it.
                if (!File.Exists(xmlPath))
                {
                    prepareXmlDoc(doc);
                }
                else
                {
                    doc.Load(xmlPath);
                }

                // This block adds the needed information to the XML file and saves it
                root = doc.DocumentElement;
                XmlElement newTime = doc.CreateElement("TrackedTime");
                XmlElement dateWorked = doc.CreateElement("DateWorked");
                dateWorked.InnerText = datePicker.SelectionRange.Start.ToString();
                XmlElement timeSpent = doc.CreateElement("TimeWorked");
                timeSpent.InnerText = lblTime.Text;
                XmlElement activity = doc.CreateElement("ActivityWorked");
                activity.InnerText = description;
                newTime.AppendChild(dateWorked);
                newTime.AppendChild(timeSpent);
                newTime.AppendChild(activity);
                root.AppendChild(newTime);
                doc.Save(xmlPath);
                #endregion
            }
            catch
#if DEBUG
            (Exception ex)
#endif
            {
                // I got this error to show up a whole bunch of times while coding this.
                // Not once was it because the XML file was write-locked by another application.
                MessageBox.Show("There was an error accessing the XML file.\r\nPlease Make Sure it's not in use.", mTitle, MessageBoxButtons.OK);
#if DEBUG
                MessageBox.Show(ex.Message + "\r\n\r\n" + ex.StackTrace);
#endif
                return;
            }

#if DEBUG
            // I thought this would get annoying in a release build so it's hidden behind a Debug directive.
            MessageBox.Show("Saved successfully.", mTitle, MessageBoxButtons.OK);
#endif
            this.Close();
        }
    }
}
