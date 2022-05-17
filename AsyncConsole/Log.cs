namespace AsyncConsole;

public static class Log
{
    public static void WriteLine(string? message = default)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        if (message is null)
            Console.WriteLine();
        else
            Console.WriteLine($"{timestamp} [Thread {Environment.CurrentManagedThreadId:D2}] => {message}");
    }
}