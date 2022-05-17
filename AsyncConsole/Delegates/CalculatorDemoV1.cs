using AsyncConsole.Delegates.Calculation.Basic;

namespace AsyncConsole.Delegates;

public static class CalculatorDemoV1
{
    public static void Run()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine(nameof(CalculatorDemoV1));
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        var calculator = new Calculator();
        double a = 0, b = 0, r = 0;
        
        Log.WriteLine($"a = {a}, b = {b}, r = {r}");
        Log.WriteLine();

        a = 2;
        b = 3;
        r = calculator.Add(a, b);
        Log.WriteLine($"{a} + {b} = {r}");
        Log.WriteLine();
        
        a = 20;
        b = 14;
        r = calculator.Subtract(a, b);
        Log.WriteLine($"{a} - {b} = {r}");
        Log.WriteLine();
        
        a = 18;
        b = 13;
        r = calculator.Multiply(a, b);
        Log.WriteLine($"{a} * {b} = {r}");
        Log.WriteLine();
        
        a = 284;
        b = 72;
        r = calculator.Divide(a, b);
        Log.WriteLine($"{a} / {b} = {r}");
        Log.WriteLine();
        
        a = 284;
        b = 0;
        r = calculator.Divide(a, b);
        Log.WriteLine($"{a} / {b} = {r}");
        Log.WriteLine();
    }
}