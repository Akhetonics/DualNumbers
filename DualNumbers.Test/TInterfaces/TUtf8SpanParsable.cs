using NUnit.Framework.Legacy;
using System.Globalization;

namespace DualNumbers.Test
{

    public class DualUtf8SpanParsableTests
    {



        [Test]
        public void TryParse_WithInvalidInput_ReturnsFalseAndDefaultDual()
        {
            ReadOnlySpan<byte> utf8Text = new byte[] { 105, 110, 118, 97, 108, 105, 100, 95, 105, 110, 112, 117, 116 };
            var provider = CultureInfo.InvariantCulture;

            bool success = Dual.TryParse(utf8Text, provider, out Dual result);

            ClassicAssert.IsFalse(success);
            ClassicAssert.AreEqual(default(Dual), result);
        }
    }
}


