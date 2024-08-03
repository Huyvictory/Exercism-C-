using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LogParser
{
    private HashSet<string> logLevels =
    [
        "[TRC]",
        "[DBG]",
        "[INF]",
        "[WRN]",
        "[ERR]",
        "[FTL]"
    ];

    public bool IsValidLine(string text)
    {
        return logLevels.Contains(text.Split(" ")[0]);
    }

    public string[] SplitLogLine(string text)
    {
        var RegexPattern = @"<[^>]*>";

        var replacedString = Regex.Replace(text, RegexPattern, "@");

        return replacedString.Split("@");
    }

    public int CountQuotedPasswords(string lines)
    {
        var count = 0;
        var splitedLines = lines.Split(Environment.NewLine);

        var RegexPasswordWord = @"""[^""]*password[^""]*""";

        foreach (var line in splitedLines)
        {
            var matches = Regex.Matches(line, RegexPasswordWord, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                count++;
            }
        }

        return count;
    }

    public string RemoveEndOfLineText(string line)
    {
        var RegexEndOfLine = @"end-of-line\d+";

        return Regex.Replace(line, RegexEndOfLine, string.Empty);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var results = new List<string>();

        var RegexWordStartsWithPassword = @"\bpassword\w+\b";

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, RegexWordStartsWithPassword, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                results.Add($"{matches[0].Value}: {line}");
            }
            else
            {
                results.Add($"--------: {line}");
            }
        }

        return results.ToArray();
    }
}