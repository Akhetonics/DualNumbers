namespace DualNumbers.Test;

[TestFixture]
public class DualFieldsTests
{
	[Test]
	public void Zero_HasExpectedParts()
	{
		Dual result = Dual.Zero;

		Assert.That(result.real, Is.EqualTo(0d));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void One_HasExpectedParts()
	{
		Dual result = Dual.One;

		Assert.That(result.real, Is.EqualTo(1d));
		Assert.That(result.dual, Is.EqualTo(0d));
	}

	[Test]
	public void DualOne_HasExpectedParts()
	{
		Dual result = Dual.DualOne;

		Assert.That(result.real, Is.EqualTo(0d));
		Assert.That(result.dual, Is.EqualTo(1d));
	}

	[Test]
	public void Infinity_HasPositiveInfinityInBothParts()
	{
		Dual result = Dual.Infinity;

		Assert.That(double.IsPositiveInfinity(result.real), Is.True);
		Assert.That(double.IsPositiveInfinity(result.dual), Is.True);
	}

	[Test]
	public void NaN_HasNaNInBothParts()
	{
		Dual result = Dual.NaN;

		Assert.That(double.IsNaN(result.real), Is.True);
		Assert.That(double.IsNaN(result.dual), Is.True);
	}

	[Test]
	public void StandardFields_ArePairwiseDistinctValues()
	{
		Assert.That(Dual.Zero.real, Is.Not.EqualTo(Dual.One.real));
		Assert.That(Dual.Zero.dual, Is.Not.EqualTo(Dual.DualOne.dual));
		Assert.That(double.IsNaN(Dual.NaN.real), Is.True);
		Assert.That(double.IsPositiveInfinity(Dual.Infinity.real), Is.True);
	}
}
