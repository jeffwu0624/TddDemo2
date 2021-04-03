using NUnit.Framework;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class BlackCatTests
    {
        [Test()]
        public void GetCompanyName_Test()
        {
            var blackCat = new BlackCat();

            var companyName = blackCat.GetCompanyName();

            Assert.That(companyName, Is.EqualTo("黑貓"));
        }

        [Test()]
        public void GetFeeTest()
        {
            Assert.Fail();
        }
    }
}