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
    private Thread WorkerThread;
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
                new ToolStripMenuItem("Exit", null, Exit)
            }
            },
            Visible = true
        };

        if (Properties.Settings.Default.ignoredWakeRequest == null) Properties.Settings.Default.ignoredWakeRequest = new System.Collections.Specialized.StringCollection();
        WorkerThread = new Thread(() => { worker(); });
        WorkerThread.Start();
        Console.WriteLine($"{DateTime.Now} graceTime: {Properties.Settings.Default.graceTime}");
        Console.WriteLine($"{DateTime.Now} sleepTime: {Properties.Settings.Default.idleTime}");
    }

    void Exit(object? sender, EventArgs e)
    {
        WorkerThread.Suspend();
        trayIcon.Visible = false;
        Application.Exit();
    }
    void Settings(object? sender, EventArgs e)
    {
        var settings = new Settings();
        settings.Show();
    }

    void worker()
    {
        while (true)
        {
            if (CheckShutdown())
            {
                Console.WriteLine($"{DateTime.Now} shutdown soon!");
                if (WaitGraceTime())
                {
                    Console.WriteLine($"{DateTime.Now} shutdown now!");
                    S.shutdown();
                }
            }
            //Console.WriteLine($"{S.GetIdleTime}");
            Thread.Sleep(1000);
        }
    }

    bool WaitGraceTime()
    {
        for (int i = 0; i < Properties.Settings.Default.graceTime; i++)
        {
            if (S.GetIdleTime < 10)
            {
                Console.WriteLine($"{DateTime.Now} shutdown aborted!");
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
            {
                return false;
            }
            return true;
        }
        return false;
    }

}

