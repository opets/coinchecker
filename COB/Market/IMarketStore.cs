using System;
using System.Collections.Generic;
using CC.Base;
using CC.Base.Market;

namespace CC.COB.Market
{
    public interface IMarketStore
    {
        Currency[] Currencies { get; }
        TradingPair[] TradingPairs { get; }
        IDictionary<string, OrderBook> OrderBooks { get; }

        void RefreshOrderBookAsync(IEnumerable<string> tradingPairsIds);

        void RefreshOrderBook(IEnumerable<string> tradingPairsIds);

        void Refresh();
    }
}