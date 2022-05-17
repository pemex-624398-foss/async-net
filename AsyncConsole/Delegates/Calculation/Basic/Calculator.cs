namespace AsyncConsole.Delegates.Calculation.Basic;

public class Calculator
{
    public virtual double Add(double a, double b)
    {
        return a + b;
    }

    public virtual double Subtract(double a, double b)
    {
        return a - b;
    }

    public virtual double Multiply(double a, double b)
    {
        return a * b;
    }

    public virtual double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException();

        return a / b;
    }
}