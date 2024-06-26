using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

    namespace DualNumbers.Test
    {
        [TestFixture]
        public class DualNumberTests
        {
            private readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            [Test]
            public void Abs_ReturnsCorrectResult()
            {
                var dual = new Dual(-3.0, 4.0);
                var result = Dual.Abs(dual);
                Assert.That(result, Is.EqualTo(5.0));
            }

            [Test]
            public void IsNaN_ReturnsTrueForNaN()
            {
                var dual = new Dual(double.NaN, 2.0);
                Assert.That(Dual.IsNaN(dual), Is.True);
            }

            [Test]
            public void IsInfinity_ReturnsTrueForInfinity()
            {
                var dual = new Dual(double.PositiveInfinity, 2.0);
                Assert.That(Dual.IsInfinity(dual), Is.True);
            }

            [Test]
            public void IsZero_ReturnsTrueForZero()
            {
                var dual = new Dual(0.0, 0.0);
                Assert.That(Dual.IsZero(dual), Is.True);
            }

            [Test]
            public void MaxMagnitude_ReturnsCorrectResult()
            {
                var dual1 = new Dual(3.0, 4.0);
                var dual2 = new Dual(1.0, -2.0);
                var result = Dual.MaxMagnitude(dual1, dual2);
                Assert.That(result.real, Is.EqualTo(3.0));
                Assert.That(result.dual, Is.EqualTo(4.0));
            }

            [Test]
            public void Parse_ValidString_ReturnsCorrectDual()
            {
                var s = "1.5+2.5i";
                var result = Dual.Parse(s, NumberStyles.Any, cultureInfo);
                Assert.That(result.real, Is.EqualTo(1.5));
                Assert.That(result.dual, Is.EqualTo(2.5));
            }

            [Test]
            public void TryParse_ValidString_ReturnsTrueAndCorrectDual()
            {
                var s = "1.5+2.5i";
                var success = Dual.TryParse(s, NumberStyles.Any, cultureInfo, out var result);
                Assert.That(success, Is.True);
                Assert.That(result.real, Is.EqualTo(1.5));
                Assert.That(result.dual, Is.EqualTo(2.5));
            }

            [Test]
            public void TryParse_InvalidString_ReturnsFalseAndDefaultDual()
            {
                var s = "invalid";
                var success = Dual.TryParse(s, NumberStyles.Any, cultureInfo, out var result);
                Assert.That(success, Is.False);
                Assert.That(result, Is.EqualTo(default(Dual)));
            }

            [Test]
            public void UnsupportedOperators_ThrowNotSupportedException()
            {
                var dual1 = new Dual(1.0, 2.0);
                var dual2 = new Dual(3.0, 4.0);

                Assert.Throws<NotSupportedException>(() => { var _ = dual1 % dual2; });
                Assert.Throws<NotSupportedException>(() => { var _ = dual1 < dual2; });
                Assert.Throws<NotSupportedException>(() => { var _ = dual1 > dual2; });
                Assert.Throws<NotSupportedException>(() => { var _ = dual1 <= dual2; });
                Assert.Throws<NotSupportedException>(() => { var _ = dual1 >= dual2; });
            }
        }
    }


