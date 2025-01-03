public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        var idx = str.IndexOf(delimiter);
        return idx != -1 ? str.Substring(idx + delimiter.Length) : "";
    }

    public static string SubstringBetween(this string str, string delimiter1, string delimiter2)
    {
        var idx = str.IndexOf(delimiter1);
        var result = idx != -1 ? str.Substring(idx + delimiter1.Length) : "";
        var split = result.Split(delimiter2);
        return split[0];
    }

    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}