namespace LogsLogsLogs;

// TODO: define the 'LogLevel' enum

internal static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        var logLevel = logLine.Split(':')[0];

        // write inline switch statement

        var logLevelEnum = logLevel switch
        {
            "[TRC]" => LogLevel.Trace,
            "[DBG]" => LogLevel.Debug,
            "[INF]" => LogLevel.Info,
            "[WRN]" => LogLevel.Warning,
            "[ERR]" => LogLevel.Error,
            "[FTL]" => LogLevel.Fatal,
            _ => LogLevel.Unknown,
        };

        return logLevelEnum;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{logLevel.GetHashCode()}:{message}"
               + "asdfasfasfasdf"
               + "asdfasdfasdfasdf"
               + "asdfasdfasdfasdf"
               + "asdfasdfasdfasdf";
    }
}