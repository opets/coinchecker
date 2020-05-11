using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CC.Base.Extensions;
using CC.Base.Market;

namespace CC.COB.Wallet
{
    internal sealed class WalletStore : IWalletStore
    {
        private readonly IWalletProvider _walletProvider;
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IDictionary<string, double> _balance = new ConcurrentDictionary<string, double>();

        public WalletStore(IWalletProvider WalletProvider)
        {
            _walletProvider = WalletProvider;
        }

        public double GetBalance(string currency)
        {
            return _balance.ContainsKey(currency) ? _balance[currency] : -1;
        }

        public IDictionary<string, double> RefreshBalance(IEnumerable<string> currencies)
        {
            var balancePairs = _walletProvider.GetBalance(currencies);
            balancePairs.Foreach(pair => UpdateBalancePair(pair.Key, pair.Value));
            return _balance;
        }

        public double RefreshBalance(string currency)
        {
            double balance = _walletProvider.GetBalance(currency);
            UpdateBalancePair(currency, balance);
            return balance;
        }

        private void UpdateBalancePair(string currency, double balance) => _balance.InsertOrUpdate(currency, balance);
    }
}