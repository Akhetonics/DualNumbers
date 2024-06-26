using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualNumbers.Test
{
  
        [TestFixture]
        public class DualFormattableTests
        {
            [Test]
            public void ToString_WithNullFormatAndProvider_ReturnsDefaultString()
            {
                // Arrange
                var dual = new Dual(1.0, 2.0);
                var expected = Helper.ToComplex(dual).ToString(null, null);

                // Act
                var result = dual.ToString(null, null);

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void ToString_WithFormat_ReturnsFormattedString()
            {
                // Arrange
                var dual = new Dual(1.0, 2.0);
                var format = "F2";
                var expected = Helper.ToComplex(dual).ToString(format, null);

                // Act
                var result = dual.ToString(format, null);

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void ToString_WithFormatProvider_ReturnsFormattedString()
            {
                // Arrange
                var dual = new Dual(1.0, 2.0);
                var formatProvider = CultureInfo.InvariantCulture;
                var expected = Helper.ToComplex(dual).ToString(null, formatProvider);

                // Act
                var result = dual.ToString(null, formatProvider);

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void ToString_WithFormatAndFormatProvider_ReturnsFormattedString()
            {
                // Arrange
                var dual = new Dual(1.0, 2.0);
                var format = "F2";
                var formatProvider = CultureInfo.InvariantCulture;
                var expected = Helper.ToComplex(dual).ToString(format, formatProvider);

                // Act
                var result = dual.ToString(format, formatProvider);

                // Assert
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void ToString_WithInvalidFormat_ThrowsFormatException()
            {
                // Arrange
                var dual = new Dual(1.0, 2.0);
                var format = "InvalidFormat";

                // Act & Assert
                Assert.Throws<FormatException>(() => dual.ToString(format, null));
            }
        }

        // Helper class to simulate the Helper.ToComplex method
        public static class Helper
        {
            public static Complex ToComplex(Dual dual)
            {
                return new Complex(dual.real, dual.dual);
            }
        }

        // Complex struct to simulate the complex number conversion
        public struct Complex
        {
            private readonly double real;
            private readonly double imaginary;

            public Complex(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public override string ToString()
            {
                return $"({real}, {imaginary})";
            }

            public string ToString(string? format, IFormatProvider? formatProvider)
            {
                if (format == null)
                    return ToString();

                return $"({real.ToString(format, formatProvider)}, {imaginary.ToString(format, formatProvider)})";
            }
        }
    }


