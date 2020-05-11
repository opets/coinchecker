using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CC.Base.Extensions;
using CC.Base.UI.Logger;
using log4net;
using log4net.Core;
using SourceGrid.Cells;
using ColumnHeader = SourceGrid.Cells.ColumnHeader;

namespace CC.COB.UI
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Store Store { get; }

        public MainForm()
        {
            InitializeComponent();
            Store = Store.Create();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshButton_Click(null, null);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (!refreshBackgrWorker.IsBusy)
            {
                Log.Debug("Refreshing...");
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                refreshBackgrWorker.RunWorkerAsync();
            }
        }

        private void BindWallet()
        {
            IEnumerable<string> lines = Store.MarketStore.Currencies
                .Select(c => new KeyValuePair<string,double>(c.Id, Store.WalletStore.GetBalance(c.Id)))
                .OrderByDescending(c=>c.Value)
                .Select(c=>$@"{c.Key.PadRight(7)}	{c.Value:F10}");
            walletTextBox.Text = string.Join(Environment.NewLine, lines);

            if (walletTab.Visible) walletTextBox.Invalidate();
        }

        private void refreshBackgrWorker_Do(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Store.RefreshBase();
            refreshBackgrWorker.ReportProgress(20);
            Store.RefreshOrderBook(currency => refreshBackgrWorker.ReportProgress(40, currency));
            refreshBackgrWorker.ReportProgress(60);
            Store.RefreshWallet();
            refreshBackgrWorker.ReportProgress(80);
            
            refreshBackgrWorker.ReportProgress(100);
        }

        private void refreshBackgrWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            switch (e.ProgressPercentage)
            {
                case 20:
                    BindGridToCurrencyNames();
                    break;
                case 40:
                    BindGridRowToOrderBook(e.UserState.ToString());
                    break;
                case 80:
                    BindWallet();
                    break;

            }
        }

        private void refreshBackgrWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
        }

        void BindGridRowToOrderBook(string currencyId)
        {
            int rowIndex = grid1.Rows.FirstOrDefault(r => string.Equals(r.Tag, currencyId))?.Index ?? -1;
            if (rowIndex == -1)
                return;

            var circle = Store.PredictCircle(currencyId, 0.01);
            var backCircle = Store.PredictBackCircle(currencyId, 0.01);
            var circle70 = Store.PredictCircle70(currencyId, 0.01, 0.7);
            var backCircle70 = Store.PredictBackCircle70(currencyId, 0.01, 0.7);

            grid1[rowIndex, 1] = new Cell($"{circle * 100:P}", typeof(string));
            grid1[rowIndex, 2] = new Cell($"{backCircle * 100:P}", typeof(string));
            grid1[rowIndex, 3] = new Cell($"{circle70 * 100:P}", typeof(string));
            grid1[rowIndex, 4] = new Cell($"{backCircle70 * 100:P}", typeof(string));

            var isAttention = circle > 0.01 || backCircle > 0.01;
            Enumerable.Range(0, grid1.ColumnsCount).Foreach(col =>
                grid1[rowIndex, col].View =
                    isAttention ? GridHelper.CellViewAttention : GridHelper.CellViewNormal
            );
            if (gridTab.Visible)
                grid1.Invalidate();
        }

        private void BindGridToCurrencyNames()
        {
            grid1.RowsCount = Store.MarketStore.Currencies.Length + 1;
            grid1.ColumnsCount = 5;
            //Header
            grid1[0, 0] = new ColumnHeader("Currency");
            grid1[0, 1] = new ColumnHeader("Circle %");
            grid1[0, 2] = new ColumnHeader("Back %");
            grid1[0, 3] = new ColumnHeader("Circle 70");
            grid1[0, 4] = new ColumnHeader("Back 70");
            grid1.Columns[0].Width = 60;
            grid1.Columns[1].Width = 60;
            grid1.Columns[2].Width = 60;
            grid1.Columns[3].Width = 60;
            grid1.Columns[4].Width = 60;

            var rowIndex = 0;
            foreach (var currency in Store.MarketStore.Currencies.Where(c => c.Id != "ETH" && c.Id != "BTC"))
            {
                rowIndex++;
                grid1[rowIndex, 0] = new Cell(currency.Id, typeof(string));
                grid1.Rows[rowIndex].Tag = currency.Id;
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loggerLevelDropDownButton.DropDownItems
                .OfType<ToolStripMenuItem>()
                .Foreach(i => i.Checked = i == sender);

            (sender as ToolStripMenuItem)
                .IfNotNull(i =>
                {
                    loggerLevelDropDownButton.Text = i.Text;
                    loggerLevelDropDownButton.ToolTipText = i.ToolTipText;

                    var levels = new[]
                        {Level.All, Level.Debug, Level.Info, Level.Warn, Level.Error, Level.Fatal, Level.Off};
                    var level = levels.First(l => l.Name == i.Text);
                    LoggerHelper.SetAppenderLogLevel(level, "richTextAppender");
                });
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            loggerRichTextBox.Text = string.Empty;
        }

    }
}