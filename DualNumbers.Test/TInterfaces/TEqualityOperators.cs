using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualNumbers;



namespace DualNumbers.Test.TInterfaces
{
   
        [TestFixture]
        public class DualEqualityOperatorsTests
        {
            [Test]
            public void EqualityOperator_TwoIdenticalDuals_ReturnsTrue()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(1.0, 2.0);

                // Act
                var result = a == b;

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void EqualityOperator_DifferentRealParts_ReturnsFalse()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(2.0, 2.0);

                // Act
                var result = a == b;

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void EqualityOperator_DifferentDualParts_ReturnsFalse()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(1.0, 3.0);

                // Act
                var result = a == b;

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void InequalityOperator_TwoIdenticalDuals_ReturnsFalse()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(1.0, 2.0);

                // Act
                var result = a != b;

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void InequalityOperator_DifferentRealParts_ReturnsTrue()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(2.0, 2.0);

                // Act
                var result = a != b;

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void InequalityOperator_DifferentDualParts_ReturnsTrue()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(1.0, 3.0);

                // Act
                var result = a != b;

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void EqualityOperator_WithNaNValues_ReturnsFalse()
            {
                // Arrange
                var a = new Dual(double.NaN, 2.0);
                var b = new Dual(double.NaN, 2.0);

                // Act
                var result = a == b;

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void EqualityOperator_WithInfinityValues_ReturnsTrue()
            {
                // Arrange
                var a = new Dual(double.PositiveInfinity, 2.0);
                var b = new Dual(double.PositiveInfinity, 2.0);

                // Act
                var result = a == b;

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void InequalityOperator_WithInfinityValues_ReturnsFalse()
            {
                // Arrange
                var a = new Dual(double.PositiveInfinity, 2.0);
                var b = new Dual(double.PositiveInfinity, 2.0);

                // Act
                var result = a != b;

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void EqualityOperator_UsingGenerics_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var b = new Dual(1.0, 2.0);

                // Act
                var result = AreEqual(a, b);

                // Assert
                Assert.That(result, Is.True);
            }

            private bool AreEqual<T>(T a, T b) where T : System.Numerics.IEqualityOperators<T, T, bool>
            {
                return a == b;
            }
        }
    }




