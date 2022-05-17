using AsyncConsole.Delegates.Calculation.Extended;

namespace AsyncConsole.Delegates;

public static class CalculatorDemoV2
{
    public static void Run()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine(nameof(CalculatorDemoV2));
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();
        
        var calculator = new ExtendedCalculator(OnOperationCompleted, OnOperationFailed);
        // var calculator = new CalculatorExtended();
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

    private static void OnOperationCompleted(CalculatorOperation operation, double a, double b, double result)
    {
        var s = ExtendedCalculator.GetOperationSymbol(operation);
        Log.WriteLine($"{a} {s} {b} = {result}");
        Log.WriteLine();
    }

    private static void OnOperationFailed(CalculatorOperation operation, double a, double b, Exception exception)
    {
        var s = ExtendedCalculator.GetOperationSymbol(operation);
        Log.WriteLine($"{operation} error ({a} {s} {b}): {exception.Message}");
        Log.WriteLine();
    }
}