
namespace CC.COB.Wallet
{
    internal partial class WalletProvider
    {
        private class LedgerContainerJson
        {
            public LedgerJson[] Ledger { get; set; }
        }

        private class LedgerJson
        {
            public string Trade_Id { get; set; }
            public string Type { get; set; }
            public string Currency { get; set; }
            public string Amount { get; set; }
            public string Balance { get; set; }
            public string Timestamp { get; set; }
        }


    }
}