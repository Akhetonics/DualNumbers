using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIMultiplyOperatorsTests
{
    private static T Multiply<T>(T left, T right) where T : IMultiplyOperators<T, T, T> => left * right;

    [Test]
    public void IMultiplyOperators_Multiply_ReturnsExpectedDual()
    {
        Dual result = Multiply(new Dual(8.0, 3.0), new Dual(2.0, 1.0));

        DualInterfaceAssert.AreEqual(result, 16.0, 14.0);
    }
}
