using System.Globalization;
using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualISpanFormattableTests
{
    [Test]
    public void ISpanFormattable_TryFormat_WritesExpectedText()
    {
        Dual value = new(12.345, -6.789);
        ISpanFormattable asSpanFormattable = value;
        Span<char> destination = stackalloc char[128];

        bool success = asSpanFormattable.TryFormat(destination, out int charsWritten, "F2", CultureInfo.InvariantCulture);

        string expected = new Complex(12.345, -6.789).ToString("F2", CultureInfo.InvariantCulture);
        string output = new(destination[..charsWritten]);

        Assert.That(success, Is.True);
        Assert.That(charsWritten, Is.GreaterThan(0));
        Assert.That(output, Is.EqualTo(expected));
    }
}
