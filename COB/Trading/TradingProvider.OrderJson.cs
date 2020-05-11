using CC.Base.Trading;

namespace CC.COB.Trading
{
    internal partial class TradingProvider
    {
        private class OrderContainerJson
        {
            public OrderJson Order { get; set; }
        }

        private class OrderJson
        {
            public string Id { get; set; }
            public string TradingPair { get; set; }
            public string OrderState { get; set; }
            public string OrderSide { get; set; }
            public string OrderType { get; set; }
            public double Price { get; set; }
            public double Size { get; set; }
            public double Filled { get; set; }
        }

        private static Order GetOrderFromJson(OrderJson json)
        {
            return new Order()
            {
                OrderId = json.Id,
                TradingPairId = json.TradingPair,



            };
        }


    }
}