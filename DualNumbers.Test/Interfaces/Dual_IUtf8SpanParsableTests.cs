using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIUtf8SpanParsableTests
{
    private static T ParseViaInterface<T>(ReadOnlySpan<byte> s, IFormatProvider? provider) where T : IUtf8SpanParsable<T>
        => T.Parse(s, provider);

    private static bool TryParseViaInterface<T>(ReadOnlySpan<byte> s, IFormatProvider? provider, [MaybeNullWhen(false)] out T result)
        where T : IUtf8SpanParsable<T>
        => T.TryParse(s, provider, out result);

    [Test]
    public void IUtf8SpanParsable_ParseAndTryParse_ReturnExpectedDual()
    {
        Complex expected = new(3.5, -2.25);
        string text = expected.ToString(CultureInfo.InvariantCulture);
        byte[] utf8 = Encoding.UTF8.GetBytes(text);

        Dual parsed = ParseViaInterface<Dual>(utf8, CultureInfo.InvariantCulture);
        bool ok = TryParseViaInterface<Dual>(utf8, CultureInfo.InvariantCulture, out Dual tryParsed);

        Assert.That(ok, Is.True);
        DualInterfaceAssert.AreEqual(parsed, expected.Real, expected.Imaginary);
        DualInterfaceAssert.AreEqual(tryParsed, expected.Real, expected.Imaginary);
    }
}
