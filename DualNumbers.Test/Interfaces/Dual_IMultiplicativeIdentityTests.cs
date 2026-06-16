using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIMultiplicativeIdentityTests
{
    private static T GetMultiplicativeIdentity<T>() where T : IMultiplicativeIdentity<T, T> => T.MultiplicativeIdentity;

    [Test]
    public void IMultiplicativeIdentity_MultiplicativeIdentity_IsOne()
    {
        Dual result = GetMultiplicativeIdentity<Dual>();

        DualInterfaceAssert.AreEqual(result, 1.0, 0.0);
    }
}
