using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIAdditiveIdentityTests
{
    private static T GetAdditiveIdentity<T>() where T : IAdditiveIdentity<T, T> => T.AdditiveIdentity;

    [Test]
    public void IAdditiveIdentity_AdditiveIdentity_IsZero()
    {
        Dual result = GetAdditiveIdentity<Dual>();

        DualInterfaceAssert.AreEqual(result, 0.0, 0.0);
    }
}
