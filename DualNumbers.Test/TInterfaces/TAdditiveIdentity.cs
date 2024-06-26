using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DualNumbers.Test.TInterfaces
{
    [TestFixture]
    public class DualAdditiveIdentityTests
    {
        [Test]
        public void AdditiveIdentity_IsZero()
        {
            // Arrange
            var zero = Dual.Zero;

            // Act
            var identity = Dual.AdditiveIdentity;

            // Assert
            Assert.That(identity.real, Is.EqualTo(zero.real));
            Assert.That(identity.dual, Is.EqualTo(zero.dual));
        }

        [Test]
        public void Addition_WithAdditiveIdentity_DoesNotChangeValue()
        {
            // Arrange
            var a = new Dual(3.0, 4.0);
            var identity = Dual.AdditiveIdentity;

            // Act
            var result1 = a + identity;
            var result2 = identity + a;

            // Assert
            Assert.That(result1.real, Is.EqualTo(a.real));
            Assert.That(result1.dual, Is.EqualTo(a.dual));
            Assert.That(result2.real, Is.EqualTo(a.real));
            Assert.That(result2.dual, Is.EqualTo(a.dual));
        }

        [Test]
        public void Addition_WithAdditiveIdentity_UsingGenerics_DoesNotChangeValue()
        {
            // Arrange
            var a = new Dual(3.0, 4.0);

            // Act
            var result = AddWithIdentity(a);

            // Assert
            Assert.That(result.real, Is.EqualTo(a.real));
            Assert.That(result.dual, Is.EqualTo(a.dual));
        }

        private T AddWithIdentity<T>(T a) where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
        {
            return a + T.AdditiveIdentity;
        }
    }
}

