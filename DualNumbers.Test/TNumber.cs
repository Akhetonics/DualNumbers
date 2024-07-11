using System.Globalization;
using System.Numerics;


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


