using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIDivisionOperatorsTests
{
    private static T Divide<T>(T left, T right) where T : IDivisionOperators<T, T, T> => left / right;

    [Test]
    public void IDivisionOperators_Divide_ReturnsExpectedDual()
    {
        Dual result = Divide(new Dual(8.0, 3.0), new Dual(2.0, 1.0));

        DualInterfaceAssert.AreEqual(result, 4.0, -2.0);
    }
}
