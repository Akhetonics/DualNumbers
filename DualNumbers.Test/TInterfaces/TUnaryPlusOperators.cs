using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Assert.AreEqual(5.0, result.Real, 1e-6); // Check real part
                Assert.AreEqual(2.0, result.Imaginary, 1e-6); // Check imaginary part
            }

            [Test]
            public void UnaryPlusOperator_ReturnsOriginalNegativeDual()
            {
                // Arrange
                Dual dual = new Dual(-3.0, -1.0);

                // Act
                Dual result = +dual;

                // Assert
                Assert.AreEqual(-3.0, result.Real, 1e-6); // Check real part
                Assert.AreEqual(-1.0, result.Imaginary, 1e-6); // Check imaginary part
            }

            [Test]
            public void UnaryPlusOperator_ReturnsZeroForZeroDual()
            {
                // Arrange
                Dual zero = Dual.Zero;

                // Act
                Dual result = +zero;

                // Assert
                Assert.AreEqual(0.0, result.Real, 1e-6); // Check real part
                Assert.AreEqual(0.0, result.Imaginary, 1e-6); // Check imaginary part
            }
        }
    }


