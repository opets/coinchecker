using System.Linq;
using CC.Base.Market;

namespace CC.COB
{
    public partial class Store
    {
        public double PredictBuy(string tradingPair, double bitcoinSum)
        {
            var orderBook = GetOrderBook(tradingPair);
            if (orderBook == null)
                return 0;

            double cobsSum = 0;
            var sum = bitcoinSum;
            foreach (var ask in orderBook.Asks.OrderBy(a => a.Price))
            {
                var cobs = sum / ask.Price;
                if (cobs <= ask.Size)
                {
                    cobsSum += cobs;
                    break;
                }

                sum -= ask.Size * ask.Price;
                cobsSum += ask.Size;
            }

            return cobsSum;
        }

        public double PredictSell(string tradingPair, double cobsSum)
        {
            var orderBook = GetOrderBook(tradingPair);
            if (orderBook == null)
                return 0;

            double bitcoinSum = 0;
            var sum = cobsSum;
            foreach (var bid in orderBook.Bids.OrderByDescending(a => a.Price))
            {
                if (sum <= bid.Size)
                {
                    bitcoinSum += sum * bid.Price;
                    break;
                }

                sum -= bid.Size;
                bitcoinSum += bid.Size * bid.Price;
            }

            return bitcoinSum;
        }

        public double PredictCircle(string currency, double bitcoins)
        {
            var cobs = PredictBuy($"{currency}-BTC", bitcoins);
            var eths = PredictSell($"{currency}-ETH", cobs);
            var bitcoinsOut = PredictSell($"ETH-BTC", eths);
            return bitcoinsOut;
        }

        public double PredictBackCircle(string currency, double bitcoins)
        {
            var eths = PredictBuy($"ETH-BTC", bitcoins);
            var cobs = PredictBuy($"{currency}-ETH", eths);
            var bitcoinsOut = PredictSell($"{currency}-BTC", cobs);
            return bitcoinsOut;
        }

        public double PredictSell70(string tradingPair, double cobsSum, double pers)
        {
            var orderBook = GetOrderBook(tradingPair);
            if (orderBook == null)
                return 0;

            var firstBid = orderBook.Bids.OrderByDescending(a => a.Price).FirstOrDefault();
            var firstAsk = orderBook.Asks.OrderBy(a => a.Price).FirstOrDefault();

            if (firstAsk == null || firstBid == null)
                return 0;

            return cobsSum * (firstAsk.Price - pers * (firstAsk.Price - firstBid.Price));
        }

        public double PredictBuy70(string tradingPair, double bitcoinSum, double pers)
        {
            var orderBook = GetOrderBook(tradingPair);
            if (orderBook == null)
                return 0;

            var firstBid = orderBook.Bids.OrderByDescending(a => a.Price).FirstOrDefault();
            var firstAsk = orderBook.Asks.OrderBy(a => a.Price).FirstOrDefault();

            if (firstAsk == null || firstBid == null)
                return 0;

            return bitcoinSum / (firstBid.Price - pers * (firstBid.Price - firstAsk.Price));
        }

        public double PredictCircle70(string currency, double bitcoins, double pers)
        {
            var cobs = PredictBuy70($"{currency}-BTC", bitcoins, pers);
            var eths = PredictSell70($"{currency}-ETH", cobs, pers);
            var bitcoinsOut = PredictSell70($"ETH-BTC", eths, pers);
            return bitcoinsOut;
        }

        public double PredictBackCircle70(string currency, double bitcoins, double pers)
        {
            var eths = PredictBuy70($"ETH-BTC", bitcoins, pers);
            var cobs = PredictBuy70($"{currency}-ETH", eths, pers);
            var bitcoinsOut = PredictSell70($"{currency}-BTC", cobs, pers);
            return bitcoinsOut;
        }

        private OrderBook GetOrderBook(string tradingPair)
        {
            if (!MarketStore.OrderBooks.ContainsKey(tradingPair))
            {
                Log.Debug($"Unable load OrderBook for {tradingPair}");
                return OrderBook.Empty;
            }

            var orderBook = MarketStore.OrderBooks[tradingPair];
            return orderBook;
        }

    }
}