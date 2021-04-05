using NUnit.Framework;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class PostOfficeTests
    {
        private PostOffice _postOffice;

        [SetUp]
        public void Init()
        {
            _postOffice = new PostOffice();
        }

        [Test()]
        public void GetCompanyName_Test()
        {
            var companyName = _postOffice.GetCompanyName();

            Assert.That(companyName, Is.EqualTo("郵局"));
        }

        [Test()]
        public void GetFee_ShouldBeZero_WhenInit()
        {
            var fee = _postOffice.GetFee();

            Assert.That(fee, Is.EqualTo(0));
        }

        [Test]
        public void GetFee_ShouldBe180()
        {
            _postOffice.ShipProduct = new Product()
            {
                Weight = 10,
                Length = 30,
                Width = 20,
                Height = 10
            };

            _postOffice.Calculated();

            var fee = _postOffice.GetFee();

            Assert.That(fee, Is.EqualTo(180));
        }
    }
}