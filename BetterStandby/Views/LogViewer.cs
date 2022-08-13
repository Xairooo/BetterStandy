using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterStandby.Views;

public partial class LogViewer : Form
{
    public LogViewer()
    {
        InitializeComponent();
        foreach (var logEntry in Properties.Settings.Default.logEntries)
        {
            logTextBox.AppendText(logEntry);
        }
    }

    private void clearLogButton_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.logEntries = new System.Collections.Specialized.StringCollection();
        logTextBox.Clear();
        Properties.Settings.Default.Save();
    }
}
