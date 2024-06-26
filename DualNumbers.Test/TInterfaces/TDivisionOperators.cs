using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace DualNumbers.Test.TInterfaces
    {
        [TestFixture]
        public class DualDivisionOperatorsTests
        {
            [Test]
            public void Division_TwoPositiveDuals_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(6.0, 8.0);
                var b = new Dual(3.0, 2.0);

                // Act
                var result = a / b;

                // Assert
                Assert.That(result.real, Is.EqualTo(2.0));
                Assert.That(result.dual, Is.EqualTo(2.0 / 3.0));
            }

            [Test]
            public void Division_PositiveAndNegativeDuals_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(6.0, 8.0);
                var b = new Dual(-3.0, -2.0);

                // Act
                var result = a / b;

                // Assert
                Assert.That(result.real, Is.EqualTo(-2.0));
                Assert.That(result.dual, Is.EqualTo(-2.0 / 3.0));
            }

            [Test]
            public void Division_TwoNegativeDuals_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(-6.0, -8.0);
                var b = new Dual(-3.0, -2.0);

                // Act
                var result = a / b;

                // Assert
                Assert.That(result.real, Is.EqualTo(2.0));
                Assert.That(result.dual, Is.EqualTo(-2.0 / 3.0));
            }

            [Test]
            public void Division_WithZeroRealPart_ThrowsDivideByZeroException()
            {
                // Arrange
                var a = new Dual(6.0, 8.0);
                var b = new Dual(0.0, 2.0);

                // Act & Assert
                Assert.Throws<DivideByZeroException>(() => _ = a / b);
            }

            [Test]
            public void Division_WithNaN_ReturnsNaN()
            {
                // Arrange
                var a = new Dual(double.NaN, 8.0);
                var b = new Dual(3.0, 2.0);

                // Act
                var result = a / b;

                // Assert
                Assert.That(double.IsNaN(result.real));
                Assert.That(result.dual, Is.EqualTo(double.NaN));
            }

            [Test]
            public void Division_WithInfinity_ReturnsInfinity()
            {
                // Arrange
                var a = new Dual(double.PositiveInfinity, 8.0);
                var b = new Dual(3.0, 2.0);

                // Act
                var result = a / b;

                // Assert
                Assert.That(result.real, Is.EqualTo(double.PositiveInfinity));
                Assert.That(result.dual, Is.EqualTo(double.PositiveInfinity));
            }

            [Test]
            public void Division_UsingGenerics_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(6.0, 8.0);
                var b = new Dual(3.0, 2.0);

                // Act
                var result = Divide(a, b);

                // Assert
                Assert.That(result.real, Is.EqualTo(2.0));
                Assert.That(result.dual, Is.EqualTo(2.0 / 3.0));
            }

            private T Divide<T>(T a, T b) where T : System.Numerics.IDivisionOperators<T, T, T>
            {
                return a / b;
            }
        }
    }


