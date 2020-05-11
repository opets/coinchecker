using System;
using System.Reflection;
using CC.Base.Common;
using CC.Base.Rest;
using CC.Base.Trading;
using log4net;

namespace CC.COB.Trading
{
    internal partial class TradingProvider : ITradingProvider
    {
        private const string GetOrderUrl = "/v1/trading/orders/{0}";
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IWebClient _webClient;

        public TradingProvider(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public Order GetOrder(string orderId)
        {
            try
            {
                var orderJson = _webClient.GetObject<OrderJson>(string.Format(GetOrderUrl, orderId));
                return GetOrderFromJson(orderJson);
            }
            catch (Exception ex)
            {
                Log.Error($"Unable to call GetOrder('{orderId}')", ex);
                return Order.Empty;
            }
        }

    }
}