namespace DualNumbers.Test.Interfaces;

internal static class DualInterfaceAssert
{
    private const double Tolerance = 1e-12;

    internal static void AreEqual(Dual actual, double expectedReal, double expectedDual)
    {
        Assert.That(actual.real, Is.EqualTo(expectedReal).Within(Tolerance));
        Assert.That(actual.dual, Is.EqualTo(expectedDual).Within(Tolerance));
    }
}
