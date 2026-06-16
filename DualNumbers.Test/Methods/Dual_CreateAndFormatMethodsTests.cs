using System.Globalization;
using System.Numerics;
using System.Text;

namespace DualNumbers.Test.Methods;

[TestFixture]
public class DualCreateAndFormatMethodsTests
{
    [TestCase(3.25, 3.25, 0.0)]
    [TestCase(-7.5, -7.5, 0.0)]
    public void CreateChecked_FromDouble_ReturnsExpected(double value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateChecked(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(3.25f, 3.25, 0.0)]
    [TestCase(-7.5f, -7.5, 0.0)]
    public void CreateChecked_FromFloat_ReturnsExpected(float value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateChecked(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(7, 7.0, 0.0)]
    [TestCase(-13, -13.0, 0.0)]
    public void CreateChecked_FromInt_ReturnsExpected(int value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateChecked(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    private static IEnumerable<TestCaseData> CreateCheckedComplexCases()
    {
        yield return new TestCaseData(new Complex(2.0, -5.0), 2.0, -5.0);
        yield return new TestCaseData(new Complex(-3.5, 0.25), -3.5, 0.25);
    }

    [TestCaseSource(nameof(CreateCheckedComplexCases))]
    public void CreateChecked_FromComplex_ReturnsExpected(Complex value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateChecked(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(7L)]
    [TestCase(-4L)]
    public void CreateChecked_UnsupportedType_ThrowsNotSupportedException(long value)
    {
        Assert.Throws<NotSupportedException>(() => Dual.CreateChecked(value));
    }

    [TestCase(3.25, 3.25, 0.0)]
    [TestCase(-7.5, -7.5, 0.0)]
    public void CreateSaturating_FromDouble_ReturnsExpected(double value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateSaturating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(3.25f, 3.25, 0.0)]
    [TestCase(-7.5f, -7.5, 0.0)]
    public void CreateSaturating_FromFloat_ReturnsExpected(float value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateSaturating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(7, 7.0, 0.0)]
    [TestCase(-13, -13.0, 0.0)]
    public void CreateSaturating_FromInt_ReturnsExpected(int value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateSaturating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    private static IEnumerable<TestCaseData> CreateSaturatingComplexCases()
    {
        yield return new TestCaseData(new Complex(2.5, -7.75), 2.5, -7.75);
        yield return new TestCaseData(new Complex(-1.5, 3.125), -1.5, 3.125);
    }

    [TestCaseSource(nameof(CreateSaturatingComplexCases))]
    public void CreateSaturating_FromComplex_ReturnsExpected(Complex value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateSaturating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(7L)]
    [TestCase(-4L)]
    public void CreateSaturating_UnsupportedType_ThrowsInvalidOperationException(long value)
    {
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Dual.CreateSaturating(value))!;

        Assert.That(ex.InnerException, Is.TypeOf<NotSupportedException>());
    }

    [TestCase(9.99, 9.0, 0.0)]
    [TestCase(-2.01, -2.0, 0.0)]
    public void CreateTruncating_FromDouble_ReturnsExpected(double value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateTruncating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(9.99f, 9.0, 0.0)]
    [TestCase(-2.01f, -2.0, 0.0)]
    public void CreateTruncating_FromFloat_ReturnsExpected(float value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateTruncating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(7, 7.0, 0.0)]
    [TestCase(-13, -13.0, 0.0)]
    public void CreateTruncating_FromInt_ReturnsExpected(int value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateTruncating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    private static IEnumerable<TestCaseData> CreateTruncatingComplexCases()
    {
        yield return new TestCaseData(new Complex(2.9, -7.2), 2.0, -7.0);
        yield return new TestCaseData(new Complex(-1.1, 3.9), -1.0, 3.0);
    }

    [TestCaseSource(nameof(CreateTruncatingComplexCases))]
    public void CreateTruncating_FromComplex_ReturnsExpected(Complex value, double expectedReal, double expectedDual)
    {
        Dual result = Dual.CreateTruncating(value);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(7L)]
    [TestCase(-4L)]
    public void CreateTruncating_UnsupportedType_ThrowsInvalidOperationException(long value)
    {
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Dual.CreateTruncating(value))!;

        Assert.That(ex.InnerException, Is.TypeOf<NotSupportedException>());
    }

    [TestCase(2.0, 0.5, 1.7551651237807455, 0.958851077208406)]
    [TestCase(1.0, 0.0, 1.0, 0.0)]
    public void FromPolarCoordinates_ReturnsExpected(double magnitude, double phase, double expectedReal, double expectedDual)
    {
        Dual result = Dual.FromPolarCoordinates(magnitude, phase);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase("G")]
    [TestCase("F2")]
    public void ToString_WithFormat_MatchesComplex(string format)
    {
        Dual value = new(12.345, -6.789);

        string result = value.ToString(format);
        string expected = new Complex(12.345, -6.789).ToString(format);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("en-US")]
    [TestCase("de-DE")]
    public void ToString_WithProvider_MatchesComplex(string cultureName)
    {
        Dual value = new(12.345, -6.789);
        IFormatProvider provider = CultureInfo.GetCultureInfo(cultureName);

        string result = value.ToString(provider);
        string expected = new Complex(12.345, -6.789).ToString(provider);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(12.345, -6.789)]
    [TestCase(-1.0, 2.5)]
    public void ToString_Override_MatchesComplex(double real, double dual)
    {
        Dual value = new(real, dual);

        string result = value.ToString();
        string expected = new Complex(real, dual).ToString();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("G")]
    [TestCase("F2")]
    public void TryFormat_WritesExpectedUtf8Output(string format)
    {
        Dual value = new(12.345, -6.789);
        byte[] buffer = new byte[128];

        bool success = value.TryFormat(buffer, out int bytesWritten, format, CultureInfo.InvariantCulture);

        Assert.That(success, Is.True);
        Assert.That(bytesWritten, Is.GreaterThan(0));

        string output = Encoding.UTF8.GetString(buffer.AsSpan(0, bytesWritten));
        string expected = new Complex(12.345, -6.789).ToString(format, CultureInfo.InvariantCulture);
        Assert.That(output, Is.EqualTo(expected));
    }
}
