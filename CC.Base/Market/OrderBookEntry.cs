namespace CC.Base.Market
{
    public class OrderBookEntry
    {
        public OrderBookEntry(double price, double size, double count)
        {
            Price = price;
            Size = size;
            Count = count;
        }

        public double Price { get; }
        public double Size { get; }
        public double Count { get; }
    }
}
