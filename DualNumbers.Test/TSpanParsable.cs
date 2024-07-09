using NUnit.Framework.Legacy;
using System.Globalization;

namespace DualNumbers.Test

{

    [TestFixture]
    public class DualSpanParsableTests
    {



        [Test]
        public void TryParse_WithInvalidInput_ReturnsFalseAndDefaultDual()
        {
            ReadOnlySpan<char> input = "invalid_input";
            var provider = CultureInfo.InvariantCulture;

            bool success = Dual.TryParse(input, provider, out Dual result);

            ClassicAssert.IsFalse(success);
            ClassicAssert.AreEqual(default(Dual), result);
        }
    }
}


