namespace DualNumbers.Test;

public class TDualMethods
{
    [TestFixture]
    public class DualTests
    {
        [TestCase(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
        [TestCase(-1.0, 2.5, 3.1, -4.0, 2.1, -1.5)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        public void Add_TwoDuals_ReturnsCorrectDual(double leftReal, double leftDual, double rightReal, double rightDual, double expectedReal, double expectedDual)
        {
            var left = new Dual(leftReal, leftDual);
            var right = new Dual(rightReal, rightDual);
            var expected = new Dual(expectedReal, expectedDual);

            var result = Dual.Add(left, right);

            
           //Standard testcases
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
            Assert.That(result.real, Is.Not.EqualTo(-1));
            Assert.That(result.dual, Is.Not.EqualTo(-1));
            

        }

        [TestCase(1.0, 2.0, 3.0, 4.0, 2.0)]
        [TestCase(-1.0, 2.5, 3.5, 2.5, 2.5)]
        [TestCase(0.0, 0.0, 1.0, 1.0, 0.0)]
        public void Add_DualAndDouble_ReturnsCorrectDual(double leftReal, double leftDual, double right, double expectedReal, double expectedDual)
        {
            var left = new Dual(leftReal, leftDual);
            var expected = new Dual(expectedReal, expectedDual);

            var result = Dual.Add(left, right);

            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        }

        [TestCase(3.0, 1.0, 2.0, 4.0, 2.0)]
        [TestCase(3.5, -1.0, 2.5, 2.5, 2.5)]
        [TestCase(1.0, 0.0, 0.0, 1.0, 0.0)]
        public void Add_DoubleAndDual_ReturnsCorrectDual(double left, double rightReal, double rightDual, double expectedReal, double expectedDual)
        {
            var right = new Dual(rightReal, rightDual);
            var expected = new Dual(expectedReal, expectedDual);

            var result = Dual.Add(left, right);

            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        }
    }
}