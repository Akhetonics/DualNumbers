using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualISpanParsableTests
{
    private static T ParseViaInterface<T>(ReadOnlySpan<char> s, IFormatProvider? provider) where T : ISpanParsable<T>
        => T.Parse(s, provider);

    private static bool TryParseViaInterface<T>(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out T result)
        where T : ISpanParsable<T>
        => T.TryParse(s, provider, out result);

    [Test]
    public void ISpanParsable_ParseAndTryParse_ReturnExpectedDual()
    {
        Complex expected = new(3.5, -2.25);
        string text = expected.ToString(CultureInfo.InvariantCulture);

        Dual parsed = ParseViaInterface<Dual>(text.AsSpan(), CultureInfo.InvariantCulture);
        bool ok = TryParseViaInterface<Dual>(text.AsSpan(), CultureInfo.InvariantCulture, out Dual tryParsed);

        Assert.That(ok, Is.True);
        DualInterfaceAssert.AreEqual(parsed, expected.Real, expected.Imaginary);
        DualInterfaceAssert.AreEqual(tryParsed, expected.Real, expected.Imaginary);
    }
}
