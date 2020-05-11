namespace CC.Base.Market
{
    public class TradingPair
    {
        public string Id { get; }
        public string BaseCurrencyId { get; }
        public string QuoteCurrencyId { get; }
        public double BaseMinSize { get; }
        public double BaseMaxSize { get; }
        public double QuoteIncrement { get; }

        public TradingPair(string id, string baseCurrencyId, string quoteCurrencyId, double baseMinSize, double baseMaxSize, double quoteIncrement)
        {
            Id = id;
            BaseCurrencyId = baseCurrencyId;
            QuoteCurrencyId = quoteCurrencyId;
            BaseMinSize = baseMinSize;
            BaseMaxSize = baseMaxSize;
            QuoteIncrement = quoteIncrement;
        }
    }
}