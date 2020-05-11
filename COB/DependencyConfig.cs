using Autofac;
using CC.Base;
using CC.COB.Market;
using CC.COB.SystemInfo;
using CC.COB.Trading;
using CC.COB.Wallet;

namespace CC.COB
{
    public class DependencyConfig : BaseDependencyConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Base
            base.Load(builder);

            // System
            builder.RegisterType<SystemInfoProvider>().As<ISystemInfoProvider>().SingleInstance();
            builder.RegisterType<SystemInfoStore>().As<ISystemInfoStore>().SingleInstance();

            // Market
            builder.RegisterType<MarketProvider>().As<IMarketProvider>().SingleInstance();
            builder.RegisterType<MarketStore>().As<IMarketStore>().SingleInstance();

            // Trading
            builder.RegisterType<TradingProvider>().As<ITradingProvider>().SingleInstance();
            builder.RegisterType<TradingStore>().As<ITradingStore>().SingleInstance();

            // Wallet
            builder.RegisterType<WalletProvider>().As<IWalletProvider>().SingleInstance();
            builder.RegisterType<WalletStore>().As<IWalletStore>().SingleInstance();

            builder.RegisterType<Store>().As<Store>().SingleInstance();
        }
    }
}