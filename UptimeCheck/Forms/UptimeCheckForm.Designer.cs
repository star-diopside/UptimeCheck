namespace UptimeCheck.Forms
{
    partial class UptimeCheckForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelOSUptimeTitle = new System.Windows.Forms.Label();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.contextMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemFont = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpacityValue = new UptimeCheck.MyLib.CustomControls.ToolStripTrackBar();
            this.menuItemOpacityText = new System.Windows.Forms.ToolStripLabel();
            this.menuItemPos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPosNone = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPosTopLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPosBottomLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPosTopRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPosBottomRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPosMiddleCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemUptimeReset = new System.Windows.Forms.ToolStripMenuItem();
            this.labelProcUptimeTitle = new System.Windows.Forms.Label();
            this.labelOSUptime = new System.Windows.Forms.Label();
            this.labelProcUptime = new System.Windows.Forms.Label();
            this.toolTipMoveHelp = new System.Windows.Forms.ToolTip(this.components);
            this.contextMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemOpacityValue.TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOSUptimeTitle
            // 
            this.labelOSUptimeTitle.AutoSize = true;
            this.labelOSUptimeTitle.Location = new System.Drawing.Point(13, 9);
            this.labelOSUptimeTitle.Name = "labelOSUptimeTitle";
            this.labelOSUptimeTitle.Size = new System.Drawing.Size(141, 20);
            this.labelOSUptimeTitle.TabIndex = 0;
            this.labelOSUptimeTitle.Text = "Windows起動時間 : ";
            // 
            // timerCheck
            // 
            this.timerCheck.Tick += new System.EventHandler(this.TimerTickEvent);
            // 
            // contextMain
            // 
            this.contextMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFont,
            this.menuItemOpacity,
            this.menuItemPos,
            this.menuItemTopMost,
            this.menuItemSeparator,
            this.menuItemUptimeReset});
            this.contextMain.Name = "contextMain";
            this.contextMain.Size = new System.Drawing.Size(290, 130);
            this.contextMain.Opened += new System.EventHandler(this.ContextMainOpenedEvent);
            // 
            // menuItemFont
            // 
            this.menuItemFont.Name = "menuItemFont";
            this.menuItemFont.Size = new System.Drawing.Size(289, 24);
            this.menuItemFont.Text = "フォントの変更(&F)";
            this.menuItemFont.Click += new System.EventHandler(this.FontChangeEvent);
            // 
            // menuItemOpacity
            // 
            this.menuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpacityValue,
            this.menuItemOpacityText});
            this.menuItemOpacity.Name = "menuItemOpacity";
            this.menuItemOpacity.Size = new System.Drawing.Size(289, 24);
            this.menuItemOpacity.Text = "ウィンドウの不透明度(&O)";
            this.menuItemOpacity.DropDownOpened += new System.EventHandler(this.OpacityMenuDropDownOpenedEvent);
            // 
            // menuItemOpacityValue
            // 
            this.menuItemOpacityValue.Name = "menuItemOpacityValue";
            this.menuItemOpacityValue.Size = new System.Drawing.Size(160, 45);
            // 
            // menuItemOpacityValue
            // 
            this.menuItemOpacityValue.TrackBar.AccessibleName = "menuItemOpacityValue";
            this.menuItemOpacityValue.TrackBar.Location = new System.Drawing.Point(41, 3);
            this.menuItemOpacityValue.TrackBar.Maximum = 20;
            this.menuItemOpacityValue.TrackBar.Name = "menuItemOpacityValue";
            this.menuItemOpacityValue.TrackBar.Size = new System.Drawing.Size(160, 45);
            this.menuItemOpacityValue.TrackBar.TabIndex = 0;
            this.menuItemOpacityValue.ValueChanged += new System.EventHandler(this.OpacityChangeEvent);
            // 
            // menuItemOpacityText
            // 
            this.menuItemOpacityText.Name = "menuItemOpacityText";
            this.menuItemOpacityText.Size = new System.Drawing.Size(0, 0);
            // 
            // menuItemPos
            // 
            this.menuItemPos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPosNone,
            this.menuItemPosTopLeft,
            this.menuItemPosBottomLeft,
            this.menuItemPosTopRight,
            this.menuItemPosBottomRight,
            this.menuItemPosMiddleCenter});
            this.menuItemPos.Name = "menuItemPos";
            this.menuItemPos.Size = new System.Drawing.Size(289, 24);
            this.menuItemPos.Text = "ウィンドウの位置(&P)";
            this.menuItemPos.DropDownOpened += new System.EventHandler(this.PosMenuDropDownOpenedEvent);
            // 
            // menuItemPosNone
            // 
            this.menuItemPosNone.Name = "menuItemPosNone";
            this.menuItemPosNone.Size = new System.Drawing.Size(205, 26);
            this.menuItemPosNone.Text = "指定しない(&N)";
            this.menuItemPosNone.Click += new System.EventHandler(this.PosSubMenuClickEvent);
            // 
            // menuItemPosTopLeft
            // 
            this.menuItemPosTopLeft.Name = "menuItemPosTopLeft";
            this.menuItemPosTopLeft.Size = new System.Drawing.Size(205, 26);
            this.menuItemPosTopLeft.Text = "デスクトップ左上(&1)";
            this.menuItemPosTopLeft.Click += new System.EventHandler(this.PosSubMenuClickEvent);
            // 
            // menuItemPosBottomLeft
            // 
            this.menuItemPosBottomLeft.Name = "menuItemPosBottomLeft";
            this.menuItemPosBottomLeft.Size = new System.Drawing.Size(205, 26);
            this.menuItemPosBottomLeft.Text = "デスクトップ左下(&2)";
            this.menuItemPosBottomLeft.Click += new System.EventHandler(this.PosSubMenuClickEvent);
            // 
            // menuItemPosTopRight
            // 
            this.menuItemPosTopRight.Name = "menuItemPosTopRight";
            this.menuItemPosTopRight.Size = new System.Drawing.Size(205, 26);
            this.menuItemPosTopRight.Text = "デスクトップ右上(&3)";
            this.menuItemPosTopRight.Click += new System.EventHandler(this.PosSubMenuClickEvent);
            // 
            // menuItemPosBottomRight
            // 
            this.menuItemPosBottomRight.Name = "menuItemPosBottomRight";
            this.menuItemPosBottomRight.Size = new System.Drawing.Size(205, 26);
            this.menuItemPosBottomRight.Text = "デスクトップ右下(&4)";
            this.menuItemPosBottomRight.Click += new System.EventHandler(this.PosSubMenuClickEvent);
            // 
            // menuItemPosMiddleCenter
            // 
            this.menuItemPosMiddleCenter.Name = "menuItemPosMiddleCenter";
            this.menuItemPosMiddleCenter.Size = new System.Drawing.Size(205, 26);
            this.menuItemPosMiddleCenter.Text = "デスクトップ中央(&5)";
            this.menuItemPosMiddleCenter.Click += new System.EventHandler(this.PosSubMenuClickEvent);
            // 
            // menuItemTopMost
            // 
            this.menuItemTopMost.Name = "menuItemTopMost";
            this.menuItemTopMost.Size = new System.Drawing.Size(289, 24);
            this.menuItemTopMost.Text = "常に手前に表示する(&T)";
            this.menuItemTopMost.Click += new System.EventHandler(this.FormTopMostEvent);
            // 
            // menuItemSeparator
            // 
            this.menuItemSeparator.Name = "menuItemSeparator";
            this.menuItemSeparator.Size = new System.Drawing.Size(286, 6);
            // 
            // menuItemUptimeReset
            // 
            this.menuItemUptimeReset.Name = "menuItemUptimeReset";
            this.menuItemUptimeReset.Size = new System.Drawing.Size(289, 24);
            this.menuItemUptimeReset.Text = "プログラム起動時間をリセットする(&R)";
            this.menuItemUptimeReset.Click += new System.EventHandler(this.UptimeResetEvent);
            // 
            // labelProcUptimeTitle
            // 
            this.labelProcUptimeTitle.AutoSize = true;
            this.labelProcUptimeTitle.Location = new System.Drawing.Point(12, 29);
            this.labelProcUptimeTitle.Name = "labelProcUptimeTitle";
            this.labelProcUptimeTitle.Size = new System.Drawing.Size(135, 20);
            this.labelProcUptimeTitle.TabIndex = 1;
            this.labelProcUptimeTitle.Text = "プログラム起動時間 : ";
            // 
            // labelOSUptime
            // 
            this.labelOSUptime.AutoSize = true;
            this.labelOSUptime.Location = new System.Drawing.Point(168, 15);
            this.labelOSUptime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOSUptime.Name = "labelOSUptime";
            this.labelOSUptime.Size = new System.Drawing.Size(0, 20);
            this.labelOSUptime.TabIndex = 2;
            this.labelOSUptime.Resize += new System.EventHandler(this.ControlResizeEvent);
            // 
            // labelProcUptime
            // 
            this.labelProcUptime.AutoSize = true;
            this.labelProcUptime.Location = new System.Drawing.Point(168, 52);
            this.labelProcUptime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProcUptime.Name = "labelProcUptime";
            this.labelProcUptime.Size = new System.Drawing.Size(0, 20);
            this.labelProcUptime.TabIndex = 3;
            this.labelProcUptime.Resize += new System.EventHandler(this.ControlResizeEvent);
            // 
            // toolTipMoveHelp
            // 
            this.toolTipMoveHelp.IsBalloon = true;
            this.toolTipMoveHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipMoveHelp.ToolTipTitle = "ウィンドウ移動のキャンセル";
            // 
            // UptimeCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.ContextMenuStrip = this.contextMain;
            this.Controls.Add(this.labelProcUptime);
            this.Controls.Add(this.labelOSUptime);
            this.Controls.Add(this.labelProcUptimeTitle);
            this.Controls.Add(this.labelOSUptimeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UptimeCheckForm";
            this.Text = "システム起動時間";
            this.contextMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuItemOpacityValue.TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOSUptimeTitle;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.ContextMenuStrip contextMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemUptimeReset;
        private System.Windows.Forms.ToolStripMenuItem menuItemTopMost;
        private System.Windows.Forms.Label labelProcUptimeTitle;
        private System.Windows.Forms.Label labelOSUptime;
        private System.Windows.Forms.Label labelProcUptime;
        private System.Windows.Forms.ToolStripMenuItem menuItemFont;
        private System.Windows.Forms.ToolStripSeparator menuItemSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpacity;
        private MyLib.CustomControls.ToolStripTrackBar menuItemOpacityValue;
        private System.Windows.Forms.ToolStripLabel menuItemOpacityText;
        private System.Windows.Forms.ToolStripMenuItem menuItemPos;
        private System.Windows.Forms.ToolStripMenuItem menuItemPosNone;
        private System.Windows.Forms.ToolStripMenuItem menuItemPosTopLeft;
        private System.Windows.Forms.ToolStripMenuItem menuItemPosBottomLeft;
        private System.Windows.Forms.ToolStripMenuItem menuItemPosTopRight;
        private System.Windows.Forms.ToolStripMenuItem menuItemPosBottomRight;
        private System.Windows.Forms.ToolStripMenuItem menuItemPosMiddleCenter;
        private System.Windows.Forms.ToolTip toolTipMoveHelp;
    }
}
