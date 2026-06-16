namespace DualNumbers;

public readonly partial struct Dual
{
    // Plus operator
    public static Dual operator +(Dual a, double b) => new(a.real + b, a.dual);
    public static Dual operator +(double a, Dual b) => new(a + b.real, b.dual);
    // Division operator
    public static Dual operator /(Dual a, double b) => new(a.real / b, a.dual * b);
    public static Dual operator /(double a, Dual b) => new(a / b.real, -a * b.dual);
    // Multiply operator
    public static Dual operator *(Dual a, double b) => new(a.real * b, a.dual * b);
    public static Dual operator *(double a, Dual b) => new(a * b.real, a * b.dual);
    // Subtraction operator
    public static Dual operator -(Dual a, double b) => new(a.real - b, a.dual);
    public static Dual operator -(double a, Dual b) => new(a - b.real, -b.dual);
}
