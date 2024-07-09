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


    }
}


