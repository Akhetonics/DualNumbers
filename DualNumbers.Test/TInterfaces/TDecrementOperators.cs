using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;



namespace DualNumbers.Test.TInterfaces
{
    [TestFixture]
    public class DualDecrementOperatorsTests
    {
        [Test]
        public void DecrementOperator_DecrementsRealPartByOne()
        {
            // Arrange
            var a = new Dual(5.0, 3.0);

            // Act
            var result = --a;

            // Assert
            Assert.That(result.real, Is.EqualTo(4.0));
            Assert.That(result.dual, Is.EqualTo(3.0));
        }

        [Test]
        public void DecrementOperator_DecrementsNegativeRealPartByOne()
        {
            // Arrange
            var a = new Dual(-2.0, 3.0);

            // Act
            var result = --a;

            // Assert
            Assert.That(result.real, Is.EqualTo(-3.0));
            Assert.That(result.dual, Is.EqualTo(3.0));
        }

        [Test]
        public void DecrementOperator_DecrementsZeroRealPartToNegativeOne()
        {
            // Arrange
            var a = new Dual(0.0, 3.0);

            // Act
            var result = --a;

            // Assert
            Assert.That(result.real, Is.EqualTo(-1.0));
            Assert.That(result.dual, Is.EqualTo(3.0));
        }

        [Test]
        public void DecrementOperator_DoesNotChangeDualPart()
        {
            // Arrange
            var a = new Dual(5.0, 3.0);

            // Act
            var result = --a;

            // Assert
            Assert.That(result.dual, Is.EqualTo(3.0));
        }

        [Test]
        public void DecrementOperator_UsingGenerics_ReturnsCorrectResult()
        {
            // Arrange
            var a = new Dual(5.0, 3.0);

            // Act
            var result = Decrement(a);

            // Assert
            Assert.That(result.real, Is.EqualTo(4.0));
            Assert.That(result.dual, Is.EqualTo(3.0));
        }

        private T Decrement<T>(T value) where T : IDecrementOperators<T>
        {
            return --value;
        }
    }
}

