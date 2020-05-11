using System.Collections.Generic;
using CC.Base.Market;

namespace CC.COB.Market
{
    public interface IMarketProvider
    {
        IEnumerable<Currency> GetAllCurrencies();
        IEnumerable<TradingPair> GetAllTradingPairs();
        OrderBook GetOrderBook(string tradingPairId);
    }
}