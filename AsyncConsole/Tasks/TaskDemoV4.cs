using System.Linq.Expressions;
using AsyncConsole.Delegates.Calculation.Extended;

namespace AsyncConsole.Tasks;

public static class TaskDemoV4
{
    public static async Task RunAsync()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV4)} (Async Calculator)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        var completed = 0;
        var failed = 0;
        
        var calculator = new AsyncCalculator(
            (_, _, _, _) => completed++, 
            (_, _, _, _) => failed++
            );
        double a = 0, b = 0, r = 0;

        Log.WriteLine($"a = {a}, b = {b}, r = {r}");
        Log.WriteLine();

        
        a = 698;
        b = 547;
        r = await calculator.AddAsync(a, b);
        Log.WriteLine($"{a} + {b} = {r}");
        Log.WriteLine();
        
        
        a = 832;
        b = 222;
        r = await calculator.SubtractAsync(a, b);
        Log.WriteLine($"{a} - {b} = {r}");
        Log.WriteLine();
        
        
        a = 154;
        b = 359;
        r = await calculator.MultiplyAsync(a, b);
        Log.WriteLine($"{a} * {b} = {r}");
        Log.WriteLine();
        
        
        a = 438;
        b = 998;
        r = await calculator.DivideAsync(a, b);
        Log.WriteLine($"{a} / {b} = {r}");
        Log.WriteLine();


        try
        {
            a = 222;
            b = 0;
            r = await calculator.DivideAsync(a, b);
            Log.WriteLine($"{a} / {b} = {r}");
            Log.WriteLine();
        }
        catch (Exception exception)
        {
            Log.WriteLine($"Division error ({a} / {b}): {exception.Message}");
        }
        
        Log.WriteLine($"{completed} operation(s) completed");
        Log.WriteLine($"{failed} operation(s) failed");
    }
}