using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CC.Base.Configuration;
using CC.Base.Extensions;
using CC.Base.Market;
using log4net;

namespace CC.COB.Market
{
    internal sealed class MarketStore : IMarketStore
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMarketProvider _marketProvider;
        private readonly IConfigurationProvider _configurationProvider;

        public Currency[] Currencies { get; private set; }
        public TradingPair[] TradingPairs { get; private set; }
        public IDictionary<string, OrderBook> OrderBooks { get; }

        public MarketStore(IMarketProvider marketProvider, IConfigurationProvider configurationProvider)
        {
            _marketProvider = marketProvider;
            _configurationProvider = configurationProvider;
            OrderBooks = new Dictionary<string, OrderBook>();
        }

        public void Refresh()
        {
            var sw = Stopwatch.StartNew();
            var filteredTradingPairJsons = _marketProvider.GetAllTradingPairs()
                .Where(tp => !_configurationProvider.ExcludeCurrencies.Contains(tp.BaseCurrencyId)
                            && !_configurationProvider.ExcludeCurrencies.Contains(tp.QuoteCurrencyId));

            TradingPairs = filteredTradingPairJsons.ToArray();
            Log.Debug($"Load TradingPairs: {TradingPairs.Count(p => p.QuoteCurrencyId == "ETH")}*ETH, " +
                      $"{TradingPairs.Count(p => p.QuoteCurrencyId == "BTC")}*BTC, {TradingPairs.Count(p => p.QuoteCurrencyId == "USD")}*USD, " +
                      $"{TradingPairs.Count(p => p.QuoteCurrencyId != "USD" && p.QuoteCurrencyId != "BTC" && p.QuoteCurrencyId != "ETH")}*Other ({sw.Elapsed.Seconds}s.)");

            sw = Stopwatch.StartNew();
            Currencies = _marketProvider.GetAllCurrencies()
                .Where(c => !_configurationProvider.ExcludeCurrencies.Contains(c.Id))
                .Where(c => !_configurationProvider.ExcludeCurrencies.Contains(c.Id))
                .ToArray();
            Log.Debug($@"Load Currencies: {Currencies.Length} items ({sw.Elapsed.Seconds}s.)");

        }

        public void RefreshOrderBookAsync(IEnumerable<string> tradingPairsIds)
        {
            var sw = Stopwatch.StartNew();
            Parallel.Invoke(
                tradingPairsIds.Select(
                    pairId => new Action(() =>
                    {
                        var orderBook = _marketProvider.GetOrderBook(pairId);
                        OrderBooks.InsertOrUpdate(pairId, orderBook);
                    })
                ).ToArray());
            sw.Stop();
            Log.Debug($"OrderBook Load(Async): {sw.Elapsed.Seconds}s.");
        }

        public void RefreshOrderBook(IEnumerable<string> tradingPairsIds)
        {
            var sw = Stopwatch.StartNew();
            tradingPairsIds.Foreach(pairId =>
            {
                var orderBook = _marketProvider.GetOrderBook(pairId);
                OrderBooks.InsertOrUpdate(pairId, orderBook);
            });
            sw.Stop();
            Log.Debug($"OrderBook Load(Sync): {sw.Elapsed.Seconds}s.");
        }
    }
}