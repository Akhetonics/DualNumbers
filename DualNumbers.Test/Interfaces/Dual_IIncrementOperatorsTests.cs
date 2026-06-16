using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIIncrementOperatorsTests
{
    private static T Increment<T>(T value) where T : IIncrementOperators<T> => ++value;

    [Test]
    public void IIncrementOperators_Increment_IncreasesRealPartOnly()
    {
        Dual result = Increment(new Dual(8.0, 3.0));

        DualInterfaceAssert.AreEqual(result, 9.0, 3.0);
    }
}
