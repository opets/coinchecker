using System;
using Autofac;
using CC.COB.SystemInfo;
using CC.COB.Tests.Common;
using NUnit.Framework;

namespace CC.COB.Tests.System
{
    [TestFixture]
    internal sealed class SystemTests
    {
        private ISystemInfoProvider _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = TestHelper.ServiceLocator.Resolve<ISystemInfoProvider>();
        }

        [Test]
        public void GetSystemInformation_Test()
        {
            var res = _sut.GetSystemInformation();

            Assert.IsTrue(res.StartsWith("production"), $"expected: 'production:...' but was: {res}");
        }

        [Test]
        public void GetSystemTime_Test()
        {
            var systemTime = _sut.GetSystemTime();

            Assert.Less(DateTime.UtcNow.AddMinutes(-5), systemTime);
        }
    }
}