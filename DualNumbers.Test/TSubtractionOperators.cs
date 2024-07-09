using NUnit.Framework.Legacy;

namespace DualNumbers.Tests
{
    public class DualTests
    {
        [Test]
        public void SubtractionOperator_SubtractingDualNumbers_ReturnsCorrectResult()
        {
            // Arrange
            Dual dual1 = new Dual(5.0, 2.0);
            Dual dual2 = new Dual(3.0, 1.0);

            // Act
            Dual result = dual1 - dual2;

            // Assert
             ClassicAssert.AreEqual(2.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(1.0, result.dual, 1e-6); // Check dual part
        }

        [Test]
        public void SubtractionOperator_SubtractingFromItself_ReturnsZero()
        {
            // Arrange
            Dual dual = new Dual(3.0, 1.0);

            // Act
            Dual result = dual - dual;

            // Assert
            ClassicAssert.AreEqual(0.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(0.0, result.dual, 1e-6); // Check dual part
        }

        [Test]
        public void SubtractionOperator_SubtractingZero_ReturnsOriginalDualNumber()
        {
            // Arrange
            Dual dual = new Dual(3.0, 1.0);
            Dual zero = Dual.Zero;

            // Act
            Dual result = dual - zero;

            // Assert
            ClassicAssert.AreEqual(3.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(1.0, result.dual, 1e-6); // Check dual part
        }

        [Test]
        public void SubtractionOperator_SubtractingFromZero_ReturnsNegativeOfDualNumber()
        {
            // Arrange
            Dual dual = new Dual(3.0, 1.0);
            Dual zero = Dual.Zero;

            // Act
            Dual result = zero - dual;

            // Assert
            ClassicAssert.AreEqual(-3.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(-1.0, result.dual, 1e-6); // Check dual part
        }
    }
}


