using System;

public class FuzzyNumber
{
    public double X { get; }
    public double E1 { get; }
    public double E2 { get; }

    public FuzzyNumber(double x, double e1, double e2)
    {
        X = x;
        E1 = e1;
        E2 = e2;
    }

    public static FuzzyNumber operator +(FuzzyNumber a, FuzzyNumber b)
    {
        return new FuzzyNumber(a.X + b.X, a.E1 + b.E1, a.E2 + b.E2);
    }

    public static FuzzyNumber operator -(FuzzyNumber a, FuzzyNumber b)
    {
        return new FuzzyNumber(a.X - b.X, a.E1 + b.E1, a.E2 + b.E2);
    }

    public static FuzzyNumber operator *(FuzzyNumber a, FuzzyNumber b)
    {
        double x = a.X * b.X;
        double e1 = a.X * b.E1 + b.X * a.E1 + a.E1 * b.E1;
        double e2 = a.X * b.E2 + b.X * a.E2 + a.E2 * b.E2;
        return new FuzzyNumber(x, e1, e2);
    }

    public FuzzyNumber Inverse()
    {
        if (X <= 0)
            throw new InvalidOperationException("The inverse is defined only for positive x.");
        return new FuzzyNumber(1 / (X + E2), 1 / X, 1 / (X - E1));
    }

    public static FuzzyNumber operator /(FuzzyNumber a, FuzzyNumber b)
    {
        if (b.X <= 0)
            throw new InvalidOperationException("Division by a fuzzy number with non-positive x is undefined.");
        return new FuzzyNumber(
            (a.X - a.E1) / (b.X + b.E2),
            a.X / b.X,
            (a.X + a.E2) / (b.X - b.E1)
        );
    }

    public override string ToString()
    {
        return $"({X}, {E1}, {E2})";
    }
}
