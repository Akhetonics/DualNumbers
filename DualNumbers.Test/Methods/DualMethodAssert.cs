namespace DualNumbers.Test.Methods;

internal static class DualMethodAssert
{
    private const double Tolerance = 1e-12;

    internal static void AreEqual(Dual actual, double expectedReal, double expectedDual)
    {
        Assert.That(actual.real, Is.EqualTo(expectedReal).Within(Tolerance));
        Assert.That(actual.dual, Is.EqualTo(expectedDual).Within(Tolerance));
    }

    internal static void AreNaN(Dual actual)
    {
        Assert.That(double.IsNaN(actual.real), Is.True);
        Assert.That(double.IsNaN(actual.dual), Is.True);
    }
}
