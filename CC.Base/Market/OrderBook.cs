using System.Collections.Generic;
using System.Linq;

namespace CC.Base.Market
{
    public class OrderBook
    {
        public static OrderBook Empty = new OrderBook(new OrderBookEntry[0], new OrderBookEntry[0]);

        /// <summary> Sell. Bids less than Asks  </summary>
        public OrderBookEntry[] Asks { get; }

        /// <summary> Buy. Bids less than Asks  </summary>
        public OrderBookEntry[] Bids { get; }

        public OrderBook(IEnumerable<OrderBookEntry> asks, IEnumerable<OrderBookEntry> bids)
        {
            Asks = asks.ToArray();
            Bids = bids.ToArray();
        }
    }
}