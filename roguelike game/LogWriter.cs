using System;
using System.IO;

public class LogWriter
{
    public static void WriteLog(string logMessage)
    {
        string path = "C:\\Users\\sasha\\source\\repos\\roguelike-game\\roguelike game\\roguelike game\\log.txt";
           
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLineAsync(logMessage);
        }
    }
}
