using System.Globalization;
using System.Numerics;

namespace DualNumbers.Test
{

    [TestFixture]
    public class DualFormattableTests
    {
        /* [Test]
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
        */
        /*
         [Test]
         public void ToString_WithFormat_ReturnsFormattedString()
         {
             // Arrange
             var dual = new Dual(1.0, 2.0);
             var format = "F2";
             var expected = Helper.ToComplex(dual).ToString(format,null);

             // Act
             var result = dual.ToString(format, null);

             // Assert
             Assert.That(result, Is.EqualTo(expected));
         }*/


        [Test]
        public void ToString_WithFormatProvider_ReturnsFormattedString()
        {
            // Arrange
            var dual = new Dual(1.0, 2.0);
            var complex = new Complex(1.0, 2.0);
            var formatProvider = CultureInfo.InvariantCulture;
            var expected = complex.ToString(null, formatProvider);


            // Act
            var result = dual.ToString(null, formatProvider);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        /* [Test]
         public void ToString_WithFormatAndFormatProvider_ReturnsFormattedString()
         {
             // Arrange
             var dual = new Dual(1.0, 2.0);
             var complex = new Complex(1.0, 2.0);
             var format = "F2";
             var formatProvider = CultureInfo.InvariantCulture;
             var expected = Helper.ToComplex(dual).ToString(format, formatProvider);

             // Act
             var result = dual.ToString(format, formatProvider);
             Console.Write(complex.ToString(format, formatProvider));

             // Assert
             Assert.That(result, Is.EqualTo(expected));
         }*/

        [Test]
        public void ToString_WithInvalidFormat()
        {
            // Arrange
            var dual = new Dual(1.0, 2.0);
            var complex = new Complex(1.0, 2.0);
            var format = "XYZ";
            Assert.That(dual.ToString(format, null), Is.EqualTo("<XYZ; XYZ>"));

        }



    }
}



