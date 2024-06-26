using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DualNumbers.Test.TInterfaces
{

        [TestFixture]
        public class DualMultiplyOperatorsTests
        {
            [Test]
            public void Multiply_TwoPositiveDuals_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(2.0, 3.0);
                var b = new Dual(4.0, 5.0);
                var expected = new Dual(8.0, 22.0);

                // Act
                var result = a * b;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Multiply_PositiveAndNegativeDuals_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(2.0, 3.0);
                var b = new Dual(-4.0, -5.0);
                var expected = new Dual(-8.0, -2.0);

                // Act
                var result = a * b;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Multiply_TwoNegativeDuals_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(-2.0, -3.0);
                var b = new Dual(-4.0, -5.0);
                var expected = new Dual(8.0, 22.0);

                // Act
                var result = a * b;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Multiply_WithZero_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(2.0, 3.0);
                var b = new Dual(0.0, 0.0);
                var expected = new Dual(0.0, 0.0);

                // Act
                var result = a * b;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Multiply_LargeAndSmallNumbers_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(1e10, 1e-10);
                var b = new Dual(1e-10, 1e10);
                var expected = new Dual(1.0, 2.0);

                // Act
                var result = a * b;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Multiply_WithNaN_ReturnsNaN()
            {
                // Arrange
                var a = new Dual(double.NaN, 3.0);
                var b = new Dual(4.0, 5.0);
                var result = a * b;

                // Assert
                Assert.That(double.IsNaN(result.real));
                Assert.That(result.dual, Is.EqualTo(double.NaN));
            }

            [Test]
            public void Multiply_WithInfinity_ReturnsInfinity()
            {
                // Arrange
                var a = new Dual(double.PositiveInfinity, 3.0);
                var b = new Dual(4.0, 5.0);
                var expectedReal = double.PositiveInfinity;
                var expectedDual = double.PositiveInfinity;

                // Act
                var result = a * b;

                // Assert
                Assert.That(result.real, Is.EqualTo(expectedReal));
                Assert.That(result.dual, Is.EqualTo(expectedDual));
            }

            [Test]
            public void Multiply_UsingGenerics_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(2.0, 3.0);
                var b = new Dual(4.0, 5.0);
                var expected = new Dual(8.0, 22.0);

                // Act
                var result = Multiply(a, b);

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            private T Multiply<T>(T a, T b) where T : IMultiplyOperators<T, T,T>
            {
                return a * b;
            }
        }

        // Dual struct with multiplication operator implementation
        public readonly partial struct Dual
        {
            public Dual(double real, double dual)
            {
                this.real = real;
                this.dual = dual;
            }

            public double real { get; }
            public double dual { get; }

            public static Dual operator *(Dual a, Dual b)
                => new Dual(a.real * b.real, a.real * b.dual + a.dual * b.real);
        }
    }


