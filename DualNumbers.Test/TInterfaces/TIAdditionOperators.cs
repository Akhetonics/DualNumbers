using NUnit.Framework;
using System.Numerics;

namespace DualNumbers.Test
{
    [TestFixture]
    public class TDualInterfacesTests
    {
        [Test]
        public void Addition_TwoPositiveDuals_ReturnsCorrectResult()
        {
            var a = new Dual(1.0, 2.0);
            var b = new Dual(3.0, 4.0);
            var result = a + b;
            Assert.That(result.real, Is.EqualTo(4.0));
            Assert.That(result.dual, Is.EqualTo(6.0));
        }

        [Test]
        public void Addition_PositiveAndNegativeDuals_ReturnsCorrectResult()
        {
            var a = new Dual(1.0, 2.0);
            var b = new Dual(-3.0, -4.0);
            var result = a + b;
            Assert.That(result.real, Is.EqualTo(-2.0));
            Assert.That(result.dual, Is.EqualTo(-2.0));
        }

        [Test]
        public void Addition_TwoNegativeDuals_ReturnsCorrectResult()
        {
            var a = new Dual(-1.0, -2.0);
            var b = new Dual(-3.0, -4.0);
            var result = a + b;
            Assert.That(result.real, Is.EqualTo(-4.0));
            Assert.That(result.dual, Is.EqualTo(-6.0));
        }

        [Test]
        public void Addition_WithZero_ReturnsCorrectResult()
        {
            var a = new Dual(1.0, 2.0);
            var b = new Dual(0.0, 0.0);
            var result = a + b;
            Assert.That(result.real, Is.EqualTo(1.0));
            Assert.That(result.dual, Is.EqualTo(2.0));
        }

        [Test]
        public void Addition_LargeAndSmallNumbers_ReturnsCorrectResult()
        {
            var a = new Dual(1e10, 1e-10);
            var b = new Dual(1e-10, 1e10);
            var result = a + b;
            Assert.That(result.real, Is.EqualTo(1e10));
            Assert.That(result.dual, Is.EqualTo(1e10));
        }

        [Test]
        public void Addition_WithNaN_ReturnsNaN()
        {
            var a = new Dual(double.NaN, 2.0);
            var b = new Dual(3.0, 4.0);
            var result = a + b;
            Assert.That(double.IsNaN(result.real));
            Assert.That(result.dual, Is.EqualTo(6.0));
        }

        [Test]
        public void Addition_WithInfinity_ReturnsInfinity()
        {
            var a = new Dual(double.PositiveInfinity, 2.0);
            var b = new Dual(3.0, 4.0);
            var result = a + b;
            Assert.That(result.real, Is.EqualTo(double.PositiveInfinity));
            Assert.That(result.dual, Is.EqualTo(6.0));
        }

        [Test]
        public void Addition_UsingGenerics_ReturnsCorrectResult()
        {
            var a = new Dual(1.0, 2.0);
            var b = new Dual(3.0, 4.0);

            var result = Add(a, b);
            Assert.That(result.real, Is.EqualTo(4.0));
            Assert.That(result.dual, Is.EqualTo(6.0));
        }

        private T Add<T>(T a, T b) where T : IAdditionOperators<T, T, T>
        {
            return a + b;
        }
    }
}
