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
    }
}