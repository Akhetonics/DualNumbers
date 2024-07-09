using NUnit.Framework.Legacy;

namespace DualNumbers.Test.TInterfaces
{
    public class DualUnaryNegationOperatorTests
    {
        [Test]
        public void UnaryNegationOperator_NegateDual_ReturnsCorrectResult()
        {
            // Arrange
            Dual dual = new Dual(5.0, 2.0);

            // Act
            Dual result = -dual;

            // Assert
            ClassicAssert.AreEqual(-5.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(-2.0, result.dual, 1e-6); // Check imaginary part
        }

        [Test]
        public void UnaryNegationOperator_NegateNegativeDual_ReturnsOriginalNumber()
        {
            // Arrange
            Dual dual = new Dual(-3.0, -1.0);

            // Act
            Dual result = -dual;

            // Assert
            ClassicAssert.AreEqual(3.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(1.0, result.dual, 1e-6); // Check imaginary part
        }

        [Test]
        public void UnaryNegationOperator_NegateZero_ReturnsZero()
        {
            // Arrange
            Dual zero = Dual.Zero;

            // Act
            Dual result = -zero;

            // Assert
            ClassicAssert.AreEqual(0.0, result.real, 1e-6); // Check real part
            ClassicAssert.AreEqual(0.0, result.dual, 1e-6); // Check imaginary part
        }
    }
}



