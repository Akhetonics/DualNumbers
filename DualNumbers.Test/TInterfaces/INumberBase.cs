using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using DualNumbers;


namespace DualNumbers.Test
{

    [TestFixture]
    public class DualNumberBaseTests
    {
        private readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        [Test]
        public void Radix_ReturnsCorrectValue()
        {
            Assert.That(INumberBase<Dual>.Radix, Is.EqualTo(2));
        }

        [Test]
        public void AdditiveIdentity_ReturnsCorrectValue()
        {
            var additiveIdentity = IAdditiveIdentity<Dual, Dual>.AdditiveIdentity;
            Assert.That(additiveIdentity, Is.EqualTo(Dual.Zero));
        }

        [Test]
        public void MultiplicativeIdentity_ReturnsCorrectValue()
        {
            var multiplicativeIdentity = IMultiplicativeIdentity<Dual, Dual>.MultiplicativeIdentity;
            Assert.That(multiplicativeIdentity, Is.EqualTo(Dual.One));
        }

        [Test]
        public void Abs_ReturnsCorrectResult()
        {
            var dual = new Dual(-3.0, 4.0);
            var result = INumberBase<Dual>.Abs(dual);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void TryConvertFromChecked_ConvertsCorrectly()
        {
            double doubleValue = 3.5;
            bool success = INumberBase<Dual>.TryConvertFromChecked(doubleValue, out var result);
            Assert.That(success, Is.True);
            Assert.That(result.real, Is.EqualTo(3.5));
            Assert.That(result.dual, Is.EqualTo(0.0));
        }

        [Test]
        public void TryConvertFromSaturating_ConvertsCorrectly()
        {
            double doubleValue = double.MaxValue;
            bool success = INumberBase<Dual>.TryConvertFromSaturating(doubleValue, out var result);
            Assert.That(success, Is.True);
            Assert.That(result.real, Is.EqualTo(double.MaxValue));
            Assert.That(result.dual, Is.EqualTo(double.MaxValue));
        }

        [Test]
        public void TryConvertFromTruncating_ConvertsCorrectly()
        {
            double doubleValue = 3.5;
            bool success = INumberBase<Dual>.TryConvertFromTruncating(doubleValue, out var result);
            Assert.That(success, Is.True);
            Assert.That(result.real, Is.EqualTo(3.0));
            Assert.That(result.dual, Is.EqualTo(0.0));
        }

        [Test]
        public void TryConvertToChecked_ConvertsCorrectly()
        {
            var dual = new Dual(3.0, 4.0);
            bool success = INumberBase<Dual>.TryConvertToChecked(dual, out double result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(5.0).Within(1e-6));
        }

        [Test]
        public void TryConvertToSaturating_ConvertsCorrectly()
        {
            var dual = new Dual(double.MaxValue, double.MaxValue);
            bool success = INumberBase<Dual>.TryConvertToSaturating(dual, out float result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(float.MaxValue));
        }

        [Test]
        public void TryConvertToTruncating_ConvertsCorrectly()
        {
            var dual = new Dual(3.5, 0.0);
            bool success = INumberBase<Dual>.TryConvertToTruncating(dual, out int result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(3));
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


