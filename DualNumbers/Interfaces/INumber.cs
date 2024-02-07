using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : INumber<Dual>
{
    public static int Radix => throw new NotImplementedException();

    static Dual INumberBase<Dual>.One => throw new NotImplementedException();

    static Dual INumberBase<Dual>.Zero => throw new NotImplementedException();

    public static double Abs(Dual value)
    {
        Complex c = new(value.real, value.dual);
        return Complex.Abs(c);
        //return new(c.Real, c.Imaginary);
    }

    public static bool IsCanonical(Dual value)
    {
        throw new NotSupportedException();
    }

    public static bool IsComplexNumber(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsComplexNumber(tmp);
    }

    public static bool IsEvenInteger(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsEvenInteger(tmp);
    }

    public static bool IsFinite(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsFinite(tmp);
    }

    public static bool IsImaginaryNumber(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsImaginaryNumber(tmp);
    }

    public static bool IsInfinity(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsInfinity(tmp);
    }

    public static bool IsInteger(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsInteger(tmp);
    }

    public static bool IsNaN(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsNaN(tmp);
    }

    public static bool IsNegative(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsNegative(tmp);
    }

    public static bool IsNegativeInfinity(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsNegativeInfinity(tmp);
    }

    public static bool IsNormal(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsNormal(tmp);
    }

    public static bool IsOddInteger(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsOddInteger(tmp);
    }

    public static bool IsPositive(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsPositive(tmp);
    }

    public static bool IsPositiveInfinity(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsPositiveInfinity(tmp);
    }

    public static bool IsRealNumber(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsRealNumber(tmp);
    }

    public static bool IsSubnormal(Dual value)
    {
        Complex tmp = new(value.real, value.dual);
        return Complex.IsSubnormal(tmp);
    }

    public static bool IsZero(Dual value)
    {
        return value == Zero;
    }

    public static Dual MaxMagnitude(Dual x, Dual y)
    {
        Complex xComplex = new(x.real, x.dual);
        Complex yComplex = new(y.real, y.dual);
        var tmp = Complex.MaxMagnitude(xComplex, yComplex);
        return new(tmp.Real, tmp.Imaginary);
    }

    public static Dual MaxMagnitudeNumber(Dual x, Dual y)
    {
        throw new NotSupportedException();
    }

    public static Dual MinMagnitude(Dual x, Dual y)
    {
        Complex xComplex = new(x.real, x.dual);
        Complex yComplex = new(y.real, y.dual);
        var tmp = Complex.MinMagnitude(xComplex, yComplex);
        return new(tmp.Real, tmp.Imaginary);
    }

    public static Dual MinMagnitudeNumber(Dual x, Dual y)
    {
        throw new NotSupportedException();
    }

    public static Dual Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        Complex tmp = Complex.Parse(s, style, provider);
        return new Dual(tmp.Real, tmp.Imaginary);
    }

    public static Dual Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        Complex tmp = Complex.Parse(s, style, provider);
        return new Dual(tmp.Real, tmp.Imaginary);
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Dual result)
    {
        bool tmp = Complex.TryParse(s, style, provider, out Complex compResult);
        result = new(compResult.Real, compResult.Imaginary);
        return tmp;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Dual result)
    {
        bool tmp = Complex.TryParse(s, style, provider, out Complex compResult);
        result = new(compResult.Real, compResult.Imaginary);
        return tmp;
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Dual other)
    {
        throw new NotImplementedException();
    }

    public static Dual operator %(Dual left, Dual right)
    {
        throw new NotSupportedException("Modular operator is not well defined in this number space.");
    }

    public static bool operator <(Dual left, Dual right)
    {
        throw new NotSupportedException("Smaller-Than operator is not well defined in this number space.");
    }

    public static bool operator >(Dual left, Dual right)
    {
        throw new NotSupportedException("Greater-Than operator is not well defined in this number space.");
    }

    public static bool operator <=(Dual left, Dual right)
    {
        throw new NotSupportedException("Smaller-Or-Equal-To operator is not well defined in this number space.");
    }

    public static bool operator >=(Dual left, Dual right)
    {
        throw new NotSupportedException("Greater-OrEqual-To operator is not well defined in this number space.");
    }
}