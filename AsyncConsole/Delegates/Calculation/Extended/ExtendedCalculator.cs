using AsyncConsole.Delegates.Calculation.Basic;

namespace AsyncConsole.Delegates.Calculation.Extended;

public class ExtendedCalculator : Calculator
{
    private readonly OperationCompleted? _onOperationCompleted;
    private readonly OperationFailed? _onOperationFailed;

    public ExtendedCalculator(
        OperationCompleted? onOperationCompleted = default,
        OperationFailed? onOperationFailed = default
        )
    {
        _onOperationCompleted = onOperationCompleted;
        _onOperationFailed = onOperationFailed;
    }
    
    public static string GetOperationSymbol(CalculatorOperation operation)
    {
        return operation switch
        {
            CalculatorOperation.Addition => "+",
            CalculatorOperation.Subtraction => "-",
            CalculatorOperation.Multiplication => "*",
            CalculatorOperation.Division => "/",
            _ => "?"
        };
    }

    public override double Add(double a, double b)
    {
        var r = base.Add(a, b);
        _onOperationCompleted?.Invoke(CalculatorOperation.Addition, a, b, r);
        return r;
    }

    public override double Subtract(double a, double b)
    {
        var r = base.Subtract(a, b);
        _onOperationCompleted?.Invoke(CalculatorOperation.Subtraction, a, b, r);
        return r;
    }

    public override double Multiply(double a, double b)
    {
        var r = base.Multiply(a, b);
        _onOperationCompleted?.Invoke(CalculatorOperation.Multiplication, a, b, r);
        return r;
    }

    public override double Divide(double a, double b)
    {
        try
        {
            var r = base.Divide(a, b);
            _onOperationCompleted?.Invoke(CalculatorOperation.Division, a, b, r);
            return r;
        }
        catch (Exception exception)
        {
            if (_onOperationFailed == default) throw;
            
            _onOperationFailed.Invoke(CalculatorOperation.Division, a, b, exception);
            return double.NaN;
        }
    }
}