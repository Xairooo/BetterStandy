using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterStandby.Views
{
    public partial class Settings : Form
    {
        private bool buttonPressed;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            IdleTimeTextBox.Text = $"{Properties.Settings.Default.idleTime}";
            GraceTimeTextBox.Text = $"{Properties.Settings.Default.graceTime}";
            Refresh();
        }

        private void IdleTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            int time;
            int.TryParse(IdleTimeTextBox.Text, out time);
            if (time == 0) IdleTimeTextBox.Text = $"{Properties.Settings.Default.idleTime}";
            //else Properties.Settings.Default.idleTime = time;
        }

        private void GraceTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            int time;
            int.TryParse(GraceTimeTextBox.Text, out time);
            if (time == 0) GraceTimeTextBox.Text = $"{Properties.Settings.Default.graceTime}";
            //else Properties.Settings.Default.graceTime = time;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SafeChanges();
            buttonPressed = true;
            Close();
        }
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonPressed) return;
            var box = MessageBox.Show("Save changes ?", "", MessageBoxButtons.YesNo);
            if (box == DialogResult.Yes)
            {
                SafeChanges();
            }
        }

        private void SafeChanges()
        {
            int graceTime;
            int.TryParse(GraceTimeTextBox.Text, out graceTime);
            Properties.Settings.Default.graceTime = graceTime;
            int idleTime;
            int.TryParse(IdleTimeTextBox.Text, out idleTime);
            Properties.Settings.Default.idleTime = idleTime;

            foreach (string item in IgnoredWakesListBox.CheckedItems)
            {                
                if (!Properties.Settings.Default.ignoredWakeRequest.Contains(item))
                {
                    Properties.Settings.Default.ignoredWakeRequest.Add(item);
                }
            }

            Properties.Settings.Default.Save();
        }

        private void Refresh()
        {
            IgnoredWakesListBox.Items.Clear();
            var requests = Properties.Settings.Default.ignoredWakeRequest;
            for (int i = 0; i < requests.Count; i++)
            {
                if (!IgnoredWakesListBox.Items.Contains(requests[i]))
                {                    
                    IgnoredWakesListBox.Items.Add(requests[i]);
                    IgnoredWakesListBox.SetItemChecked(i, true);
                }
            }
            
            foreach (var request in S.GetRequests())
            {
                foreach (var usage in request.Usages)
                {
                    if (!IgnoredWakesListBox.Items.Contains(usage)) IgnoredWakesListBox.Items.Add(usage);
                }
            }

        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
            Close();
        }

    }
}
