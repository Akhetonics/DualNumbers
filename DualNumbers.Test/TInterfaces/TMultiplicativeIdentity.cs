using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using DualNumbers;

namespace DualNumbers.Test;


[TestFixture]
public class DualMultiplicativeIdentityTests
{
    [Test]
    public void MultiplicativeIdentity_ReturnsOne()
    {
        // Arrange
        var expected = new Dual(1, 0);

        // Act
        var result = Dual.MultiplicativeIdentity;

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        });
    }

    [Test]
    public void MultiplyByIdentity_ReturnsSameValue()
    {
        // Arrange
        var a = new Dual(3.0, 4.0);
        var identity = Dual.MultiplicativeIdentity;
        var expected = new Dual(3.0, 4.0);

        // Act
        var result = a * identity;

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        });
    }

    [Test]
    public void IdentityMultipliedByValue_ReturnsSameValue()
    {
        // Arrange
        var a = new Dual(3.0, 4.0);
        var identity = Dual.MultiplicativeIdentity;
        var expected = new Dual(3.0, 4.0);

        // Act
        var result = identity * a;

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result.real, Is.EqualTo(expected.real));
            Assert.That(result.dual, Is.EqualTo(expected.dual));
        });
    }
}

// Dual struct with multiplication operator implementation



