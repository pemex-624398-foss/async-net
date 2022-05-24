namespace AsyncConsole;

public static class Work
{
    private static readonly Random Random = new();

    public record Argument(
        IDictionary<string, IList<int>> Data,
        string Key,
        CancellationToken? CancellationToken = default
        );
    
    public const int Timeout = 3 * 1000;

    public static void Run(Argument argument)
    {
        if (argument.CancellationToken?.IsCancellationRequested ?? false)
        {
            Log.WriteLine();
            Log.WriteLine($"Work cancelled before processing key {argument.Key}");
            Log.WriteLine();
            return;
        }
        
        var list = argument.Data[argument.Key];
        foreach (var number in list)
        {
            if (argument.CancellationToken?.IsCancellationRequested ?? false)
            {
                Log.WriteLine();
                Log.WriteLine($"Work cancelled for key {argument.Key}");
                Log.WriteLine();
                return;
            }

            var s = Random.Next(1, 4);
            var formattedNumber = number.ToString().PadRight(5, ' ');
            Log.WriteLine($"Processing value {argument.Key}:{formattedNumber} (next value in {s} second{(s != 1 ? "s" : "")})");
            
            Thread.Sleep(s * 1000);
        }
        Log.WriteLine();
        Log.WriteLine($"Work finished for key {argument.Key}");
        Log.WriteLine();
    }
    
    public static void Run(object? param)
    {
        if (param is not Argument argument)
            throw new ArgumentException("Invalid argument type", nameof(param));

        Run(argument);
    }
}