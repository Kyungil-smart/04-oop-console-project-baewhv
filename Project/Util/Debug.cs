namespace Project;


public static class Debug
{
    public  enum LogType
    {
        Normal,
        Warning,
    }

    private static List<(LogType type, String text)> LogList = new List<(LogType type, string text)>();

    public static void Log(string text)
    {
        LogList.Add((LogType.Normal, text));
    }

    public static void LogWarning(string text)
    {
        LogList.Add((LogType.Warning, text));
    }

    public static void Render()
    {
        foreach ((LogType type, string text) in LogList)
        {
            if(type == LogType.Normal) text.Print();
            else if(type == LogType.Warning) text.Print(ConsoleColor.Yellow);
            Console.WriteLine();
        }
    }
}