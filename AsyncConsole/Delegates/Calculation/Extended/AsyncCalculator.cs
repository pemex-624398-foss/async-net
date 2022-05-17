namespace AsyncConsole.Delegates.Calculation.Extended;

public class AsyncCalculator : ExtendedCalculator
{
    public AsyncCalculator(
        OperationCompleted? onOperationCompleted = default,
        OperationFailed? onOperationFailed = default) : base(onOperationCompleted, onOperationFailed)
    {
    }

    public Task<double> AddAsync(double a, double b)
    {
        return Task.Run(() => Add(a, b));
    }
    
    public Task<double> SubtractAsync(double a, double b)
    {
        return Task.Run(() => Subtract(a, b));
    }
    
    public Task<double> MultiplyAsync(double a, double b)
    {
        return Task.Run(() => Multiply(a, b));
    }
    
    public Task<double> DivideAsync(double a, double b)
    {
        return Task.Run(() => Divide(a, b));
    }
}