namespace DualNumbers.Test.Methods;

[TestFixture]
public class DualArithmeticMethodsTests
{
    [TestCase(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
    [TestCase(-1.0, 2.5, 3.1, -4.0, 2.1, -1.5)]
    [TestCase(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
    public void Add_DualDual_ReturnsExpected(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Add(new Dual(leftReal, leftDual), new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(1.0, 2.0, 3.0, 4.0, 2.0)]
    [TestCase(-1.0, 2.5, 3.5, 2.5, 2.5)]
    [TestCase(0.0, 0.0, 1.0, 1.0, 0.0)]
    public void Add_DualDouble_ReturnsExpected(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Add(new Dual(leftReal, leftDual), right);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(3.0, 1.0, 2.0, 4.0, 2.0)]
    [TestCase(3.5, -1.0, 2.5, 2.5, 2.5)]
    [TestCase(1.0, 0.0, 0.0, 1.0, 0.0)]
    public void Add_DoubleDual_ReturnsExpected(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Add(left, new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(2.0, 3.0, 5.0, 7.0, 10.0, 29.0)]
    [TestCase(-1.0, 4.0, 6.0, -2.0, -6.0, 26.0)]
    public void Multiply_DualDual_ReturnsExpected(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Multiply(new Dual(leftReal, leftDual), new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(2.0, 3.0, 4.0, 8.0, 12.0)]
    [TestCase(-1.5, 2.0, -2.0, 3.0, -4.0)]
    public void Multiply_DualDouble_ReturnsExpected(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Multiply(new Dual(leftReal, leftDual), right);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(4.0, 2.0, 3.0, 8.0, 12.0)]
    [TestCase(-2.0, -1.5, 2.0, 3.0, -4.0)]
    public void Multiply_DoubleDual_ReturnsExpected(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Multiply(left, new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(4.0, 3.0, 2.0, 5.0, 2.0, -14.0)]
    [TestCase(10.0, -1.0, 2.0, 3.0, 5.0, -32.0)]
    public void Divide_DualDual_ReturnsExpected(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Divide(new Dual(leftReal, leftDual), new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(10.0, 4.0, 2.0, 5.0, 8.0)]
    [TestCase(-9.0, 3.0, -3.0, 3.0, -9.0)]
    public void Divide_DualDouble_ReturnsExpected(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Divide(new Dual(leftReal, leftDual), right);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(10.0, 2.0, 5.0, 5.0, -50.0)]
    [TestCase(-6.0, -3.0, 2.0, 2.0, 12.0)]
    public void Divide_DoubleDual_ReturnsExpected(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Divide(left, new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(10.0, 3.0, 4.0, 1.0, 6.0, 2.0)]
    [TestCase(-1.0, 2.0, -3.0, 4.0, 2.0, -2.0)]
    public void Subtract_DualDual_ReturnsExpected(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Subtract(new Dual(leftReal, leftDual), new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(10.0, 3.0, 4.0, 6.0, 3.0)]
    [TestCase(-1.0, 2.0, -3.0, 2.0, 2.0)]
    public void Subtract_DualDouble_ReturnsExpected(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Subtract(new Dual(leftReal, leftDual), right);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(10.0, 4.0, 1.0, 6.0, -1.0)]
    [TestCase(-1.0, -3.0, 2.0, 2.0, -2.0)]
    public void Subtract_DoubleDual_ReturnsExpected(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Subtract(left, new Dual(rightReal, rightDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(4.0, -3.5, 4.0, 3.5)]
    [TestCase(-2.0, 5.0, -2.0, -5.0)]
    public void Conjugate_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Conjugate(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(3.0, -4.0, -3.0, 4.0)]
    [TestCase(-2.5, 8.0, 2.5, -8.0)]
    public void Negate_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Negate(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(4.0, 2.0, 0.25, -0.125)]
    [TestCase(-2.0, 6.0, -0.5, -1.5)]
    public void Reciprocal_ReturnsExpected(double real, double dual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Reciprocal(new Dual(real, dual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(4.0, 3.0, 2.0, 16.0, 24.0)]
    [TestCase(9.0, 2.0, 0.5, 3.0, 0.3333333333333333)]
    public void Pow_DualDouble_ReturnsExpected(double real, double dual, double power, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Pow(new Dual(real, dual), power);

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(4.0, 3.0, 2.0, 1.0, 16.0, 46.18070977791825)]
    [TestCase(9.0, 1.5, 0.5, -2.0, 3.0, -12.933347464017316)]
    public void Pow_DualDual_ReturnsExpected(double valueReal, double valueDual, double powerReal, double powerDual, double expectedReal, double expectedDual)
    {
        Dual result = Dual.Pow(new Dual(valueReal, valueDual), new Dual(powerReal, powerDual));

        DualMethodAssert.AreEqual(result, expectedReal, expectedDual);
    }

    [TestCase(-2.0, 1.0, 3.0, 1.0)]
    [TestCase(0.0, 1.0, 0.0, 1.0)]
    public void Pow_DualDual_InvalidInputs_ReturnNaN(double valueReal, double valueDual, double powerReal, double powerDual)
    {
        Dual result = Dual.Pow(new Dual(valueReal, valueDual), new Dual(powerReal, powerDual));

        DualMethodAssert.AreNaN(result);
    }
}
