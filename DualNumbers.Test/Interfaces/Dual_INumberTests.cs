using System.Numerics;
using System.Globalization;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualINumberTests
{
    private static T Modulus<T>(T left, T right) where T : IModulusOperators<T, T, T> => left % right;

    private static bool LessThan<T>(T left, T right) where T : IComparisonOperators<T, T, bool> => left < right;

    private const double Tolerance = 1e-12;

    private static void AssertDualMatchesComplex(Dual actual, Complex expected)
    {
        Assert.That(actual.real, Is.EqualTo(expected.Real).Within(Tolerance));
        Assert.That(actual.dual, Is.EqualTo(expected.Imaginary).Within(Tolerance));
    }

    private static bool GreaterThan(Dual left, Dual right) => left > right;

    private static bool LessThanOrEqual(Dual left, Dual right) => left <= right;

    private static bool GreaterThanOrEqual(Dual left, Dual right) => left >= right;

    [Test]
    public void INumber_UnsupportedOperators_ThrowNotSupportedException()
    {
        Dual left = new(2.0, 1.0);
        Dual right = new(1.0, 0.0);

        Assert.Throws<NotSupportedException>(() => _ = Modulus(left, right));
        Assert.Throws<NotSupportedException>(() => _ = LessThan(left, right));
        Assert.Throws<NotSupportedException>(() => _ = GreaterThan(left, right));
        Assert.Throws<NotSupportedException>(() => _ = LessThanOrEqual(left, right));
        Assert.Throws<NotSupportedException>(() => _ = GreaterThanOrEqual(left, right));
    }

    [Test]
    public void INumber_PredicateMembers_MatchComplexImplementations()
    {
        Dual value = new(2.0, 3.0);
        Complex expected = new(2.0, 3.0);

        Assert.That(Dual.IsComplexNumber(value), Is.EqualTo(Complex.IsComplexNumber(expected)));
        Assert.That(Dual.IsEvenInteger(value), Is.EqualTo(Complex.IsEvenInteger(expected)));
        Assert.That(Dual.IsFinite(value), Is.EqualTo(Complex.IsFinite(expected)));
        Assert.That(Dual.IsImaginaryNumber(value), Is.EqualTo(Complex.IsImaginaryNumber(expected)));
        Assert.That(Dual.IsInfinity(value), Is.EqualTo(Complex.IsInfinity(expected)));
        Assert.That(Dual.IsInteger(value), Is.EqualTo(Complex.IsInteger(expected)));
        Assert.That(Dual.IsNaN(value), Is.EqualTo(Complex.IsNaN(expected)));
        Assert.That(Dual.IsNegative(value), Is.EqualTo(Complex.IsNegative(expected)));
        Assert.That(Dual.IsNegativeInfinity(value), Is.EqualTo(Complex.IsNegativeInfinity(expected)));
        Assert.That(Dual.IsNormal(value), Is.EqualTo(Complex.IsNormal(expected)));
        Assert.That(Dual.IsOddInteger(value), Is.EqualTo(Complex.IsOddInteger(expected)));
        Assert.That(Dual.IsPositive(value), Is.EqualTo(Complex.IsPositive(expected)));
        Assert.That(Dual.IsPositiveInfinity(value), Is.EqualTo(Complex.IsPositiveInfinity(expected)));
        Assert.That(Dual.IsRealNumber(value), Is.EqualTo(Complex.IsRealNumber(expected)));
        Assert.That(Dual.IsSubnormal(value), Is.EqualTo(Complex.IsSubnormal(expected)));
        Assert.That(Dual.IsZero(Dual.Zero), Is.True);
    }

    [Test]
    public void INumber_AbsAndMagnitudeMethods_MatchComplex()
    {
        Dual x = new(3.0, 4.0);
        Dual y = new(2.0, -10.0);
        Complex cx = new(3.0, 4.0);
        Complex cy = new(2.0, -10.0);

        Assert.That(Dual.Abs(x), Is.EqualTo(Complex.Abs(cx)).Within(Tolerance));
        AssertDualMatchesComplex(Dual.MaxMagnitude(x, y), Complex.MaxMagnitude(cx, cy));
        AssertDualMatchesComplex(Dual.MinMagnitude(x, y), Complex.MinMagnitude(cx, cy));
    }

    [Test]
    public void INumber_ParseAndTryParse_WithNumberStyles_MatchComplex()
    {
        Complex expected = new(3.5, -2.25);
        string text = expected.ToString(CultureInfo.InvariantCulture);
        NumberStyles style = NumberStyles.Float | NumberStyles.AllowParentheses;

        Dual parsedFromString = Dual.Parse(text, style, CultureInfo.InvariantCulture);
        Dual parsedFromSpan = Dual.Parse(text.AsSpan(), style, CultureInfo.InvariantCulture);
        bool tryStringOk = Dual.TryParse(text, style, CultureInfo.InvariantCulture, out Dual tryParsedString);
        bool trySpanOk = Dual.TryParse(text.AsSpan(), style, CultureInfo.InvariantCulture, out Dual tryParsedSpan);

        Assert.That(tryStringOk, Is.True);
        Assert.That(trySpanOk, Is.True);
        AssertDualMatchesComplex(parsedFromString, expected);
        AssertDualMatchesComplex(parsedFromSpan, expected);
        AssertDualMatchesComplex(tryParsedString, expected);
        AssertDualMatchesComplex(tryParsedSpan, expected);
    }

    [Test]
    public void INumber_UnsupportedMembers_ThrowNotSupportedException()
    {
        Dual left = new(2.0, 1.0);
        Dual right = new(1.0, 0.0);

        Assert.Throws<NotSupportedException>(() => _ = Dual.IsCanonical(left));
        Assert.Throws<NotSupportedException>(() => _ = Dual.MaxMagnitudeNumber(left, right));
        Assert.Throws<NotSupportedException>(() => _ = Dual.MinMagnitudeNumber(left, right));
        Assert.Throws<NotSupportedException>(() => _ = left.CompareTo((object?)right));
        Assert.Throws<NotSupportedException>(() => _ = left.CompareTo(right));
    }
}
