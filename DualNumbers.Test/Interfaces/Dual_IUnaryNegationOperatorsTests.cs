using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIUnaryNegationOperatorsTests
{
    private static T Negate<T>(T value) where T : IUnaryNegationOperators<T, T> => -value;

    [Test]
    public void IUnaryNegationOperators_UnaryMinus_ReturnsNegatedDual()
    {
        Dual result = Negate(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, -8.0, -3.0);
    }
}
