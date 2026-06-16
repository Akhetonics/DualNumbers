namespace DualNumbers.Test.Interfaces;

[TestFixture]
public class DualIEquatableTests
{
    private static bool EqualsViaInterface<T>(T left, T right) where T : IEquatable<T> => left.Equals(right);

    [Test]
    public void IEquatable_Equals_WorkAsExpected()
    {
        Dual left = new(3.0, 2.0);

        Assert.That(EqualsViaInterface(left, new Dual(3.0, 2.0)), Is.True);
        Assert.That(EqualsViaInterface(left, new Dual(3.0, 5.0)), Is.False);
    }

    [Test]
    public void IEquatable_EqualsObjectAndHashCode_WorkAsExpected()
    {
        Dual left = new(3.0, 2.0);
        object same = new Dual(3.0, 2.0);
        object different = new Dual(3.0, 5.0);

        Assert.That(left.Equals(same), Is.True);
        Assert.That(left.Equals(different), Is.False);
        Assert.That(left.GetHashCode(), Is.EqualTo(((Dual)same).GetHashCode()));
    }

    [Test]
    public void IEquatable_EqualsObject_BranchesForNullAndDifferentType()
    {
        Dual left = new(3.0, 2.0);

        Assert.That(left.Equals(null), Is.False);
        Assert.That(left.Equals("not-a-dual"), Is.False);
        Assert.That(left.Equals(new Dual(9.0, 2.0)), Is.False);
    }
}
