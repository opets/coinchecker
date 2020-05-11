using Autofac;
using CC.Base.Rest;
using NUnit.Framework;

namespace CC.COB.Tests.Common
{
    [TestFixture]
    public class WebClientTests
    {
        private IWebClient _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = TestHelper.ServiceLocator.Resolve<IWebClient>();
        }

        [Test]
        public void UnsuccessfulJson_ThrowsException()
        {
            //    try
            //    {
            //int res = _sut.GetObject<int>("/v1/system/qwe");
            //    }
            //    catch (UnsuccessfulResponseException ex)
            //    {
            //        Assert.AreEqual("qwe", ex.Message);
            //        return;
            //    }
            //    Assert.Fail("Exception expected");
        }
    }
}
