using System;
using System.Text.RegularExpressions;

static partial class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Split(':')[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        return Regex.Replace(logLine.Split(':')[0].ToLower().Trim(), @"[\[\]]", "");
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
