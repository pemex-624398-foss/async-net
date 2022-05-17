namespace AsyncConsole.Delegates.Calculation.Extended;

// Method signature:
// void (CalculatorOperation, double, double, Exception)
public delegate void OperationFailed(
    CalculatorOperation operation,
    double a,
    double b, 
    Exception exception
    );