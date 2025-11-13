using System.Diagnostics;

public static class Log
{
    private static void Construct(string level, string message)
    {
        string timestamp = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");

        var stackTrace = new StackTrace();
        var callingMethod = stackTrace.GetFrame(2)?.GetMethod();
        string? callingClass = callingMethod?.DeclaringType?.Name;

        string entry = $"[{timestamp}] {level}: {callingClass}: {message}";
        Console.WriteLine(entry);
    }

    public static void LogDebug(string message)
    {
        Construct("DEBUG", message);
    }
    public static void LogInfo(string message)
    {
        Construct("INFO", message);
    }

    public static void LogWarning(string message)
    {
        Construct("WARN", message);
    }

    public static void LogError(string message)
    {
        Construct("ERROR", message);
    }

    public static void LogCritical(string message)
    {
        Construct("CRITICAL", message);
    }
}