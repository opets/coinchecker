using System;
using Autofac;
using CC.Base.Configuration;
using CC.Base.Serialization;
using CC.Base.Tests.Common;
using NUnit.Framework;

namespace CC.Base.Tests.Serialization
{
    [TestFixture]
    public partial class JsonConverterTests
    {
        private IJsonConverter _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = TestHelper.ServiceLocator.Resolve<IJsonConverter>();
        }

        [Test]
        public void SuccessIntJson_ReturnValue()
        {
            int res = _sut.DeserializeObject<int>(Resources.SuccessIntExample);

            Assert.AreEqual(123, res);
        }

        //[Test]
        //public void UnsuccessfulJson_ThrowsException()
        //{
        //    var sut = TestHelper.ServiceLocator.Resolve<IConfigurationProvider>();

        //    try
        //    {
        //        _sut.DeserializeObject<int>(Resources.UnsuccessIntExample);
        //    }
        //    catch (UnsuccessfulResponseException ex)
        //    {
        //        Assert.AreEqual("qwe", ex.Message);
        //        return;
        //    }
        //    Assert.Fail("Exception expected");

        //}

        [Test]
        public void SuccessObjJson_ReturnValue()
        {
            TestSystemTime res = _sut.DeserializeObject<TestSystemTime>(Resources.GetSystemTimeJson);

            Assert.AreEqual(1505204498376L, res.Time);
        }

        private class TestSystemTime
        {
            public long Time;
        }

    }
}
