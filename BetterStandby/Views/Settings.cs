using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace BetterStandby.Views
{
    public partial class Settings : Form
    {
        private bool buttonPressed;
        private int requestCntOld;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            IdleTimeTextBox.Text = $"{Properties.Settings.Default.idleTime}";
            IdleTimeMaxTextBox.Text = $"{Properties.Settings.Default.idleTimeMax}";
            GraceTimeTextBox.Text = $"{Properties.Settings.Default.graceTime}";            
            /*System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(RefreshGui);
            aTimer.Interval = 1000;
            aTimer.Enabled = false;*/
            RefreshGui();
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
        }
        private void IdleTimeMaxTextBox_TextChanged(object sender, EventArgs e)
        {
            int time;
            int.TryParse(IdleTimeMaxTextBox.Text, out time);
            if (time == 0) IdleTimeMaxTextBox.Text = $"{Properties.Settings.Default.idleTimeMax}";
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
            int idleTime;
            int.TryParse(IdleTimeTextBox.Text, out idleTime);
            Properties.Settings.Default.idleTime = idleTime;
            int idleTimeMax;
            int.TryParse(IdleTimeMaxTextBox.Text, out idleTimeMax);
            Properties.Settings.Default.idleTimeMax = idleTimeMax;
            int graceTime;
            int.TryParse(GraceTimeTextBox.Text, out graceTime);
            Properties.Settings.Default.graceTime = graceTime;
            Properties.Settings.Default.ignoredWakeRequest = new ();
            for (int i = 0; i < IgnoredWakesListBox.Items.Count; i++)
            {
                if (!Properties.Settings.Default.ignoredWakeRequest.Contains(IgnoredWakesListBox.GetItemText(i)) && IgnoredWakesListBox.GetItemChecked(i))
                {
                    Properties.Settings.Default.ignoredWakeRequest.Add(IgnoredWakesListBox.GetItemText(i));
                }
            }

            Properties.Settings.Default.Save();
        }

        private void RefreshGui(object sender = null, ElapsedEventArgs e = null)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                var requests = S.GetRequests();
                if (requests.Count == requestCntOld) return;

                IgnoredWakesListBox.Items.Clear();
                var savedRequests = Properties.Settings.Default.ignoredWakeRequest;
                for (int i = 0; i < savedRequests.Count; i++)
                {
                    if (!IgnoredWakesListBox.Items.Contains(savedRequests[i]))
                    {                    
                        IgnoredWakesListBox.Items.Add(savedRequests[i]);
                        IgnoredWakesListBox.SetItemChecked(i, true);
                    }
                }
            
                foreach (var request in requests)
                {
                    foreach (var usage in request.Usages)
                    {
                        if (!IgnoredWakesListBox.Items.Contains(usage)) IgnoredWakesListBox.Items.Add(usage);
                    }
                }
            }));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            buttonPressed = true;
            Close();
        }


    }
}
