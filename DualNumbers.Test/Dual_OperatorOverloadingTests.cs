namespace DualNumbers.Test;

[TestFixture]
public class DualOperatorOverloadingTests
{
	private const double Tolerance = 1e-12;

	private static void AssertDual(Dual actual, double expectedReal, double expectedDual)
	{
		Assert.That(actual.real, Is.EqualTo(expectedReal).Within(Tolerance));
		Assert.That(actual.dual, Is.EqualTo(expectedDual).Within(Tolerance));
	}

	[TestCase(1.0, 2.0, 3.0, 4.0, 2.0)]
	[TestCase(-1.0, 2.5, 3.5, 2.5, 2.5)]
	[TestCase(0.0, 0.0, 1.0, 1.0, 0.0)]
	public void OperatorPlus_DualAndDouble_ReturnsExpectedDual(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
	{
		Dual left = new(leftReal, leftDual);

		Dual result = left + right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(3.0, 1.0, 2.0, 4.0, 2.0)]
	[TestCase(3.5, -1.0, 2.5, 2.5, 2.5)]
	[TestCase(1.0, 0.0, 0.0, 1.0, 0.0)]
	public void OperatorPlus_DoubleAndDual_ReturnsExpectedDual(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
	{
		Dual right = new(rightReal, rightDual);

		Dual result = left + right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(10.0, 4.0, 2.0, 5.0, 8.0)]
	[TestCase(-9.0, 3.0, -3.0, 3.0, -9.0)]
	public void OperatorDivide_DualAndDouble_ReturnsExpectedDual(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
	{
		Dual left = new(leftReal, leftDual);

		Dual result = left / right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(10.0, 2.0, 5.0, 5.0, -50.0)]
	[TestCase(-6.0, -3.0, 2.0, 2.0, 12.0)]
	public void OperatorDivide_DoubleAndDual_ReturnsExpectedDual(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
	{
		Dual right = new(rightReal, rightDual);

		Dual result = left / right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(2.0, 3.0, 4.0, 8.0, 12.0)]
	[TestCase(-1.5, 2.0, -2.0, 3.0, -4.0)]
	public void OperatorMultiply_DualAndDouble_ReturnsExpectedDual(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
	{
		Dual left = new(leftReal, leftDual);

		Dual result = left * right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(4.0, 2.0, 3.0, 8.0, 12.0)]
	[TestCase(-2.0, -1.5, 2.0, 3.0, -4.0)]
	public void OperatorMultiply_DoubleAndDual_ReturnsExpectedDual(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
	{
		Dual right = new(rightReal, rightDual);

		Dual result = left * right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(10.0, 3.0, 4.0, 6.0, 3.0)]
	[TestCase(-1.0, 2.0, -3.0, 2.0, 2.0)]
	public void OperatorSubtract_DualAndDouble_ReturnsExpectedDual(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
	{
		Dual left = new(leftReal, leftDual);

		Dual result = left - right;

		AssertDual(result, expectedReal, expectedDual);
	}

	[TestCase(10.0, 4.0, 1.0, 6.0, -1.0)]
	[TestCase(-1.0, -3.0, 2.0, 2.0, -2.0)]
	public void OperatorSubtract_DoubleAndDual_ReturnsExpectedDual(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
	{
		Dual right = new(rightReal, rightDual);

		Dual result = left - right;

		AssertDual(result, expectedReal, expectedDual);
	}
}
