using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


    namespace DualNumbers.Test
    {
        [TestFixture]
        public class DualParsableTests
        {
            private readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            [Test]
            public void Parse_WithValidString_ReturnsCorrectDual()
            {
                string input = "3.5+2.5i";
                var result = Dual.Parse(input, cultureInfo);
                Assert.That(result.real, Is.EqualTo(3.5).Within(1e-6));
                Assert.That(result.dual, Is.EqualTo(2.5).Within(1e-6));
            }

            [Test]
            public void Parse_WithInvalidString_ThrowsFormatException()
            {
                string input = "invalid";
                Assert.Throws<FormatException>(() => Dual.Parse(input, cultureInfo));
            }

            [Test]
            public void TryParse_WithValidString_ReturnsTrueAndCorrectDual()
            {
                string input = "3.5+2.5i";
                bool success = Dual.TryParse(input, cultureInfo, out var result);
                Assert.That(success, Is.True);
                Assert.That(result.real, Is.EqualTo(3.5).Within(1e-6));
                Assert.That(result.dual, Is.EqualTo(2.5).Within(1e-6));
            }

            [Test]
            public void TryParse_WithInvalidString_ReturnsFalseAndDefaultDual()
            {
                string input = "invalid";
                bool success = Dual.TryParse(input, cultureInfo, out var result);
                Assert.That(success, Is.False);
                Assert.That(result, Is.EqualTo(default(Dual)));
            }
        }
    }

