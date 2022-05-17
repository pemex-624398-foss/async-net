using AsyncConsole.Delegates.Calculation.Extended;

namespace AsyncConsole.Delegates;

public static class CalculatorDemoV3
{
    public static void Run()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine(nameof(CalculatorDemoV3));
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        var calculator = new ExtendedCalculator(
            (o, a, b, r) =>
            {
                var s = ExtendedCalculator.GetOperationSymbol(o);
                Log.WriteLine($"{a} {s} {b} = {r}");
                Log.WriteLine();
            },
            (o, a, b, e) =>
            {
                var s = ExtendedCalculator.GetOperationSymbol(o);
                Log.WriteLine($"{o} error ({a} {s} {b}): {e.Message}");
                Log.WriteLine();
            }
            );
        
        
        double a = 0, b = 0;

        Log.WriteLine($"a = {a}, b = {b}");
        Log.WriteLine();

        a = 78;
        b = 65;
        calculator.Add(a, b);
        
        a = 94;
        b = 26;
        calculator.Subtract(a, b);;
        
        a = 872;
        b = 22;
        calculator.Multiply(a, b);
        
        a = 915;
        b = 76;
        calculator.Divide(a, b);
        
        a = 915;
        b = 0;
        calculator.Divide(a, b);
    }
}