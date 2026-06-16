using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIAdditionOperatorsTests
{
    private static T Add<T>(T left, T right) where T : IAdditionOperators<T, T, T> => left + right;

    [Test]
    public void IAdditionOperators_Add_ReturnsExpectedDual()
    {
        Dual result = Add(new Dual(8.0, 3.0), new Dual(2.0, 1.0));

        DualInterfaceAssert.AreEqual(result, 10.0, 4.0);
    }
}
