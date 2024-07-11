using NUnit.Framework.Legacy;

namespace DualNumbers.Test
{

    public class DualUnaryPlusOperatorTests
    {
        [Test]
        public void UnaryPlusOperator_ReturnsOriginalDual()
        {
            // Arrange
            Dual dual = new Dual(5.0, 2.0);

            // Act
            Dual result = +dual;

            // Assert
            ClassicAssert.AreEqual(5.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(2.0, result.dual, 1e-6); // Check imaginary part
        }

        [Test]
        public void UnaryPlusOperator_ReturnsOriginalNegativeDual()
        {
            // Arrange
            Dual dual = new Dual(-3.0, -1.0);

            // Act
            Dual result = +dual;

            // Assert
            ClassicAssert.AreEqual(-3.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(-1.0, result.dual, 1e-6); // Check imaginary part
        }

        [Test]
        public void UnaryPlusOperator_ReturnsZeroForZeroDual()
        {
            // Arrange
            Dual zero = Dual.Zero;

            // Act
            Dual result = +zero;

            // Assert
            ClassicAssert.AreEqual(0.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(0.0, result.dual, 1e-6); // Check imaginary part
        }
    }
}


