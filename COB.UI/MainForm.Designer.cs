namespace CC.COB.UI {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private global::System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.gridTab = new System.Windows.Forms.TabPage();
            this.grid1 = new SourceGrid.Grid();
            this.detailsTabs = new System.Windows.Forms.TabControl();
            this.logTab = new System.Windows.Forms.TabPage();
            this.loggerRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.clearLogButton = new System.Windows.Forms.ToolStripButton();
            this.loggerLevelDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.aLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNFOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wARNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eRRORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fATALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gloablActionsTab = new System.Windows.Forms.TabPage();
            this.coinActionsTab = new System.Windows.Forms.TabPage();
            this.refreshBackgrWorker = new System.ComponentModel.BackgroundWorker();
            this.walletTab = new System.Windows.Forms.TabPage();
            this.walletTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.gridTab.SuspendLayout();
            this.detailsTabs.SuspendLayout();
            this.logTab.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.walletTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1081, 24);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 18);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1081, 34);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(28, 28);
            this.refreshButton.Text = "toolStripButton1";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 34);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.mainTabs);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.detailsTabs);
            this.splitContainer.Size = new System.Drawing.Size(1081, 590);
            this.splitContainer.SplitterDistance = 641;
            this.splitContainer.TabIndex = 8;
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.gridTab);
            this.mainTabs.Controls.Add(this.walletTab);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Location = new System.Drawing.Point(0, 0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(641, 590);
            this.mainTabs.TabIndex = 2;
            // 
            // gridTab
            // 
            this.gridTab.Controls.Add(this.grid1);
            this.gridTab.Location = new System.Drawing.Point(4, 25);
            this.gridTab.Name = "gridTab";
            this.gridTab.Padding = new System.Windows.Forms.Padding(3);
            this.gridTab.Size = new System.Drawing.Size(633, 561);
            this.gridTab.TabIndex = 0;
            this.gridTab.Text = "Coin";
            this.gridTab.UseVisualStyleBackColor = true;
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.ColumnsCount = 7;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnableSort = true;
            this.grid1.FixedColumns = 1;
            this.grid1.FixedRows = 1;
            this.grid1.Location = new System.Drawing.Point(3, 3);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.RowsCount = 1;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.grid1.Size = new System.Drawing.Size(627, 555);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // detailsTabs
            // 
            this.detailsTabs.Controls.Add(this.logTab);
            this.detailsTabs.Controls.Add(this.gloablActionsTab);
            this.detailsTabs.Controls.Add(this.coinActionsTab);
            this.detailsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTabs.Location = new System.Drawing.Point(0, 0);
            this.detailsTabs.Name = "detailsTabs";
            this.detailsTabs.SelectedIndex = 0;
            this.detailsTabs.Size = new System.Drawing.Size(436, 590);
            this.detailsTabs.TabIndex = 3;
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.loggerRichTextBox);
            this.logTab.Controls.Add(this.toolStrip2);
            this.logTab.Location = new System.Drawing.Point(4, 25);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(428, 561);
            this.logTab.TabIndex = 0;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // loggerRichTextBox
            // 
            this.loggerRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.loggerRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loggerRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerRichTextBox.Location = new System.Drawing.Point(3, 34);
            this.loggerRichTextBox.Name = "loggerRichTextBox";
            this.loggerRichTextBox.ReadOnly = true;
            this.loggerRichTextBox.Size = new System.Drawing.Size(422, 524);
            this.loggerRichTextBox.TabIndex = 11;
            this.loggerRichTextBox.Text = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogButton,
            this.loggerLevelDropDownButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(422, 31);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // clearLogButton
            // 
            this.clearLogButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearLogButton.Image = ((System.Drawing.Image)(resources.GetObject("clearLogButton.Image")));
            this.clearLogButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearLogButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(28, 28);
            this.clearLogButton.Text = "toolStripButton1";
            this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
            // 
            // loggerLevelDropDownButton
            // 
            this.loggerLevelDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loggerLevelDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aLLToolStripMenuItem,
            this.dEBUGToolStripMenuItem,
            this.iNFOToolStripMenuItem,
            this.wARNToolStripMenuItem,
            this.eRRORToolStripMenuItem,
            this.fATALToolStripMenuItem,
            this.oFFToolStripMenuItem});
            this.loggerLevelDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("loggerLevelDropDownButton.Image")));
            this.loggerLevelDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loggerLevelDropDownButton.Name = "loggerLevelDropDownButton";
            this.loggerLevelDropDownButton.Size = new System.Drawing.Size(56, 28);
            this.loggerLevelDropDownButton.Text = "INFO";
            this.loggerLevelDropDownButton.ToolTipText = "INFO";
            // 
            // aLLToolStripMenuItem
            // 
            this.aLLToolStripMenuItem.Name = "aLLToolStripMenuItem";
            this.aLLToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.aLLToolStripMenuItem.Tag = "";
            this.aLLToolStripMenuItem.Text = "ALL";
            this.aLLToolStripMenuItem.ToolTipText = "The ALL has the lowest possible rank and is intended to turn on all logging.";
            this.aLLToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // dEBUGToolStripMenuItem
            // 
            this.dEBUGToolStripMenuItem.Name = "dEBUGToolStripMenuItem";
            this.dEBUGToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.dEBUGToolStripMenuItem.Text = "DEBUG";
            this.dEBUGToolStripMenuItem.ToolTipText = resources.GetString("dEBUGToolStripMenuItem.ToolTipText");
            this.dEBUGToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // iNFOToolStripMenuItem
            // 
            this.iNFOToolStripMenuItem.Checked = true;
            this.iNFOToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iNFOToolStripMenuItem.Name = "iNFOToolStripMenuItem";
            this.iNFOToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.iNFOToolStripMenuItem.Text = "INFO";
            this.iNFOToolStripMenuItem.ToolTipText = resources.GetString("iNFOToolStripMenuItem.ToolTipText");
            this.iNFOToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // wARNToolStripMenuItem
            // 
            this.wARNToolStripMenuItem.Name = "wARNToolStripMenuItem";
            this.wARNToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.wARNToolStripMenuItem.Text = "WARN";
            this.wARNToolStripMenuItem.ToolTipText = resources.GetString("wARNToolStripMenuItem.ToolTipText");
            this.wARNToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // eRRORToolStripMenuItem
            // 
            this.eRRORToolStripMenuItem.Name = "eRRORToolStripMenuItem";
            this.eRRORToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.eRRORToolStripMenuItem.Text = "ERROR";
            this.eRRORToolStripMenuItem.ToolTipText = "ERROR level designates error events that might still allow the application to con" +
    "tinue running.\r\nFATAL level designates very severe error events that will presum" +
    "ably lead the application to abort.";
            this.eRRORToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // fATALToolStripMenuItem
            // 
            this.fATALToolStripMenuItem.Name = "fATALToolStripMenuItem";
            this.fATALToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.fATALToolStripMenuItem.Text = "FATAL";
            this.fATALToolStripMenuItem.ToolTipText = "FATAL level designates very severe error events that will presumably lead the app" +
    "lication to abort.";
            this.fATALToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // oFFToolStripMenuItem
            // 
            this.oFFToolStripMenuItem.Name = "oFFToolStripMenuItem";
            this.oFFToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.oFFToolStripMenuItem.Text = "OFF";
            this.oFFToolStripMenuItem.ToolTipText = "The OFF has the highest possible rank and is intended to turn off logging.";
            this.oFFToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // gloablActionsTab
            // 
            this.gloablActionsTab.Location = new System.Drawing.Point(4, 25);
            this.gloablActionsTab.Name = "gloablActionsTab";
            this.gloablActionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.gloablActionsTab.Size = new System.Drawing.Size(428, 563);
            this.gloablActionsTab.TabIndex = 1;
            this.gloablActionsTab.Text = "Global Actions";
            this.gloablActionsTab.UseVisualStyleBackColor = true;
            // 
            // coinActionsTab
            // 
            this.coinActionsTab.Location = new System.Drawing.Point(4, 25);
            this.coinActionsTab.Name = "coinActionsTab";
            this.coinActionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.coinActionsTab.Size = new System.Drawing.Size(428, 563);
            this.coinActionsTab.TabIndex = 2;
            this.coinActionsTab.Text = "Coin Actions";
            this.coinActionsTab.UseVisualStyleBackColor = true;
            // 
            // refreshBackgrWorker
            // 
            this.refreshBackgrWorker.WorkerReportsProgress = true;
            this.refreshBackgrWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refreshBackgrWorker_Do);
            this.refreshBackgrWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.refreshBackgrWorker_ProgressChanged);
            this.refreshBackgrWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refreshBackgrWorker_RunWorkerCompleted);
            // 
            // walletTab
            // 
            this.walletTab.Controls.Add(this.walletTextBox);
            this.walletTab.Location = new System.Drawing.Point(4, 25);
            this.walletTab.Name = "walletTab";
            this.walletTab.Padding = new System.Windows.Forms.Padding(3);
            this.walletTab.Size = new System.Drawing.Size(633, 561);
            this.walletTab.TabIndex = 1;
            this.walletTab.Text = "Wallet";
            this.walletTab.UseVisualStyleBackColor = true;
            // 
            // walletTextBox
            // 
            this.walletTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.walletTextBox.Location = new System.Drawing.Point(3, 3);
            this.walletTextBox.Multiline = true;
            this.walletTextBox.Name = "walletTextBox";
            this.walletTextBox.ReadOnly = true;
            this.walletTextBox.Size = new System.Drawing.Size(219, 555);
            this.walletTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1081, 648);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Coin Checker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.mainTabs.ResumeLayout(false);
            this.gridTab.ResumeLayout(false);
            this.detailsTabs.ResumeLayout(false);
            this.logTab.ResumeLayout(false);
            this.logTab.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.walletTab.ResumeLayout(false);
            this.walletTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.TabPage gridTab;
        private System.Windows.Forms.TabControl detailsTabs;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TabPage gloablActionsTab;
        private System.Windows.Forms.TabPage coinActionsTab;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton clearLogButton;
        private System.Windows.Forms.RichTextBox loggerRichTextBox;
        private System.Windows.Forms.ToolStripDropDownButton loggerLevelDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem aLLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNFOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wARNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eRRORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fATALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oFFToolStripMenuItem;
        private SourceGrid.Grid grid1;
        private System.ComponentModel.BackgroundWorker refreshBackgrWorker;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.TabPage walletTab;
        private System.Windows.Forms.TextBox walletTextBox;
    }
}

