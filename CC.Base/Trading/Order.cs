using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Base.Trading
{
    public class Order
    {
        public static Order Empty = new Order();

        public string OrderId { get; set; }
        public string TradingPairId { get; set; }
        public string OrderState { get; set; }
        public OrderSide OrderSide { get; set; }
        public OrderType OrderType { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public double Filled { get; set; }
    }
}
