using System.Text.RegularExpressions;

namespace BetterStandby.Models;
public class powercfgRequest
{
    public string Type;
    public List<string> Usages = new List<string>();
    public powercfgRequest(string type, string usage)
    {
        Type = type;
        foreach (Match m in Regex.Matches(usage, @"(\[\w+\] .*)\r\n([\w|\s|\-]+)", RegexOptions.None))
        {
            Usages.Add($"{m.Groups[1]} {m.Groups[2]}");
        }
    }
}
