using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using DualNumbers;

    namespace DualNumbers.Test
    {
        [TestFixture]
        public class DualSignedNumberTests
        {
            [Test]
            public void NegativeOne_Property_ReturnsCorrectValue()
            {
                var negativeOne = Dual.NegativeOne;
                Assert.That(negativeOne.real, Is.EqualTo(-1.0).Within(1e-6));
                Assert.That(negativeOne.dual, Is.EqualTo(0.0).Within(1e-6));
            }

            [Test]
            public void SignedValueOf_WithPositiveValue_ReturnsPositive()
            {
                var dual = new Dual(2.0, 0.0);
                Assert.That(dual.SignedValueOf(), Is.EqualTo(1));
            }

            [Test]
            public void SignedValueOf_WithNegativeValue_ReturnsNegative()
            {
                var dual = new Dual(-2.0, 0.0);
                Assert.That(dual.SignedValueOf(), Is.EqualTo(-1));
            }

            [Test]
            public void IsNegative_WithNegativeDual_ReturnsTrue()
            {
                var dual = new Dual(-2.0, 0.0);
                Assert.That(dual.IsNegative(), Is.True);
            }

            [Test]
            public void IsNegative_WithPositiveDual_ReturnsFalse()
            {
                var dual = new Dual(2.0, 0.0);
                Assert.That(dual.IsNegative(), Is.False);
            }

            [Test]
            public void IsNegative_WithZeroDual_ReturnsFalse()
            {
                var dual = new Dual(0.0, 0.0);
                Assert.That(dual.IsNegative(), Is.False);
            }
        }
    }


