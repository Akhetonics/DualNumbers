using System.Globalization;


namespace DualNumbers.Test
{
    [TestFixture]
    public class DualParsableTests
    {
        private readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;


        [Test]
        public void TryParse_WithInvalidString_ReturnsFalseAndDefaultDual()
        {
            string input = "invalid";
            bool success = Dual.TryParse(input, cultureInfo, out var result);
            Assert.That(success, Is.False);
            Assert.That(result, Is.EqualTo(default(Dual)));
        }
    }
}

