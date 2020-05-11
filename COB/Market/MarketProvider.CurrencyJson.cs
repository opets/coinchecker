namespace CC.COB.Market
{
    internal partial class MarketProvider
    {
        private class CurrenciesJson
        {
            public CurrencyJson[] Currencies { get; set; }

            public class CurrencyJson
            {
                public string Currency { get; set; }
                public string Name { get; set; }
                public string Min_Unit { get; set; }

            }
        }

    }
}