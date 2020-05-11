using System;
using System.Linq;
using System.Reflection;
using Autofac;
using CC.Base;
using CC.Base.Market;
using CC.COB.Market;
using CC.COB.SystemInfo;
using CC.COB.Trading;
using CC.COB.Wallet;
using log4net;

namespace CC.COB
{
    public partial class Store
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IMarketStore MarketStore { get; }
        public ITradingStore TradingStore { get; }
        public ITradingProvider TradingProvider { get; }
        public IWalletStore WalletStore { get; }
        public IWalletProvider WalletProvider { get; }
        public ISystemInfoStore SystemInfo { get; }

        public Store(
            IMarketStore marketStore,
            ITradingStore tradingStore,
            ITradingProvider tradingProvider,
            IWalletStore walletStore,
            IWalletProvider walletProvider,
            ISystemInfoStore systemInfoStore
        )
        {
            MarketStore = marketStore;
            TradingStore = tradingStore;
            TradingProvider = tradingProvider;
            WalletStore = walletStore;
            WalletProvider = walletProvider;
            SystemInfo = systemInfoStore;
        }

        public void RefreshOrderBook(Action<string> callbackAction)
        {
            foreach (string currency in MarketStore.Currencies.Select(c=>c.Id))
            {
                MarketStore.RefreshOrderBook(
                    MarketStore.TradingPairs.Where(p => p.BaseCurrencyId == currency).Select(p => p.Id)
                );
                callbackAction(currency);
            }
        }

        public void RefreshWallet()
        {
            WalletStore.RefreshBalance(MarketStore.Currencies.Select(c => c.Id).ToArray());
        }

        public void RefreshBase()
        {
            //SystemInfo.Refresh();
            MarketStore.Refresh();
            TradingStore.Refresh();            
        }

        public static Store Create() => new DependencyConfig().Build().Resolve<Store>();

    }
}