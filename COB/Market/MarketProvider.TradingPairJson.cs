namespace CC.COB.Market
{
    internal partial class MarketProvider
    {
        private class TradingPairsJson
        {
            public TradingPairJson[] Trading_Pairs { get; set; }

            public class TradingPairJson
            {
                public string Id { get; set; }
                public string Base_Currency_Id { get; set; }
                public string Quote_Currency_Id { get; set; }
                public string Base_Min_Size { get; set; }
                public string Base_Max_Size { get; set; }
                public string Quote_Increment { get; set; }

            }
        }

    }
}