using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualISignedNumberTests
{
    private static T GetNegativeOne<T>() where T : ISignedNumber<T> => T.NegativeOne;

    [Test]
    public void ISignedNumber_NegativeOne_ReturnsExpectedDual()
    {
        Dual result = GetNegativeOne<Dual>();

        DualInterfaceAssert.AreEqual(result, -1.0, 0.0);
    }
}
