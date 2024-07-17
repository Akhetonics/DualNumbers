using System.Globalization;
using System.Numerics;
using DualNumbers;


namespace DualNumbers.Test

{
    [TestFixture]

    
    
    public  class DualNumberBaseTests 
    {
        //readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;
        

        [Test]
        public void Radix_ReturnsCorrectValue()
        {
            Assert.That(Dual.Radix, expression: Is.EqualTo(2));   
        }

        [Test]
        public void AdditiveIdentity_ReturnsCorrectValue()
        {
            var additiveIdentity = Dual.AdditiveIdentity;
            Assert.That(additiveIdentity, Is.EqualTo(Dual.Zero));
        }

        [Test]
        public void MultiplicativeIdentity_ReturnsCorrectValue()
        {
            var multiplicativeIdentity = Dual.MultiplicativeIdentity;
            Assert.That(multiplicativeIdentity, Is.EqualTo(Dual.One));
        }

        [Test]
        public void Abs_ReturnsCorrectResult()
        {
            var dual = new Dual(-3.0, 4.0);
            var result = Dual.Abs(dual);
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void TryConvertFromChecked_ConvertsCorrectly()
        {
            double doubleValue = 3.5;
            INumberBase<Dual> NumberBase = new Dual();
            Dual value;
            bool success = Dual.TryConvertFromChecked<double>(doubleValue, out var result);


            Assert.That(success, Is.True);
            Assert.That(result.real, Is.EqualTo(3.5));
            Assert.That(result.dual, Is.EqualTo(0.0));
        }

        [Test]
        public void TryConvertFromSaturating_ConvertsCorrectly()
        {
            double doubleValue = double.MaxValue;
                
            INumberBase<Dual> NumberBase = new Dual(); 
            bool success = Dual.TryConvertFromSaturating<double>(doubleValue, out var result);
            Assert.That(success, Is.True);
            Assert.That(result.real, Is.EqualTo(double.MaxValue));
            Assert.That(result.dual, Is.EqualTo(0));
        }

        [Test]
        public void TryConvertFromTruncating_ConvertsCorrectly()
        {
            double doubleValue = 3.5;
            bool success = Dual.TryConvertFromTruncating<double>(doubleValue, out var result);
            Assert.That(success, Is.True);
            Assert.That(result.real, Is.EqualTo(3.0));
            Assert.That(result.dual, Is.EqualTo(0));
        }

        [Test]
        public void TryConvertToChecked_ConvertsCorrectly()
        {
            Dual dual = new Dual(3.0, 4.0);
            bool success = Dual.TryConvertToChecked(dual, out double result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(5.0).Within(1e-6));
        }

        [Test]
        public void TryConvertToSaturating_ConvertsCorrectly()
        {
            Dual dual = new Dual(double.MaxValue, double.MaxValue);
            bool success = Dual.TryConvertToSaturating<float>(dual, out float result);
            Assert.That(success, Is.True);
            Assert.That(result, Is.EqualTo(float.MaxValue));
        }

        [Test]
        public void TryConvertToTruncating_ConvertsCorrectly()
        {
            var dual = new Dual(3.5, 0.0);
            bool success = Dual.TryConvertToTruncating<int>(dual, out int result);
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
