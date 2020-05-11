using System;

namespace CC.COB.Trading
{
    internal sealed class TradingStore : ITradingStore
    {
        private readonly ITradingProvider _tradingProvider;
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TradingStore(ITradingProvider tradingProvider)
        {
            _tradingProvider = tradingProvider;
        }

        public void Refresh()
        {
        }
    }
}