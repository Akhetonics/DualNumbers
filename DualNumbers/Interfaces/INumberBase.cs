using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace DualNumbers;

public readonly partial struct Dual : System.Numerics.INumberBase<Dual>
{
    static int INumberBase<Dual>.Radix => Radix;

    static Dual IAdditiveIdentity<Dual, Dual>.AdditiveIdentity => AdditiveIdentity;

    static Dual IMultiplicativeIdentity<Dual, Dual>.MultiplicativeIdentity => MultiplicativeIdentity;

    static Dual INumberBase<Dual>.Abs(Dual value) => Abs(value);

    static bool INumberBase<Dual>.IsCanonical(Dual value) => IsCanonical(value);

    static bool INumberBase<Dual>.IsComplexNumber(Dual value) => IsComplexNumber(value);

    static bool INumberBase<Dual>.IsEvenInteger(Dual value) => IsEvenInteger(value);

    static bool INumberBase<Dual>.IsFinite(Dual value) => IsFinite(value);

    static bool INumberBase<Dual>.IsImaginaryNumber(Dual value) => IsImaginaryNumber(value);

    static bool INumberBase<Dual>.IsInfinity(Dual value) => IsInfinity(value);

    static bool INumberBase<Dual>.IsInteger(Dual value) => IsInteger(value);

    static bool INumberBase<Dual>.IsNaN(Dual value) => IsNaN(value);

    static bool INumberBase<Dual>.IsNegative(Dual value) => IsNegative(value);

    static bool INumberBase<Dual>.IsNegativeInfinity(Dual value) => IsNegativeInfinity(value);

    static bool INumberBase<Dual>.IsNormal(Dual value) => IsNormal(value);

    static bool INumberBase<Dual>.IsOddInteger(Dual value) => IsOddInteger(value);

    static bool INumberBase<Dual>.IsPositive(Dual value) => IsPositive(value);

    static bool INumberBase<Dual>.IsPositiveInfinity(Dual value) => IsPositiveInfinity(value);

    static bool INumberBase<Dual>.IsRealNumber(Dual value) => IsRealNumber(value);

    static bool INumberBase<Dual>.IsSubnormal(Dual value) => IsSubnormal(value);

    static bool INumberBase<Dual>.IsZero(Dual value) => IsZero(value);

    static Dual INumberBase<Dual>.MaxMagnitude(Dual x, Dual y) => MaxMagnitude(x, y);

    static Dual INumberBase<Dual>.MaxMagnitudeNumber(Dual x, Dual y) => MaxMagnitudeNumber(x, y);

    static Dual INumberBase<Dual>.MinMagnitude(Dual x, Dual y) => MinMagnitude(x, y);

    static Dual INumberBase<Dual>.MinMagnitudeNumber(Dual x, Dual y) => MinMagnitudeNumber(x, y);

    static Dual INumberBase<Dual>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        => Parse(s, style, provider);

    static Dual INumberBase<Dual>.Parse(string s, NumberStyles style, IFormatProvider? provider)
        => Parse(s, style, provider);

    static Dual ISpanParsable<Dual>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => Parse(s, provider);

    static Dual IParsable<Dual>.Parse(string s, IFormatProvider? provider)
        => Parse(s, provider);

    static Dual IUtf8SpanParsable<Dual>.Parse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider)
        => Parse(utf8Text, provider);

    static bool INumberBase<Dual>.TryConvertFromChecked<TOther>(TOther value, out Dual result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Dual>.TryConvertFromSaturating<TOther>(TOther value, out Dual result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Dual>.TryConvertFromTruncating<TOther>(TOther value, out Dual result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Dual>.TryConvertToChecked<TOther>(Dual value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Dual>.TryConvertToSaturating<TOther>(Dual value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Dual>.TryConvertToTruncating<TOther>(Dual value, out TOther result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<Dual>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Dual result)
        => TryParse(s, style, provider, out result);

    static bool INumberBase<Dual>.TryParse(string? s, NumberStyles style, IFormatProvider? provider, out Dual result)
        => TryParse(s, style, provider, out result);

    static bool ISpanParsable<Dual>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Dual result)
        => TryParse(s, provider, out result);

    static bool IParsable<Dual>.TryParse(string? s, IFormatProvider? provider, out Dual result)
        => TryParse(s, provider, out result);

    static bool IUtf8SpanParsable<Dual>.TryParse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider, out Dual result)
        => TryParse(utf8Text, provider, out result);

    bool IEquatable<Dual>.Equals(Dual other) => Equals(other);

    string IFormattable.ToString(string? format, IFormatProvider? formatProvider) => ToString(format, formatProvider);

    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out charsWritten, format, provider);

    static Dual IUnaryPlusOperators<Dual, Dual>.operator +(Dual value) => value;

    static Dual IAdditionOperators<Dual, Dual, Dual>.operator +(Dual left, Dual right) => left + right;

    static Dual IUnaryNegationOperators<Dual, Dual>.operator -(Dual value) => new(-value.real, -value.dual);

    static Dual ISubtractionOperators<Dual, Dual, Dual>.operator -(Dual left, Dual right) => left - right;

    static Dual IIncrementOperators<Dual>.operator ++(Dual value) => new(value.real + 1, value.dual);

    static Dual IDecrementOperators<Dual>.operator --(Dual value) => new(value.real - 1, value.dual);

    static Dual IMultiplyOperators<Dual, Dual, Dual>.operator *(Dual left, Dual right) => left * right;

    static Dual IDivisionOperators<Dual, Dual, Dual>.operator /(Dual left, Dual right) => left / right;

    static bool IEqualityOperators<Dual, Dual, bool>.operator ==(Dual left, Dual right) => left == right;

    static bool IEqualityOperators<Dual, Dual, bool>.operator !=(Dual left, Dual right) => left != right;
}