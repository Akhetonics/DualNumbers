using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;
using NUnit.Framework;
using DualNumbers;

namespace DualNumbers.Test
{
    [TestFixture]
    public class DualSpanFormattableTests
    {
        [Test]
        public void TryFormat_WithValidFormat_ReturnsTrueAndCorrectFormat()
        {
            var dual = new Dual(3.5, 2.0);
            Span<char> destination = new char[20];
            var format = "F2"; // Example format
            var provider = CultureInfo.InvariantCulture;

            bool success = dual.TryFormat(destination, out int charsWritten, format, provider);

            Assert.IsTrue(success);
            Assert.That(charsWritten, Is.EqualTo(9)); // Adjust this according to your expected output length

            var formattedString = new string(destination.Slice(0, charsWritten).ToArray());
            Assert.AreEqual("3.50 + 2.00i", formattedString); // Adjust this according to your expected formatted string
        }

        [Test]
        public void TryFormat_WithInvalidFormat_ReturnsFalse()
        {
            var dual = new Dual(3.5, 2.0);
            Span<char> destination = new char[20];
            var format = "XYZ"; // Invalid format
            var provider = CultureInfo.InvariantCulture;

            bool success = dual.TryFormat(destination, out int charsWritten, format, provider);

            Assert.IsFalse(success);
            Assert.That(charsWritten, Is.EqualTo(0)); // No characters written in case of failure
        }
    }
}


