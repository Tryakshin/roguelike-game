using System.IO;

public class LogWriter
{
    private StreamWriter writer;
    
    public LogWriter(string filePath, bool boolean)
    {

        try
        {
            writer = new StreamWriter(filePath, boolean);
        }

        catch (IOException e)
        {
            Console.WriteLine("Произошла ошибка при создании файла для записи лога: " + e.Message);
        }
    }

    public void WriteLog(string logMessage)
    {
        try
        {
            writer.WriteLineAsync(logMessage);
        }

        catch (IOException e)
        {
            Console.WriteLine("Произошла ошибка при записи лога в файл: " + e.Message);
        }
    }

    public void Close()
    {
        try
        {
            writer.Close();
        }

        catch (IOException e)
        {
            Console.WriteLine("Произошла ошибка при закрытии файла для записи лога: " + e.Message);
        }
    }
}