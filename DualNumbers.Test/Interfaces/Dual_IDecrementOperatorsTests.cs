using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIDecrementOperatorsTests
{
    private static T Decrement<T>(T value) where T : IDecrementOperators<T> => --value;

    [Test]
    public void IDecrementOperators_Decrement_ReducesRealPartOnly()
    {
        Dual result = Decrement(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, 7.0, 3.0);
    }
}
