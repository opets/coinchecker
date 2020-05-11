using System;
using System.Diagnostics;
using System.Linq;
using Autofac;
using CC.Base.Extensions;
using CC.COB.Tests.Common;
using CC.COB.Wallet;
using NUnit.Framework;

namespace CC.COB.Tests.Wallet
{
    [TestFixture]
    internal sealed class WalletDisplayAllTests
    {
        private IWalletStore _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = TestHelper.ServiceLocator.Resolve<IWalletStore>();
        }

        [Test]
        public void Balance_Test()
        {
            var sw = Stopwatch.StartNew();
            var wallet = _sut
                .RefreshBalance(
                    "BAT,USD,BAR,GNT,NGC,PAY,REP,ETH,EOS,COB,FUN,ETHOS,CMT,CVC,SAN,DGD,OCN,IOST,MANA,SPHTX,BDG,GTC,ICN,ENJ,VOISE,STK,TRX,GNO,ZRX,DRGN,OMG,INS,SNT,BTC,UTNP,BRD"
                        .Split(new[] {','})).OrderByDescending(p=>p.Value);
                
            wallet.Foreach(c => Console.WriteLine($"{c.Key.PadRight(7)}\t{c.Value:F10}"));

            Console.WriteLine($"Elapsed {sw.Elapsed.Seconds}s");
        }

    }
}