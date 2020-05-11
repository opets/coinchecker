using Autofac;

namespace CC.COB.Tests.Common
{
    internal static class TestHelper
    {
        internal static IContainer ServiceLocator = new DependencyConfig().Build();
    }
}
