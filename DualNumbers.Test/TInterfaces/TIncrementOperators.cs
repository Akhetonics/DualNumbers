using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualNumbers.Test
{

        [TestFixture]
        public class DualIncrementOperatorsTests
        {
            [Test]
            public void Increment_PositiveReal_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(1.0, 2.0);
                var expected = new Dual(2.0, 2.0);

                // Act
                var result = ++a;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Increment_NegativeReal_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(-1.0, 2.0);
                var expected = new Dual(0.0, 2.0);

                // Act
                var result = ++a;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Increment_ZeroReal_ReturnsCorrectResult()
            {
                // Arrange
                var a = new Dual(0.0, 2.0);
                var expected = new Dual(1.0, 2.0);

                // Act
                var result = ++a;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Increment_PositiveInfinityReal_ReturnsInfinity()
            {
                // Arrange
                var a = new Dual(double.PositiveInfinity, 2.0);
                var expected = new Dual(double.PositiveInfinity, 2.0);

                // Act
                var result = ++a;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Increment_NegativeInfinityReal_ReturnsNegativeInfinity()
            {
                // Arrange
                var a = new Dual(double.NegativeInfinity, 2.0);
                var expected = new Dual(double.NegativeInfinity, 2.0);

                // Act
                var result = ++a;

                // Assert
                Assert.That(result.real, Is.EqualTo(expected.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }

            [Test]
            public void Increment_NaNReal_ReturnsNaN()
            {
                // Arrange
                var a = new Dual(double.NaN, 2.0);
                var expected = new Dual(double.NaN, 2.0);

                // Act
                var result = ++a;

                // Assert
                Assert.That(double.IsNaN(result.real));
                Assert.That(result.dual, Is.EqualTo(expected.dual));
            }
        }
    }


