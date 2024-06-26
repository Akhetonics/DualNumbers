using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;

namespace DualNumbers.Test

{

    [TestFixture]
    public class DualSpanParsableTests
    {
        [Test]
        public void Parse_WithValidInput_ReturnsCorrectDual()
        {
            ReadOnlySpan<char> input = "3.5 + 2.0i";
            var provider = CultureInfo.InvariantCulture;

            var parsedDual = Dual.Parse(input, provider);

            Assert.AreEqual(3.5, parsedDual.real, 1e-6); // Adjust tolerance as needed
            Assert.AreEqual(2.0, parsedDual.Imaginary, 1e-6); // Adjust tolerance as needed
        }

        [Test]
        public void Parse_WithInvalidInput_ThrowsException()
        {
            ReadOnlySpan<char> input = "invalid_input";
            var provider = CultureInfo.InvariantCulture;

            Assert.Throws<FormatException>(() => Dual.Parse(input, provider));
        }

        [Test]
        public void TryParse_WithValidInput_ReturnsTrueAndCorrectDual()
        {
            ReadOnlySpan<char> input = "3.5 + 2.0i";
            var provider = CultureInfo.InvariantCulture;

            bool success = Dual.TryParse(input, provider, out Dual result);

            Assert.IsTrue(success);
            Assert.AreEqual(3.5, result.Real, 1e-6); // Adjust tolerance as needed
            Assert.AreEqual(2.0, result.Imaginary, 1e-6); // Adjust tolerance as needed
        }

        [Test]
        public void TryParse_WithInvalidInput_ReturnsFalseAndDefaultDual()
        {
            ReadOnlySpan<char> input = "invalid_input";
            var provider = CultureInfo.InvariantCulture;

            bool success = Dual.TryParse(input, provider, out Dual result);

            Assert.IsFalse(success);
            Assert.AreEqual(default(Dual), result);
        }
    }
}


