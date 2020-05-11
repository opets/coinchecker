using System;
using System.Collections.Generic;

namespace CC.COB.Wallet
{
	public interface IWalletProvider
	{
	    double GetBalance(string currency);

	    IDictionary<string, double> GetBalance(IEnumerable<string> currencies);
	}
}
