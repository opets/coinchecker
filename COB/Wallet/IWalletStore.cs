using System.Collections.Generic;

namespace CC.COB.Wallet
{
    public interface IWalletStore
    {
        double GetBalance(string сurrency);

        double RefreshBalance(string currency);

        IDictionary<string, double> RefreshBalance(IEnumerable<string> currencies);
    }
}