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
}
