using System;

public static class DebugLogger
{
    public static void LogMessage(string message)
    {
#if DEBUG
        Console.WriteLine(message);
#endif
    }
}

public class Program
{
    public static void Main()
    {
        DebugLogger.LogMessage("Debugging message"); // This message will be printed only in DEBUG mode
        Console.WriteLine("Other code"); // This code will always execute
    }
}
