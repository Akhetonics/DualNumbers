using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualINumberBaseTests
{
    private static int GetRadix<T>() where T : INumberBase<T> => T.Radix;

    private static T GetOne<T>() where T : INumberBase<T> => T.One;

    private static T GetZero<T>() where T : INumberBase<T> => T.Zero;

    private static double GetAbs<T>(T value) where T : INumberBase<T>
        => double.CreateChecked(T.Abs(value));

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
}
