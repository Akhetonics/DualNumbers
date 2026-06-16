using System.Numerics;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualINumberBaseTests
{
    private static int GetRadix<T>() where T : INumberBase<T> => T.Radix;

    private static T GetOne<T>() where T : INumberBase<T> => T.One;

    private static T GetZero<T>() where T : INumberBase<T> => T.Zero;

    private static double GetAbs<T>(T value) where T : INumberBase<T>
        => double.CreateChecked(T.Abs(value));

    private static bool IsFinite<T>(T value) where T : INumberBase<T> => T.IsFinite(value);

    private static bool IsZero<T>(T value) where T : INumberBase<T> => T.IsZero(value);

    private static T ParseFromString<T>(string s, NumberStyles style, IFormatProvider? provider) where T : INumberBase<T>
        => T.Parse(s, style, provider);

    private static T ParseFromSpan<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) where T : INumberBase<T>
        => T.Parse(s, style, provider);

    private static bool TryParseFromString<T>(string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) where T : INumberBase<T>
        => T.TryParse(s, style, provider, out result);

    private static bool TryParseFromSpan<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) where T : INumberBase<T>
        => T.TryParse(s, style, provider, out result);

    [Test]
    public void INumberBase_RadixOneAndZero_ReturnExpectedValues()
    {
        Assert.That(GetRadix<Dual>(), Is.EqualTo(2));
        DualInterfaceAssert.AreEqual(GetOne<Dual>(), 1.0, 0.0);
        DualInterfaceAssert.AreEqual(GetZero<Dual>(), 0.0, 0.0);
    }

    [Test]
    public void INumberBase_Abs_UsesMagnitude()
    {
        double abs = GetAbs(new Dual(3.0, 4.0));

        Assert.That(abs, Is.EqualTo(5.0).Within(1e-12));
    }

    [Test]
    public void INumberBase_IsFiniteAndIsZero_WorkAsExpected()
    {
        Assert.That(IsFinite(new Dual(1.0, 0.0)), Is.True);
        Assert.That(IsFinite(new Dual(double.PositiveInfinity, 0.0)), Is.False);
        Assert.That(IsZero(Dual.Zero), Is.True);
    }

    [Test]
    public void INumberBase_ParseAndTryParse_WithNumberStyles_WorkAsExpected()
    {
        Complex expected = new(3.5, -2.25);
        string text = expected.ToString(CultureInfo.InvariantCulture);
        NumberStyles style = NumberStyles.Float | NumberStyles.AllowParentheses;

        Dual parsedFromString = ParseFromString<Dual>(text, style, CultureInfo.InvariantCulture);
        Dual parsedFromSpan = ParseFromSpan<Dual>(text.AsSpan(), style, CultureInfo.InvariantCulture);
        bool tryStringOk = TryParseFromString<Dual>(text, style, CultureInfo.InvariantCulture, out Dual tryParsedFromString);
        bool trySpanOk = TryParseFromSpan<Dual>(text.AsSpan(), style, CultureInfo.InvariantCulture, out Dual tryParsedFromSpan);

        Assert.That(tryStringOk, Is.True);
        Assert.That(trySpanOk, Is.True);
        DualInterfaceAssert.AreEqual(parsedFromString, expected.Real, expected.Imaginary);
        DualInterfaceAssert.AreEqual(parsedFromSpan, expected.Real, expected.Imaginary);
        DualInterfaceAssert.AreEqual(tryParsedFromString, expected.Real, expected.Imaginary);
        DualInterfaceAssert.AreEqual(tryParsedFromSpan, expected.Real, expected.Imaginary);
    }

    [Test]
    public void INumberBase_ExplicitTryConvertFromMethods_WorkAsExpected()
    {
        bool checkedOk = Dual.TryConvertFromChecked(3.25d, out Dual checkedResult);
        bool saturatingOk = Dual.TryConvertFromSaturating(new Complex(double.PositiveInfinity, double.NegativeInfinity), out Dual saturatingResult);
        bool truncatingOk = Dual.TryConvertFromTruncating(new Complex(2.9, -7.2), out Dual truncatingResult);

        Assert.That(checkedOk, Is.True);
        Assert.That(saturatingOk, Is.True);
        Assert.That(truncatingOk, Is.True);
        DualInterfaceAssert.AreEqual(checkedResult, 3.25, 0.0);
        DualInterfaceAssert.AreEqual(saturatingResult, double.MaxValue, double.MinValue);
        DualInterfaceAssert.AreEqual(truncatingResult, 2.0, -7.0);
    }

    [Test]
    public void INumberBase_ExplicitTryConvertToMethods_WorkAsExpected()
    {
        bool checkedOk = Dual.TryConvertToChecked(new Dual(3.0, 4.0), out int checkedResult);
        bool saturatingOk = Dual.TryConvertToSaturating(new Dual(1e308, 1e308), out int saturatingResult);
        bool truncatingOk = Dual.TryConvertToTruncating(new Dual(3.0, 4.0), out Complex truncatingResult);

        Assert.That(checkedOk, Is.True);
        Assert.That(saturatingOk, Is.True);
        Assert.That(truncatingOk, Is.True);
        Assert.That(checkedResult, Is.EqualTo(5));
        Assert.That(saturatingResult, Is.EqualTo(int.MaxValue));
        Assert.That(truncatingResult, Is.EqualTo(new Complex(3.0, 4.0)));
    }
}
