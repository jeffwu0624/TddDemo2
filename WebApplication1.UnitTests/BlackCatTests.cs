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
        public void GetFeeTest()
        {
            Assert.Fail();
        }
    }
}