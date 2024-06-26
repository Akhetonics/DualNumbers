using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DualNumbers.Test
{

        public class DualUtf8SpanParsableTests
        {
            [Test]
            public void Parse_WithValidInput_ReturnsCorrectDual()
            {
                ReadOnlySpan<byte> utf8Text = new byte[] { 51, 46, 53, 32, 43, 32, 50, 46, 48, 105 };
                var provider = CultureInfo.InvariantCulture;

                var parsedDual = Dual.Parse(utf8Text, provider);

                Assert.AreEqual(3.5, parsedDual.real, 1e-6); // Adjust tolerance as needed
                Assert.AreEqual(2.0, parsedDual.Imaginary, 1e-6); // Adjust tolerance as needed
            }

            [Test]
            public void Parse_WithInvalidInput_ThrowsException()
            {
                ReadOnlySpan<byte> utf8Text = new byte[] { 105, 110, 118, 97, 108, 105, 100, 95, 105, 110, 112, 117, 116 };
                var provider = CultureInfo.InvariantCulture;

                Assert.Throws<FormatException>(() => Dual.Parse(utf8Text, provider));
            }

            [Test]
            public void TryParse_WithValidInput_ReturnsTrueAndCorrectDual()
            {
                ReadOnlySpan<byte> utf8Text = new byte[] { 51, 46, 53, 32, 43, 32, 50, 46, 48, 105 };
                var provider = CultureInfo.InvariantCulture;

                bool success = Dual.TryParse(utf8Text, provider, out Dual result);

                Assert.IsTrue(success);
                Assert.AreEqual(3.5, result.Real, 1e-6); // Adjust tolerance as needed
                Assert.AreEqual(2.0, result.Imaginary, 1e-6); // Adjust tolerance as needed
            }

            [Test]
            public void TryParse_WithInvalidInput_ReturnsFalseAndDefaultDual()
            {
                ReadOnlySpan<byte> utf8Text = new byte[] { 105, 110, 118, 97, 108, 105, 100, 95, 105, 110, 112, 117, 116 };
                var provider = CultureInfo.InvariantCulture;

                bool success = Dual.TryParse(utf8Text, provider, out Dual result);

                Assert.IsFalse(success);
                Assert.AreEqual(default(Dual), result);
            }
        }
    }


