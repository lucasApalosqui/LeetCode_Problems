using System;
using System.Collections.Generic;



public enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}

public static class DicLog
{
    public static Dictionary<string, LogLevel> GenDic() => new Dictionary<string, LogLevel>()
        {
            { "TRC", LogLevel.Trace },
            { "DBG", LogLevel.Debug},
            { "INF", LogLevel.Info},
            { "WRN", LogLevel.Warning},
            { "ERR", LogLevel.Error },
            { "FTL",LogLevel.Fatal }
        };
}

public static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        var lvl = logLine.Split('[', ']')[1];
        var log = DicLog.GenDic();
        var result = new LogLevel();
        try
        {
            result = log[lvl];
        }
        catch
        {
            result = LogLevel.Unknown;
        }

        return result;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}


