using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.COB.Market
{
    internal partial class MarketProvider
    {
        private class OrderBookJson
        {
            public OrderBookContainerJson Orderbook { get; set; }
        }

        private class OrderBookContainerJson
        {
            public long Sequence { get; set; }
            public OrderBookEntryJson[] Bids { get; set; }
            public OrderBookEntryJson[] Asks { get; set; }
        }

        private class OrderBookEntryJson: List<String>
        {
        }

    }
}
