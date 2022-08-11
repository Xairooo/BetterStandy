using BetterStandby.Models;
using System.Diagnostics;

namespace BetterStandby;

public static class S
{
    private static readonly IdleTime idleTime = new IdleTime();
    public static int GetIdleTime => idleTime.getIdleTime();

    public static string powercfg(string arg)
    {
        Process p = new Process();
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.Arguments = $"/c powercfg {arg}";
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        var result = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
#if DEBUG
        Console.WriteLine(result);
#endif
        return result;
    }

    public static string shutdown()
    {
        Process p = new Process();
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = "shutdown.exe";
        p.StartInfo.Arguments = $"-h";
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        var result = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
#if DEBUG
        Console.WriteLine(result);
#endif
        return result;
    }

    public static List<powercfgRequest> GetRequests()
    {
        var result = new List<powercfgRequest>();
        var reqs = S.powercfg("requests").Split("\n\r\n");
        for (int i = 0; i < reqs.Count(); i++)
        {
            var request = new powercfgRequest(reqs[i].Split(':').First(), reqs[i].Split(':').Last());
            if (request.Usages.Count() > 0) result.Add(request);
        };
        return result;
    }
}
