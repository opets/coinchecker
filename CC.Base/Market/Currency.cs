namespace CC.Base.Market
{
    public class Currency
    {
        public string Id { get; }
        public string Name { get; }
        public double MinUnit { get; }

        public Currency(string id, string name, double minUnit)
        {
            Id = id;
            Name = name;
            MinUnit = minUnit;
        }
    }
}