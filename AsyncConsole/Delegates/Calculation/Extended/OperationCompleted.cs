namespace AsyncConsole.Delegates.Calculation.Extended;

// Method signature:
// void (CalculatorOperation, double, double, double)
public delegate void OperationCompleted(
    CalculatorOperation operation, 
    double a, 
    double b,
    double result
    );