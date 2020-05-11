using System.Linq;
using Autofac;
using CC.Base.Market;
using CC.COB.Market;
using CC.COB.Tests.Common;
using NUnit.Framework;

namespace CC.COB.Tests.Market
{
    [TestFixture]
    internal sealed class MarketProviderTests
    {
        private IMarketProvider _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = TestHelper.ServiceLocator.Resolve<IMarketProvider>();
        }

        [Test]
        public void GetAllCurrencies_Test()
        {
            Currency[] currencies = _sut.GetAllCurrencies().ToArray();
            Assert.IsNotNull(currencies);
            Assert.IsTrue(currencies.All(c=>c.MinUnit> 0.0000000001), "Exists currency with MinUnit = 0");

            Currency btc = currencies.Single(c => c.Id == "BTC");
            Assert.AreEqual("BTC", btc.Id);
            Assert.AreEqual("Bitcoin", btc.Name);
            Assert.AreEqual(0.00000001, btc.MinUnit);

            Currency eth = currencies.Single(c => c.Id == "ETH");
            Assert.AreEqual("ETH", eth.Id);
            Assert.AreEqual("Ethereum", eth.Name);
            Assert.AreEqual(0.00000001, eth.MinUnit);
        }

        [Test]
        public void GetAllTradingPairs_Test()
        {
            TradingPair[] tradingPairs = _sut.GetAllTradingPairs().ToArray();
            Assert.IsNotNull(tradingPairs);

            var eth = tradingPairs.Single(c => c.Id == "ETH-BTC");
            Assert.AreEqual("ETH", eth.BaseCurrencyId);
            Assert.AreEqual("BTC", eth.QuoteCurrencyId);
            Assert.Less(1, eth.BaseMaxSize);
            Assert.Less(0.0001, eth.BaseMinSize);
            Assert.Less(0.00000001, eth.QuoteIncrement);
        }

        [Test]
        public void GetOrderBook_Test()
        {
            var orderBook = _sut.GetOrderBook("ETH-BTC");
            Assert.IsNotNull(orderBook);

            Assert.Less(5, orderBook.Bids.Length);
            Assert.Less(5, orderBook.Asks.Length);
            Assert.IsTrue(orderBook.Bids.All(c => c.Count >= 1), "OrderBook Bids: Count should be >= 1");
            Assert.IsTrue(orderBook.Bids.All(c => c.Price > 0.000001), "OrderBook Bids: Price should be > 0");
            Assert.IsTrue(orderBook.Bids.All(c => c.Size > 0.000001), "OrderBook Bids: Size should be > 0");
            Assert.IsTrue(orderBook.Asks.All(c => c.Count >= 1), "OrderBook Asks: Count should be >= 1");
            Assert.IsTrue(orderBook.Asks.All(c => c.Price > 0.000001), "OrderBook Asks: Price should be > 0");
            Assert.IsTrue(orderBook.Asks.All(c => c.Size > 0.00000001), "OrderBook Asks: Size should be > 0");

        }
    }
}