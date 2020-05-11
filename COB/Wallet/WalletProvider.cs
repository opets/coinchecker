using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CC.Base.Extensions;
using CC.Base.Rest;
using log4net;

namespace CC.COB.Wallet
{
    internal partial class WalletProvider : IWalletProvider
    {
        private const string GetAllLedgerUrl = "/v1/wallet/ledger?limit=50";
        private const string GetLedgerUrl = "/v1/wallet/ledger?currency={0}&limit=1";
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IWebClient _webClient;

        public WalletProvider(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public double GetBalance(string currency)
        {
            try
            {
                var ledgers = _webClient.GetObjectWithAuth<LedgerContainerJson>(string.Format(GetLedgerUrl, currency))
                    ?.Ledger;
                return GetBalanceFromLedgers(ledgers);
            }
            catch (Exception ex)
            {
                Log.Error($"Unable to call GetBalance", ex);
                return 0;
            }
        }

        public IDictionary<string, double> GetBalance(IEnumerable<string> currencies)
        {
            IDictionary<string, double> res = new Dictionary<string, double>();
            try
            {
                var ledgers = _webClient.GetObjectWithAuth<LedgerContainerJson>(GetAllLedgerUrl)?.Ledger.ToArray()
                    .EmptyIfNull();

                foreach (var currency in currencies)
                {
                    var filteredLedgers = ledgers.Where(l => string.Equals(l.Currency, currency)).ToArray();
                    if (!filteredLedgers.Any())
                        filteredLedgers = _webClient
                            .GetObjectWithAuth<LedgerContainerJson>(string.Format(GetLedgerUrl, currency))?.Ledger;

                    var balance = GetBalanceFromLedgers(filteredLedgers);

                    res.Add(currency, balance);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Unable to call GetBalance", ex);
            }

            return res;
        }

        private static double GetBalanceFromLedgers(LedgerJson[] ledgers)
        {
            var ledger = ledgers?.OrderByDescending(l => l.Timestamp).FirstOrDefault();

            var balance = double.Parse(ledger?.Balance ?? "0");
            return balance;
        }
    }
}