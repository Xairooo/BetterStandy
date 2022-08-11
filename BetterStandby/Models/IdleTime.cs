using System.Runtime.InteropServices;

namespace BetterStandby.Models;
public class IdleTime
{
    [DllImport("user32.dll")]
    static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    internal struct LASTINPUTINFO
    {
        public Int32 cbSize;
        public Int32 dwTime;
    }

    public int getIdleTime()
    {
        int systemUptime = Environment.TickCount;
        int LastInputTicks = 0;
        int IdleTicks = 0;

        LASTINPUTINFO LastInputInfo = new LASTINPUTINFO();
        LastInputInfo.cbSize = (Int32)Marshal.SizeOf(LastInputInfo);
        LastInputInfo.dwTime = 0;

        if (GetLastInputInfo(ref LastInputInfo))
        {
            LastInputTicks = (int)LastInputInfo.dwTime;
            IdleTicks = systemUptime - LastInputTicks;
        }
        return IdleTicks / 1000;
    }
}
