using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualISubtractionOperatorsTests
{
    private static T Subtract<T>(T left, T right) where T : ISubtractionOperators<T, T, T> => left - right;

    [Test]
    public void ISubtractionOperators_Subtract_ReturnsExpectedDual()
    {
        Dual result = Subtract(new Dual(8.0, 3.0), new Dual(2.0, 1.0));

        DualInterfaceAssert.AreEqual(result, 6.0, 2.0);
    }
}
