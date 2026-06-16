using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIUnaryPlusOperatorsTests
{
    private static T UnaryPlus<T>(T value) where T : IUnaryPlusOperators<T, T> => +value;

    private static Dual UnaryPlusDirect(Dual value) => +value;

    [Test]
    public void IUnaryPlusOperators_UnaryPlus_ReturnsUnchangedDual()
    {
        Dual result = UnaryPlus(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, 8.0, 3.0);
    }

    [Test]
    public void OperatorUnaryPlus_DirectOperator_ReturnsUnchangedDual()
    {
        Dual result = UnaryPlusDirect(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, 8.0, 3.0);
    }
}
