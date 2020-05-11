using System.Collections.Generic;
using CC.Base.Market;

namespace CC.COB.Tests.Analitics
{
    internal sealed partial class AnaliticsTests
    {
        private static class DataSample1
        {
            public static readonly Currency[] Currencies =
            {
                new Currency("ETH", "Ethereum", 0.0000000100),
                new Currency("BTC", "Bitcoin", 0.0000000100),
                new Currency("COB", "Cobinhood Token", 0.0000000100)
            };

            public static readonly TradingPair[] TradingPairs =
            {
                new TradingPair("COB-BTC", "COB", "BTC", 132.3720000000, 4412400.6100000000, 0.0000000100),
                new TradingPair("ETH-BTC", "ETH", "BTC", 0.0370000000, 1244.2600000000, 0.0000001000),
                new TradingPair("COB-ETH", "COB", "ETH", 132.3720000000, 4412400.6100000000, 0.0000001000)
            };

            public static readonly Dictionary<string, OrderBook> OrderBook = new Dictionary<string, OrderBook>
            {
                {
                    "COB-ETH", new OrderBook(
                        new[]
                        {
                            new OrderBookEntry(0.0002641000, 300.0000000000, 1.000),
                            new OrderBookEntry(0.0002640000, 300.0000000000, 1.000),
                            new OrderBookEntry(0.0002639000, 323.9724239000, 1.000),
                            new OrderBookEntry(0.0002638000, 204.3903670400, 1.000),
                            new OrderBookEntry(0.0002632000, 549.0000000000, 1.000),
                            new OrderBookEntry(0.0002625000, 500.0000000000, 1.000),
                            new OrderBookEntry(0.0002608000, 500.0000000000, 1.000),
                            new OrderBookEntry(0.0002604000, 570.1282869000, 1.000),
                            new OrderBookEntry(0.0002603000, 1200.0000000000, 1.000),
                            new OrderBookEntry(0.0002600000, 862.3499071800, 1.000)
                        },
                        new[]
                        {
                            new OrderBookEntry(0.0002577000, 3295.6229994000, 3.000),
                            new OrderBookEntry(0.0002576000, 170.0000000000, 1.000),
                            new OrderBookEntry(0.0002551000, 300.0000000000, 1.000),
                            new OrderBookEntry(0.0002545000, 500.0000000000, 1.000),
                            new OrderBookEntry(0.0002543000, 1636.0000000000, 2.000),
                            new OrderBookEntry(0.0002541000, 2527.1739473000, 1.000),
                            new OrderBookEntry(0.0002539000, 3000.0000000000, 1.000),
                            new OrderBookEntry(0.0002538000, 677.2944969600, 1.000),
                            new OrderBookEntry(0.0002537000, 14144.5712223200, 1.000),
                            new OrderBookEntry(0.0002533000, 6700.0000000000, 1.000)
                        })
                },
                {
                    "COB-BTC", new OrderBook(
                        new[]
                        {
                            new OrderBookEntry(0.0000274700, 530.7121401500, 2.000),
                            new OrderBookEntry(0.0000270000, 11000.0000000000, 2.000),
                            new OrderBookEntry(0.0000267000, 4796.0831460700, 1.000),
                            new OrderBookEntry(0.0000266800, 2913.3250612100, 1.000),
                            new OrderBookEntry(0.0000266700, 366.1004558700, 1.000),
                            new OrderBookEntry(0.0000264100, 1200.0000000000, 1.000),
                            new OrderBookEntry(0.0000262800, 1341.5917242300, 1.000),
                            new OrderBookEntry(0.0000262700, 394.6366360800, 1.000),
                            new OrderBookEntry(0.0000257500, 342.8832135800, 2.000),
                            new OrderBookEntry(0.0000255000, 6155.1489063600, 2.000)
                        },
                        new[]
                        {
                            new OrderBookEntry(0.0000252100, 416.6679888900, 1.000),
                            new OrderBookEntry(0.0000252000, 249.2805111700, 1.000),
                            new OrderBookEntry(0.0000251000, 594.0000000000, 1.000),
                            new OrderBookEntry(0.0000250100, 757.7908836400, 2.000),
                            new OrderBookEntry(0.0000250000, 4000.0000000000, 1.000),
                            new OrderBookEntry(0.0000249900, 2984.2474641000, 1.000),
                            new OrderBookEntry(0.0000247100, 306.9795171500, 1.000),
                            new OrderBookEntry(0.0000246300, 1474.2850000000, 2.000),
                            new OrderBookEntry(0.0000246100, 8712.3206938100, 3.000),
                            new OrderBookEntry(0.0000245000, 34996.0000000000, 2.000)
                        })
                },
                {
                    "ETH-BTC", new OrderBook(
                        new[]
                        {
                            new OrderBookEntry(0.0997998000, 0.1688398800, 1.000),
                            new OrderBookEntry(0.0997979000, 0.5000000000, 1.000),
                            new OrderBookEntry(0.0997000000, 0.0580000000, 1.000),
                            new OrderBookEntry(0.0995000000, 1.9865860800, 2.000),
                            new OrderBookEntry(0.0992499000, 0.7877247200, 1.000),
                            new OrderBookEntry(0.0992000000, 0.2000000000, 1.000),
                            new OrderBookEntry(0.0991000000, 4.1994448100, 2.000),
                            new OrderBookEntry(0.0989999000, 2.0000000000, 1.000),
                            new OrderBookEntry(0.0989990000, 0.7576788500, 1.000),
                            new OrderBookEntry(0.0989700000, 0.1600000000, 1.000)
                        },
                        new[]
                        {
                            new OrderBookEntry(0.0982500000, 0.1144566700, 1.000),
                            new OrderBookEntry(0.0982204000, 0.1490000000, 1.000),
                            new OrderBookEntry(0.0982203000, 0.9654349700, 1.000),
                            new OrderBookEntry(0.0980250000, 0.8654612900, 1.000),
                            new OrderBookEntry(0.0980102000, 0.3709802400, 1.000),
                            new OrderBookEntry(0.0980101000, 1.0000000000, 1.000),
                            new OrderBookEntry(0.0980085000, 0.1174221300, 1.000),
                            new OrderBookEntry(0.0980076000, 0.9062000000, 1.000),
                            new OrderBookEntry(0.0980050000, 0.0459924900, 1.000),
                            new OrderBookEntry(0.0980022000, 2.0000000000, 1.000)
                        })
                }
            };
        }

        private static class DataSample2
        {
            public static readonly Currency[] Currencies =
            {
                new Currency("USD", "Dollar", 0.0000000100),
                new Currency("EUR", "EUR", 0.0000000100),
                new Currency("COB", "Cobinhood Token", 0.0000000100)
            };

            public static readonly TradingPair[] TradingPairs =
            {
                new TradingPair("USD-UAH", "COB", "USD", 132.3720000000, 4412400.6100000000, 0.0000000100),
                new TradingPair("EUR-UAH", "EUR", "USD", 0.0370000000, 1244.2600000000, 0.0000001000)
            };

            public static readonly Dictionary<string, OrderBook> OrderBook = new Dictionary<string, OrderBook>
            {
                {
                    "USD-UAH", new OrderBook(
                        new[]
                        {
                            new OrderBookEntry(28, 1000, 1.000),
                            new OrderBookEntry(27, 100, 1.000)
                        },
                        new[]
                        {
                            new OrderBookEntry(26, 100, 1.000),
                            new OrderBookEntry(25, 1000, 1.000)
                        })
                }
            };
        }

        private static class DataSample3
        {
            public static readonly Currency[] Currencies =
            {
                new Currency("ETH", "Ethereum", 0.0000000100),
                new Currency("BTC", "Bitcoin", 0.0000000100),
                new Currency("IOST", "IOST", 0.0000000100)
            };

            public static readonly TradingPair[] TradingPairs =
            {
                new TradingPair("IOST-BTC", "IOST", "BTC", 100, 100000, 0.0000000100),
                new TradingPair("ETH-BTC", "ETH", "BTC", 1, 1000, 0.0000001000),
                new TradingPair("IOST-ETH", "IOST", "ETH", 100, 10000, 0.0000001000)
            };

            public static readonly Dictionary<string, OrderBook> OrderBook = new Dictionary<string, OrderBook>
            {
                {
                    "IOST-ETH", new OrderBook(
                        new OrderBookEntry[]
                        {
                            new OrderBookEntry(0.0001200000, 807.0000000000, 1.000),
                            new OrderBookEntry(0.0001099000, 1000.0000000000, 1.000),
                            new OrderBookEntry(0.0000538000, 1300.0000000000, 1.000),
                            new OrderBookEntry(0.0000500000, 1000.0000000000, 1.000),
                            new OrderBookEntry(0.0000499000, 23.3041002100, 1.000),
                            new OrderBookEntry(0.0000496000, 5947.2524258400, 1.000),
                            new OrderBookEntry(0.0000490000, 10008.0940000000, 1.000),
                            new OrderBookEntry(0.0000488000, 10000.0000000000, 1.000),
                            new OrderBookEntry(0.0000487000, 5000.0000000000, 1.000),
                            new OrderBookEntry(0.0000480000, 6771.5009000000, 1.000),
                        },
                        new OrderBookEntry[]
                        {
                            new OrderBookEntry(0.0000429000, 401.5090002100, 1.000),
                            new OrderBookEntry(0.0000422000, 5000.0000000000, 1.000),
                            new OrderBookEntry(0.0000400000, 4900.0000000000, 1.000),
                            new OrderBookEntry(0.0000385000, 1890.9090910000, 1.000),
                            new OrderBookEntry(0.0000384000, 3954.9696585200, 1.000),
                            new OrderBookEntry(0.0000374000, 1000.0000000000, 1.000),
                            new OrderBookEntry(0.0000304000, 8000.0000000000, 1.000),
                            new OrderBookEntry(0.0000290000, 4000.0000000000, 1.000),
                            new OrderBookEntry(0.0000230000, 807.0000000000, 1.000),
                            new OrderBookEntry(0.0000157000, 2000.0000000000, 1.000),
                        })
                },
                {
                    "IOST-BTC", new OrderBook(
                        new OrderBookEntry[]
                        {
                            new OrderBookEntry(1.0000000000, 820.0000000000, 1.000),
                            new OrderBookEntry(0.0000052300, 1331.0999999900, 1.000),
                            new OrderBookEntry(0.0000048100, 4086.9530629100, 1.000),
                            new OrderBookEntry(0.0000047900, 3800.9894656800, 2.000),
                            new OrderBookEntry(0.0000047500, 14622.1349949800, 2.000),
                        },
                        new OrderBookEntry[]
                        {
                            new OrderBookEntry(0.0000039600, 175.0000000000, 1.000),
                            new OrderBookEntry(0.0000039000, 1164.2128212600, 1.000),
                            new OrderBookEntry(0.0000038500, 1000.0000000000, 1.000),
                            new OrderBookEntry(0.0000033200, 1000.0000000000, 1.000),
                            new OrderBookEntry(0.0000013100, 3320.6106871000, 1.000),
                            new OrderBookEntry(0.0000012900, 15000.0000000000, 1.000),
                            new OrderBookEntry(0.0000011000, 1000.0000000000, 1.000),
                            new OrderBookEntry(0.0000000100, 250000.0000000000, 1.000),
                        })
                },
                {
                    "ETH-BTC", new OrderBook(
                        new OrderBookEntry[]
                        {
                            new OrderBookEntry(0.0978000000, 0.4000000000, 1.000),
                            new OrderBookEntry(0.0977000000, 1.4600000000, 1.000),
                            new OrderBookEntry(0.0976998000, 0.9096160000, 1.000),
                            new OrderBookEntry(0.0968824000, 0.6642520700, 1.000),
                            new OrderBookEntry(0.0968795000, 0.4882880400, 1.000),
                            new OrderBookEntry(0.0968790000, 2.8000000000, 1.000),
                            new OrderBookEntry(0.0968789000, 2.8000000000, 1.000),
                            new OrderBookEntry(0.0959998000, 2.9743319200, 1.000),
                            new OrderBookEntry(0.0952000000, 6.7725567000, 1.000),
                            new OrderBookEntry(0.0951999000, 0.2000000000, 1.000),
                        },
                        new OrderBookEntry[]
                        {
                            new OrderBookEntry(0.0950804000, 0.4616000000, 1.000),
                            new OrderBookEntry(0.0949999000, 0.0377655600, 1.000),
                            new OrderBookEntry(0.0945001000, 0.1000000000, 1.000),
                            new OrderBookEntry(0.0940000000, 0.2000000000, 1.000),
                            new OrderBookEntry(0.0930100000, 0.0500000000, 1.000),
                            new OrderBookEntry(0.0921104000, 0.6400000000, 1.000),
                            new OrderBookEntry(0.0921103000, 0.5300000000, 1.000),
                            new OrderBookEntry(0.0921100000, 0.2000000000, 1.000),
                            new OrderBookEntry(0.0921002000, 0.0888860000, 1.000),
                            new OrderBookEntry(0.0921001000, 3.5492846100, 1.000),
                        })
                },
            };
        }

    }
}