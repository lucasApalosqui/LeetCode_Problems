public static class LogLine
{
    public static string Message(string logLine)
    {
        var split = logLine.Split(":");
        var message = split[1];
        return message.Trim();

    }

    public static string LogLevel(string logLine)
    {
        var split = logLine.Split(":");
        var log = split[0];
        return log.Trim(['[', ']']).ToLower();
    }

    public static string Reformat(string logLine)
    {
        var split = logLine.Split(":");
        var message = split[1];
        var log = split[0];

        message = message.Trim();
        return $"{message} ({log.Trim(['[', ']']).ToLower()})";
    }
}


