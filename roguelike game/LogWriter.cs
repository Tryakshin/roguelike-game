using System;
using System.IO;

public class LogWriter
{
    public static void WriteLog(string logMessage)
    {
        string path = "C:\\Users\\Никита\\source\\repos\\roguelike4\\roguelike game\\log.txt";
           
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLineAsync(logMessage);
        }
    }

    public static void ClearLogs()
    {
        string path = "C:\\Users\\Никита\\source\\repos\\roguelike4\\roguelike game\\log.txt";

        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLineAsync();
        }
    }
}
