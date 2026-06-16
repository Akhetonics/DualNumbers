using System.Numerics;

namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIEqualityOperatorsTests
{
    private static bool AreEqual<T>(T left, T right) where T : IEqualityOperators<T, T, bool> => left == right;

    private static bool AreNotEqual<T>(T left, T right) where T : IEqualityOperators<T, T, bool> => left != right;

    [Test]
    public void IEqualityOperators_EqualityAndInequality_WorkAsExpected()
    {
        Dual left = new(3.0, 2.0);

        Assert.That(AreEqual(left, new Dual(3.0, 2.0)), Is.True);
        Assert.That(AreNotEqual(left, new Dual(3.0, 5.0)), Is.True);
    }

    [Test]
    public void IEqualityOperators_BranchCombinations_WorkAsExpected()
    {
        Dual reference = new(3.0, 2.0);

        Assert.That(AreEqual(reference, new Dual(9.0, 2.0)), Is.False);
        Assert.That(AreEqual(reference, new Dual(3.0, 9.0)), Is.False);
        Assert.That(AreNotEqual(reference, new Dual(9.0, 2.0)), Is.True);
        Assert.That(AreNotEqual(reference, new Dual(3.0, 2.0)), Is.False);
    }
}
