using CC.COB.Market;
using CC.COB.SystemInfo;
using CC.COB.Trading;
using CC.COB.Wallet;
using Moq;
using NUnit.Framework;

namespace CC.COB.Tests.Analitics
{
    [TestFixture]
    internal sealed partial class AnaliticsTests
    {
        private Store _sut;
        private Mock<IMarketStore> _marketStoreMock;
        private Mock<ITradingStore> _tradingStoreMock;
        private Mock<ITradingProvider> _tradingProviderMock;
        private Mock<IWalletProvider> _walletProviderMock;
        private Mock<IWalletStore> _walletStoreMock;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _marketStoreMock = new Mock<IMarketStore>();
            _tradingProviderMock = new Mock<ITradingProvider>();
            _tradingStoreMock = new Mock<ITradingStore>();
            _walletProviderMock = new Mock<IWalletProvider>();
            _walletStoreMock = new Mock<IWalletStore>();

            _sut = new Store(
                _marketStoreMock.Object,
                _tradingStoreMock.Object,
                _tradingProviderMock.Object,
                _walletStoreMock.Object,
                _walletProviderMock.Object,
                new Mock<ISystemInfoStore>().Object
            );
        }

        [Test]
        public void PredictBuy_Test()
        {
            _marketStoreMock.SetupGet(x => x.Currencies).Returns(DataSample1.Currencies);
            _marketStoreMock.SetupGet(x => x.TradingPairs).Returns(DataSample1.TradingPairs);
            _marketStoreMock.SetupGet(x => x.OrderBooks).Returns(DataSample1.OrderBook);

            var cobs = _sut.PredictBuy("COB-BTC", 0.01);
            Assert.AreEqual(392.15686274509807d, cobs);

            cobs = _sut.PredictBuy("COB-BTC", 0.2);
            Assert.AreEqual(7800.1023826681512d, cobs);
        }

        [Test]
        public void PredictBuy_Test2()
        {
            _marketStoreMock.SetupGet(x => x.Currencies).Returns(DataSample2.Currencies);
            _marketStoreMock.SetupGet(x => x.TradingPairs).Returns(DataSample2.TradingPairs);
            _marketStoreMock.SetupGet(x => x.OrderBooks).Returns(DataSample2.OrderBook);

            var usd = _sut.PredictBuy("USD-UAH", 2700);
            Assert.AreEqual(100, usd);

            usd = _sut.PredictBuy("USD-UAH", 27 * 100 + 28 * 500);
            Assert.AreEqual(600, usd);
        }

        [Test]
        public void PredictSell_Test2()
        {
            _marketStoreMock.SetupGet(x => x.Currencies).Returns(DataSample2.Currencies);
            _marketStoreMock.SetupGet(x => x.TradingPairs).Returns(DataSample2.TradingPairs);
            _marketStoreMock.SetupGet(x => x.OrderBooks).Returns(DataSample2.OrderBook);

            var uah = _sut.PredictSell("USD-UAH", 100);
            Assert.AreEqual(2600, uah);

            uah = _sut.PredictSell("USD-UAH", 600);
            Assert.AreEqual(100 * 26 + 500 * 25, uah);
        }

        [Test]
        public void PredictCircle_Test()
        {
            _marketStoreMock.SetupGet(x => x.Currencies).Returns(DataSample3.Currencies);
            _marketStoreMock.SetupGet(x => x.TradingPairs).Returns(DataSample3.TradingPairs);
            _marketStoreMock.SetupGet(x => x.OrderBooks).Returns(DataSample3.OrderBook);

            var qwe = _sut.PredictSell("IOST-BTC", 2106);
            var btc = _sut.PredictSell("IOST-BTC",_sut.PredictBuy("IOST-BTC", 0.01));

            Assert.AreEqual(100 * 26 + 500 * 25, btc);
        }

    }
}