using Autofac;

namespace CC.Base.Tests.Common
{
    internal static class TestHelper
    {
        internal static IContainer ServiceLocator = new BaseDependencyConfig().Build();
    }
}