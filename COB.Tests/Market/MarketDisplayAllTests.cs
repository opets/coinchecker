using System;
using System.Linq;
using Autofac;
using CC.Base.Extensions;
using CC.Base.Market;
using CC.COB.Market;
using CC.COB.Tests.Common;
using NUnit.Framework;

namespace CC.COB.Tests.Market
{
    [TestFixture]
    internal sealed class MarketDisplayAllTests
    {
        private IMarketProvider _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = TestHelper.ServiceLocator.Resolve<IMarketProvider>();
        }

        [Test]
        public void GetAllCurrencies()
        {
            Currency[] currencies = _sut.GetAllCurrencies().ToArray();
            Console.WriteLine($"{string.Join(",",currencies.Select(c=>c.Id))}");
            currencies.Foreach(c => Console.WriteLine($"{c.Id.PadRight(7)}\t{c.Name.PadRight(30)}\t{c.MinUnit:F10}"));
        }

        [Test]
        public void GetAllCurrencies_ReturnObjInitializer()
        {
            Currency[] currencies = _sut.GetAllCurrencies().ToArray();
            currencies.Foreach(c => Console.WriteLine($"\tnew Currency(\"{c.Id}\", \"{c.Name}\", {c.MinUnit:F10}),"));
        }

        [Test]
        public void GetAllTradingPairs()
        {
            TradingPair[] tradingPairs = _sut.GetAllTradingPairs()
                .OrderBy(t => t.QuoteCurrencyId)
                .ThenBy(t => t.BaseCurrencyId)
                .ToArray();

            tradingPairs.Foreach(c => Console.WriteLine(
                $"{c.Id.PadRight(13)}\t{c.BaseCurrencyId.PadRight(7)}\t{c.QuoteCurrencyId.PadRight(7)}\t" +
                $"{c.BaseMaxSize:F10}\t{c.BaseMinSize:F10}\t{c.QuoteIncrement:F10}"
                ));
        }

        [Test]
        public void GetAllTradingPairs_ReturnObjInitializer()
        {
            TradingPair[] tradingPairs = _sut.GetAllTradingPairs()
                .OrderBy(t => t.QuoteCurrencyId)
                .ThenBy(t => t.BaseCurrencyId)
                .ToArray();

            tradingPairs
                .Where(tp => new[] { "COB-BTC", "COB-ETH", "ETH-BTC" }.Contains(tp.Id))
                .Foreach(c => Console.WriteLine(
                $"\tnew TradingPair(\"{c.Id}\",\"{c.BaseCurrencyId}\",\"{c.QuoteCurrencyId}\","+
                                  $"{c.BaseMinSize:F10}, {c.BaseMaxSize:F10}, {c.QuoteIncrement:F10}),"
            ));
        }

        [Test]
        [TestCase("IOST-BTC")]
        [TestCase("IOST-ETH")]
        [TestCase("ETH-BTC")]
        public void GetOrderBook(string tradingPairId)
        {
            var orderBook = _sut.GetOrderBook(tradingPairId);

            orderBook.Asks.OrderByDescending(i=>i.Price)
                .Foreach(c => Console.WriteLine(
                    $"{c.Price:F10}\t{c.Size:F10}\t{c.Count:F3}"
                ));

            Console.WriteLine("-------------------------------------");

            orderBook.Bids.Foreach(c => Console.WriteLine(
                $"{c.Price:F10}\t{c.Size:F10}\t{c.Count:F3}"
            ));
        }

        [Test]
        [TestCase("IOST-ETH,IOST-BTC,ETH-BTC")]
        public void GetOrderBook_ReturnObjInitializer(string tradingPairIds)
        {
            foreach (var tradingPairId in tradingPairIds.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries).Select(p=>p.Trim()))
            {
                var orderBook = _sut.GetOrderBook(tradingPairId);

                Console.WriteLine($"{{\"{tradingPairId}\", new OrderBook(\r\n new OrderBookEntry[]{{");

                orderBook.Asks.OrderByDescending(i => i.Price)
                    .Foreach(c => Console.WriteLine(
                        $"new OrderBookEntry({c.Price:F10},{c.Size:F10},{c.Count:F3}),"
                    ));

                Console.WriteLine("\t},\r\nnew OrderBookEntry[]{");

                orderBook.Bids.Foreach(c => Console.WriteLine(
                    $"new OrderBookEntry({c.Price:F10},{c.Size:F10},{c.Count:F3}),"
                ));

                Console.WriteLine("\t})},");

            }
        }

    }
}