namespace DualNumbers.Test
{

    [TestFixture]
    public class DualEquatableTests
    {
        [Test]
        public void Equals_SameValues_ReturnsTrue()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            var b = new Dual(1.0, 2.0);

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_DifferentRealParts_ReturnsFalse()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            var b = new Dual(2.0, 2.0);

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_DifferentDualParts_ReturnsFalse()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            var b = new Dual(1.0, 3.0);

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_WithObject_SameValues_ReturnsTrue()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            object b = new Dual(1.0, 2.0);

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_WithObject_DifferentRealParts_ReturnsFalse()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            object b = new Dual(2.0, 2.0);

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_WithObject_DifferentDualParts_ReturnsFalse()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            object b = new Dual(1.0, 3.0);

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_WithObject_Null_ReturnsFalse()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            object? b = null;

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_WithNonDualObject_ReturnsFalse()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            object b = new object();

            // Act
            var result = a.Equals(b);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GetHashCode_SameValues_ReturnSameHashCode()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            var b = new Dual(1.0, 2.0);

            // Act
            var hashCodeA = a.GetHashCode();
            var hashCodeB = b.GetHashCode();

            // Assert
            Assert.That(hashCodeA, Is.EqualTo(hashCodeB));
        }

        [Test]
        public void GetHashCode_DifferentRealParts_ReturnDifferentHashCodes()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            var b = new Dual(2.0, 2.0);

            // Act
            var hashCodeA = a.GetHashCode();
            var hashCodeB = b.GetHashCode();

            // Assert
            Assert.That(hashCodeA, Is.Not.EqualTo(hashCodeB));
        }

        [Test]
        public void GetHashCode_DifferentDualParts_ReturnDifferentHashCodes()
        {
            // Arrange
            var a = new Dual(1.0, 2.0);
            var b = new Dual(1.0, 3.0);

            // Act
            var hashCodeA = a.GetHashCode();
            var hashCodeB = b.GetHashCode();

            // Assert
            Assert.That(hashCodeA, Is.Not.EqualTo(hashCodeB));
        }
    }
}


