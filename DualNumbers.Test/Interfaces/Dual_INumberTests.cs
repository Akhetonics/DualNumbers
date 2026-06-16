using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualINumberTests
{
    private static T Modulus<T>(T left, T right) where T : IModulusOperators<T, T, T> => left % right;

    private static bool LessThan<T>(T left, T right) where T : IComparisonOperators<T, T, bool> => left < right;

    [Test]
    public void INumber_UnsupportedOperators_ThrowNotSupportedException()
    {
        Dual left = new(2.0, 1.0);
        Dual right = new(1.0, 0.0);

        Assert.Throws<NotSupportedException>(() => _ = Modulus(left, right));
        Assert.Throws<NotSupportedException>(() => _ = LessThan(left, right));
    }
}
