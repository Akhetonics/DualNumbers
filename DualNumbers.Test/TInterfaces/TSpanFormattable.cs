using NUnit.Framework.Legacy;
using System.Globalization;

namespace DualNumbers.Test
{
   

        [TestFixture]
        public class DualTests
        {
            [Test]
            public void TestTryFormat()
            {
                // Arrange
                var value = new Dual(1.23, 4.56); // Creating a Dual number (1.23 + 4.56ε)
                Span<char> destination = new char[100]; // Allocate a large enough buffer
                int charsWritten;
                var expectedString = Helper.ToComplex(value).ToString(); // Expected string representation of the Dual number

                // Act
                bool result = value.TryFormat(destination, out charsWritten, ReadOnlySpan<char>.Empty, null);
                var formattedString = new string(destination.Slice(0, charsWritten));

            // Assert
            Assert.That(result, Is.True); 
            Assert.That(formattedString, Is.EqualTo(expectedString));
            }
        }

    
}


