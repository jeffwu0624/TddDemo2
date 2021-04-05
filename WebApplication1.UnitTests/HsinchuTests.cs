using NUnit.Framework;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class HsinchuTests
    {
        private Hsinchu _hsinchu;

        [SetUp]
        public void Init()
        {
            _hsinchu = new Hsinchu();
        }

        [Test()]
        public void GetCompanyName_Test()
        {
            var companyName = _hsinchu.GetCompanyName();

            Assert.That(companyName, Is.EqualTo("新竹貨運"));
        }

        [Test()]
        public void GetFee_ShouldBeZero_WhenInit()
        {
            var fee = _hsinchu.GetFee();

            Assert.That(fee, Is.EqualTo(0));
        }

        [Test]
        public void GetFee_ShouldBe1830_WhenLengthMoreThen100()
        {
            _hsinchu.ShipProduct = new Product()
            {
                Length = 30,
                Width = 20,
                Height = 10,
                Weight = 10
            };

            _hsinchu.Calculated();

            var fee = _hsinchu.GetFee();

            Assert.That(fee, Is.EqualTo(254).Within(0.9));
        }
    }
}