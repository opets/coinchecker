using Autofac;
using CC.Base.Configuration;
using NUnit.Framework;

namespace CC.COB.Tests.Common
{
    [TestFixture]
    internal sealed class ConfigurationTests
    {
        [Test]
        public void ConfigurationTest()
        {
            var sut = TestHelper.ServiceLocator.Resolve<IConfigurationProvider>();

            Assert.AreEqual(@"https://api.cobinhood.com", sut.BaseUrl);
        }
    }
}