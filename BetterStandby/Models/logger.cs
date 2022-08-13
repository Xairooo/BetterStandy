namespace BetterStandby.Models;
internal static class logger
{
    internal static DateTime timeLast;
    internal static string lineLast;
    internal static void Write(string line)
    {
        if (line == lineLast && DateTime.Now.Subtract(timeLast) < TimeSpan.FromMilliseconds(60000))
        {
            return;
        }
        Properties.Settings.Default.logEntries.Add($"{DateTime.Now} {line}");
        if (Properties.Settings.Default.logEntries.Count >= Properties.Settings.Default.maxLogEntries)
            Properties.Settings.Default.logEntries.RemoveAt(0);

        Properties.Settings.Default.Save();
    }
    internal static void WriteLine(string line)
    {
        if (line == lineLast && DateTime.Now.Subtract(timeLast) < TimeSpan.FromMilliseconds(60000))
        {
            return;
        }
        Properties.Settings.Default.logEntries.Add($"{DateTime.Now} {line}\n");
        if (Properties.Settings.Default.logEntries.Count >= Properties.Settings.Default.maxLogEntries)
            Properties.Settings.Default.logEntries.RemoveAt(0);
        lineLast = line;
        timeLast = DateTime.Now;
        Properties.Settings.Default.Save();
    }
}
