using System.Numerics;
using System.Text.RegularExpressions;

namespace DualNumbers;

public readonly partial struct Dual
{
    public static Dual Acos(Dual value)
        => new(Double.Acos(value.real), -value.dual / Math.Sqrt(1 - value.real * value.real));

    public static Dual Add(Dual left, Dual right) => left + right;
    public static Dual Add(Dual left, Double right) => left + right;
    public static Dual Add(Double left, Dual right) => left + right;

    public static Dual Asin(Dual value)
        => new(Double.Asin(value.real), value.dual / Math.Sqrt(1 - value.real * value.real));

    public static Dual Atan(Dual value)
        => new(Double.Atan(value.real), value.dual / (1 + value.real * value.real));

    public static Dual Conjugate(Dual value) => new(value.real, -value.dual);

    public static Dual Cos(Dual value) => new(Math.Cos(value.real), -Math.Sin(value.real) * value.dual);

    public static Dual Cosh(Dual value) => new(Math.Cosh(value.real), value.dual * Math.Sinh(value.real));

    public static Dual CreateChecked<TOther>(TOther value) where TOther : INumberBase<TOther>
         => throw new NotImplementedException();
    
    public static Dual CreateSaturating<TOther>(TOther value) where TOther : INumberBase<TOther>
         => throw new NotImplementedException();

    public static Dual CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>
         => throw new NotImplementedException();

    public static Dual Divide(Dual left, Dual right) => left / right;
    public static Dual Divide(Dual left, Double right) => left / right;
    public static Dual Divide(Double left, Dual right) => left / right;

    public static Dual Exp(Dual value) => new(Math.Exp(value.real), value.dual * Math.Exp(value.real));

    public static Dual FromPolarCoordinates (double magnitude, double phase) => Helper.ToDual(Complex.FromPolarCoordinates(magnitude,phase));

    public static Dual Log(Dual value) => new(Math.Log(value.real), value.dual/ value.real);
    public static Dual Log(Dual value, double baseValue) => new(Math.Log(value.real, baseValue), value.dual / (value.real * Math.Log(baseValue)));

    public static Dual Log10(Dual value) => new(Math.Log10(value.real), value.dual / (value.real * Math.Log(10)));

    public static Dual Multiply(Dual left, Dual right) => left * right;
    public static Dual Multiply(Dual left, Double right) => left * right;
    public static Dual Multiply(Double left, Dual right) => left * right;

    public static Dual Negate(Dual value) => -value;

    public static Dual Pow(Dual value, double power) => new(Math.Pow(value.real, power), value.dual * power * Math.Pow(value.real, power - 1));
    public static Dual Pow(Dual value, Dual power)
    {
        double a = value.real;
        double b = value.dual;
        double c = power.real;
        double d = power.dual;
        if (a < 0) return NaN;
        if (a == 0 && c == 0) return NaN;
        double realPart = Math.Pow(a, c);
        double dualPart = d * Math.Log(a) * Math.Pow(a, c) + b * c * Math.Pow(a, c - 1);
        return new(realPart, dualPart); 
    }

    public static Dual Reciprocal(Dual value) => new(1 / value.real, -(value.dual / (value.real * value.real)));

    public static Dual Sin(Dual value) => new(Math.Sin(value.real), value.dual * Math.Cos(value.real));

    public static Dual Sinh(Dual value) => new(Math.Sinh(value.real), value.dual * Math.Cosh(value.real));

    public static Dual Sqrt(Dual value) => new(Math.Sqrt(value.real), value.dual / (2 * Math.Sqrt(value.real)));

    public static Dual Subtract(Dual left, Dual right) => left - right;
    public static Dual Subtract(Dual left, Double right) => left - right;
    public static Dual Subtract(Double left, Dual right) => left - right;

    public static Dual Tan(Dual value) => Sin(value) / Cos(value);

    public static Dual Tanh(Dual value) => new(Math.Tanh(value.real), value.dual * (1 - Math.Pow(Math.Tanh(value.real), 2)));

    public string ToString (string? format) => Helper.ToComplex(this).ToString(format);
    public string ToString (IFormatProvider? provider) => Helper.ToComplex(this).ToString(provider);
    public override string ToString() => Helper.ToComplex(this).ToString();

    public bool TryFormat(Span<byte> utf8Destination, out int bytesWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = default)
        => Helper.ToComplex(this).TryFormat(utf8Destination, out bytesWritten, format, provider);
}
