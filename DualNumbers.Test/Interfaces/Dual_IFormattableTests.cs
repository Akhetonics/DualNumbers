using System.Globalization;
using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIFormattableTests
{
    [Test]
    public void IFormattable_ToString_MatchesComplexFormatting()
    {
        Dual value = new(12.345, -6.789);
        IFormattable asFormattable = value;

        string actual = asFormattable.ToString("F2", CultureInfo.InvariantCulture);
        string expected = new Complex(12.345, -6.789).ToString("F2", CultureInfo.InvariantCulture);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
