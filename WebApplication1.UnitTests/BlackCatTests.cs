using NUnit.Framework;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class BlackCatTests
    {
        private readonly BlackCat _blackCat = new BlackCat();

        [Test()]
        public void GetCompanyName_Test()
        {
            var companyName = _blackCat.GetCompanyName();

            Assert.That(companyName, Is.EqualTo("黑貓"));
        }

        [Test()]
        public void GetFee_ShouldBeZero_WhenInit()
        {
            var fee = _blackCat.GetFee();

            Assert.That(0, Is.EqualTo(0));
        }

        [Test]
        public void GetFee_ShouldBe500_WhenWeightMoreThen20()
        {
            _blackCat.ShipProduct = new Product()
            {
                Weight = 21
            };

            FeeShouldBe(500d);
        }

        [Test]
        public void GetFee_ShouldBe300_WhenWeightEqual20()
        {
            _blackCat.ShipProduct = new Product()
            {
                Weight = 20
            };

            FeeShouldBe(300d);
        }

        private void FeeShouldBe(double expected)
        {
            _blackCat.Calculated();

            var fee = _blackCat.GetFee();

            Assert.That(fee, Is.EqualTo(expected));
        }
    }
}