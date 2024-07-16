using NUnit.Framework.Legacy;

namespace DualNumbers.Test
{
    public class TDualSubstractionOperator
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
            Assert.That(result.real, Is.EqualTo(2.0).Within(1e-6));
            Assert.That(result.dual, Is.EqualTo(1.0).Within(1e-6));


        }

        [Test]
        public void SubtractionOperator_SubtractingFromItself_ReturnsZero()
        {
            // Arrange
            Dual dual = new Dual(3.0, 1.0);

            // Act
            Dual result = dual - dual;

            // Assert
            Assert.That(result.real, Is.EqualTo(0).Within(1e-6));
            Assert.That(result.dual, Is.EqualTo(0).Within(1e-6));

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
            Assert.That(result.real, Is.EqualTo(3).Within(1e-6));
            Assert.That(result.dual, Is.EqualTo(1).Within(1e-6));
           
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
            Assert.That(result.real, Is.EqualTo(-3).Within(1e-6));
            Assert.That(result.dual, Is.EqualTo(-1).Within(1e-6));
           
        }
    }
}


