using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CC.Base.Market;
using CC.Base.Rest;
using log4net;

namespace CC.COB.Market
{
    internal partial class MarketProvider : IMarketProvider
    {
        private const string GetAllCurrenciesUrl = "/v1/market/currencies";
        private const string GetAllTradingPairsUrl = "/v1/market/trading_pairs";
        private const string GetOrderBookUrl = "/v1/market/orderbooks/{0}?limit=10";

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IWebClient _webClient;

        public MarketProvider(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            CurrenciesJson currenciesJson;
            try
            {
                currenciesJson = _webClient.GetObject<CurrenciesJson>(GetAllCurrenciesUrl);
                if (currenciesJson?.Currencies == null || !currenciesJson.Currencies.Any())
                    throw new ArgumentNullException($"Currencies Response is Empty!");
            }
            catch (Exception ex)
            {
                Log.Error("Unable to call GetAllCurrencies", ex);
                yield break;
            }

            var currencyJsons = currenciesJson.Currencies;
            foreach (var currencyJson in currencyJsons)
            {
                var minUnit = double.Parse(currencyJson.Min_Unit);
                yield return new Currency(currencyJson.Currency, currencyJson.Name, minUnit);
            }
        }

        public IEnumerable<TradingPair> GetAllTradingPairs()
        {
            TradingPairsJson tradingPairsJson;
            try
            {
                tradingPairsJson = _webClient.GetObject<TradingPairsJson>(GetAllTradingPairsUrl);
                if (tradingPairsJson?.Trading_Pairs == null || !tradingPairsJson.Trading_Pairs.Any())
                    throw new ArgumentNullException($"TradingPairs Response is Empty!");
            }
            catch (Exception ex)
            {
                Log.Error("Unable to call GetAllTradingPairs", ex);
                yield break;
            }

            foreach (var tradingPairJson in tradingPairsJson.Trading_Pairs)
            {
                var baseMinSize = double.Parse(tradingPairJson.Base_Min_Size);
                var baseMaxSize = double.Parse(tradingPairJson.Base_Max_Size);
                var quoteIncrement = double.Parse(tradingPairJson.Quote_Increment);
                yield return new TradingPair(
                    tradingPairJson.Id,
                    tradingPairJson.Base_Currency_Id,
                    tradingPairJson.Quote_Currency_Id,
                    baseMinSize,
                    baseMaxSize,
                    quoteIncrement
                );
            }
        }

        public OrderBook GetOrderBook(string tradingPairId)
        {
            OrderBookJson orderBookJson;
            try
            {
                orderBookJson = _webClient.GetObject<OrderBookJson>(string.Format(GetOrderBookUrl, tradingPairId));
                if (orderBookJson?.Orderbook?.Asks == null || orderBookJson?.Orderbook?.Bids == null)
                    throw new ArgumentNullException($"OrderBook Response is Empty!");
            }
            catch (Exception ex)
            {
                Log.Error($"Unable to call GetOrderBook({tradingPairId})", ex);
                return OrderBook.Empty;
            }

            var bids = orderBookJson.Orderbook.Bids.Select(GetOrderBookEntryFromJson);
            var asks = orderBookJson.Orderbook.Asks.Select(GetOrderBookEntryFromJson);

            return new OrderBook(asks, bids);
        }

        private static OrderBookEntry GetOrderBookEntryFromJson(OrderBookEntryJson obj)
        {
            if (obj?.Count != 3)
                throw new IndexOutOfRangeException("OrderBookEntry != 3 elements");

            var price = double.Parse(obj[0]);
            var count = double.Parse(obj[1]);
            var size = double.Parse(obj[2]);
            return new OrderBookEntry(
                price,
                size,
                count
            );
        }
    }
}