using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIDecrementOperatorsTests
{
    private static T Decrement<T>(T value) where T : IDecrementOperators<T> => --value;

    private static Dual DecrementDirect(Dual value) => --value;

    [Test]
    public void IDecrementOperators_Decrement_ReducesRealPartOnly()
    {
        Dual result = Decrement(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, 7.0, 3.0);
    }

    [Test]
    public void OperatorDecrement_DirectOperator_ReducesRealPartOnly()
    {
        Dual result = DecrementDirect(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, 7.0, 3.0);
    }
}
