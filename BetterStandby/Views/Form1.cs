using BetterStandby.Models;
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

public partial class Form1 : Form
{
    private NotifyIcon trayIcon;
    private bool WorkerThreadRunning = true;

    public Form1()
    {
        InitializeComponent();
        trayIcon = new NotifyIcon()
        {
            //Icon = Resources.trayIcon.ToBitmap(),
            Icon = new Icon(SystemIcons.Information, 40, 40),
            ContextMenuStrip = new ContextMenuStrip()
            {
                Items =
            {
                new ToolStripMenuItem("Settings", null, Settings),
                new ToolStripMenuItem("View logs", null, LogViewer),
                new ToolStripMenuItem("Exit", null, Exit)
            }
            },
            Visible = true
        };

        if (Properties.Settings.Default.ignoredWakeRequest == null) Properties.Settings.Default.ignoredWakeRequest = new System.Collections.Specialized.StringCollection();
        if (Properties.Settings.Default.logEntries == null) Properties.Settings.Default.logEntries = new System.Collections.Specialized.StringCollection();

        new Thread(() => { worker(); }).Start();
        logger.WriteLine($"graceTime: {Properties.Settings.Default.graceTime}");
        logger.WriteLine($"sleepTime: {Properties.Settings.Default.idleTime}");
    }

    void Exit(object? sender, EventArgs e)
    {
        WorkerThreadRunning = false;
        trayIcon.Visible = false;
        Application.Exit();
    }
    void Settings(object? sender, EventArgs e)
    {
        var settings = new Settings();
        settings.Show();
    }
    void LogViewer(object? sender, EventArgs e)
    {
        var logViewer = new LogViewer();
        logViewer.Show();
    }
    void worker()
    {
        while (WorkerThreadRunning)
        {
            if (CheckShutdown())
            {
                logger.WriteLine($"shutdown soon!");
                if (WaitGraceTime())
                {
                    logger.WriteLine($"shutdown now!");
                    S.shutdown();
                }
            }
            Thread.Sleep(1000);
        }
    }

    bool WaitGraceTime()
    {
        for (int i = 0; i < Properties.Settings.Default.graceTime; i++)
        {
            if (S.GetIdleTime < 10)
            {
                logger.WriteLine($"shutdown aborted!");
                return false;
            }
            Thread.Sleep(1000);
        }
        return true;
    }

    bool CheckShutdown()
    {
        if (S.GetIdleTime > Properties.Settings.Default.idleTime)
        {            
            foreach (var request in S.GetRequests())            
            foreach (var usage in request.Usages)
            {
                if (Properties.Settings.Default.ignoredWakeRequest.Contains(usage)) continue;
                logger.WriteLine($"idleTime reached but blocked by: {usage}");
                return false;
            }
            
            return true;
        }
        return false;
    }

}

