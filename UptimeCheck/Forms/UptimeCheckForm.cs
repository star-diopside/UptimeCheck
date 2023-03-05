using UptimeCheck.MyLib.CustomControls;
using UptimeCheck.Properties;

namespace UptimeCheck.Forms;

public partial class UptimeCheckForm : CustomForm
{
    // 起動時間格納フィールド
    private long _startTickCount;

    // ウィンドウ位置の指定用フィールド
    private FormAlignment _alignment = FormAlignment.None;

    /// <summary>
    /// ウィンドウ位置を指定する定数
    /// </summary>
    public enum FormAlignment
    {
        None,
        BottomLeft,
        BottomRight,
        MiddleCenter,
        TopLeft,
        TopRight,
    }

    /// <summary>
    /// ウィンドウ位置を指定する
    /// </summary>
    public FormAlignment Alignment
    {
        get
        {
            return _alignment;
        }
        set
        {
            _alignment = value;
            CanMove = _alignment == FormAlignment.None;
        }
    }

    public UptimeCheckForm()
    {
        InitializeComponent();

        // ウィンドウ位置調整用の設定を行う
        menuItemPosNone.Tag = FormAlignment.None;
        menuItemPosTopLeft.Tag = FormAlignment.TopLeft;
        menuItemPosBottomLeft.Tag = FormAlignment.BottomLeft;
        menuItemPosTopRight.Tag = FormAlignment.TopRight;
        menuItemPosBottomRight.Tag = FormAlignment.BottomRight;
        menuItemPosMiddleCenter.Tag = FormAlignment.MiddleCenter;

        // OS起動後の経過時間を取得する
        _startTickCount = GetUptimeTick();

        // コントロール配置を設定する
        InitControlPos();

        // ラベルコントロールとウィンドウサイズを設定する
        SetUptimeText();

        // タイマを起動する
        timerCheck.Start();
    }

    /// <summary>
    /// コントロールの配置を初期化する
    /// </summary>
    private void InitControlPos()
    {
        int maxTitleWidth = Math.Max(labelOSUptimeTitle.Width, labelProcUptimeTitle.Width);

        labelOSUptimeTitle.Location = new(maxTitleWidth - labelOSUptimeTitle.Width + 12, 8);
        labelOSUptime.Location = new(labelOSUptimeTitle.Right, labelOSUptimeTitle.Top);
        labelProcUptimeTitle.Location = new(maxTitleWidth - labelProcUptimeTitle.Width + 12,
                                            labelOSUptimeTitle.Bottom + 4);
        labelProcUptime.Location = new(labelProcUptimeTitle.Right, labelProcUptimeTitle.Top);
    }

    /// <summary>
    /// フォームのサイズを自動調整する
    /// </summary>
    private void AdjustFormSize()
    {
        int maxLabelWidth = Math.Max(labelOSUptime.Width, labelProcUptime.Width);

        ClientSize = new(labelOSUptime.Left + maxLabelWidth + labelOSUptimeTitle.Left,
                         labelProcUptime.Bottom + labelOSUptime.Top);
    }

    /// <summary>
    /// コントロールのサイズ変更時のイベント処理
    /// </summary>
    private void ControlResizeEvent(object sender, EventArgs e) => AdjustFormSize();

    /// <summary>
    /// タイマイベント処理
    /// </summary>
    private void TimerTickEvent(object sender, EventArgs e) => SetUptimeText();

    /// <summary>
    /// ラベルコントロールに起動時間を設定する
    /// </summary>
    private void SetUptimeText()
    {
        // OS起動時間をチェックする
        TimeSpan systemRunSpan = TimeSpan.FromMilliseconds(GetUptimeTick());

        // プログラム起動時間をチェックする
        TimeSpan countSpan = TimeSpan.FromMilliseconds(GetUptimeTick() - _startTickCount);

        // 表示用文字列を生成する
        labelOSUptime.Text = CreateTimeSpanString(systemRunSpan);
        labelProcUptime.Text = CreateTimeSpanString(countSpan);
    }

    /// <summary>
    /// システム起動後のミリ秒単位の経過時間を取得する
    /// </summary>
    /// <returns>システム起動後のミリ秒単位の経過時間</returns>
    private static long GetUptimeTick() => Environment.TickCount;

    /// <summary>
    /// TimeSpanの値を示す文字列を生成する
    /// </summary>
    /// <param name="ts">TimeSpanオブジェクト</param>
    /// <returns>TimeSpanの値を示す文字列</returns>
    private static string CreateTimeSpanString(TimeSpan ts)
    {
        if (ts.Days >= 1)
        {
            // 1日を超える場合の文字列表現を返す
            return string.Format(Resources.DateWithDayFormat, ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }
        else
        {
            // 1日未満の場合の文字列表現を返す
            return string.Format(Resources.DateWithoutDayFormat, ts.Hours, ts.Minutes, ts.Seconds);
        }
    }

    /// <summary>
    /// フォームのサイズ変更または移動終了時の処理
    /// </summary>
    protected override void OnResizeEnd(EventArgs e)
    {
        base.OnResizeEnd(e);

        // フォームサイズと位置を再設定する
        AdjustFormSize();
        AutoFormPosition();
    }

    /// <summary>
    /// フォームのサイズ変更時の処理
    /// </summary>
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        // フォームサイズと位置を再設定する
        AdjustFormSize();
        AutoFormPosition();
    }

    /// <summary>
    /// ウィンドウを最小化した時の処理
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMinimize(EventArgs e)
    {
        base.OnMinimize(e);

        // タイマを停止する
        timerCheck.Stop();
    }

    /// <summary>
    /// ウィンドウを元の位置とサイズに戻した時の処理
    /// </summary>
    protected override void OnRestore(EventArgs e)
    {
        base.OnRestore(e);

        // テキストを再設定する
        SetUptimeText();

        // フォームサイズと位置を再設定する
        AdjustFormSize();
        AutoFormPosition();

        // タイマを起動する
        timerCheck.Start();
    }

    /// <summary>
    /// ウィンドウの移動がキャンセルされた場合の処理
    /// </summary>
    protected override void OnMoveCanceled(EventArgs e)
    {
        base.OnMoveCanceled(e);

        // ツールチップでヘルプメッセージを表示する
        toolTipMoveHelp.Show(Resources.MoveCancelHelpText, this, PointToClient(MousePosition));

        // マウスをキャプチャする
        Capture = true;
    }

    /// <summary>
    /// マウスボタンが離された場合の処理
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        // ツールチップを非表示にする
        toolTipMoveHelp.Hide(this);
    }

    /// <summary>
    /// プログラム起動時間リセットイベント処理
    /// </summary>
    private void UptimeResetEvent(object sender, EventArgs e)
    {
        // プログラム起動時間をリセットする
        _startTickCount = GetUptimeTick();
    }

    /// <summary>
    /// フォームを最前面に設定するイベント処理
    /// </summary>
    private void FormTopMostEvent(object sender, EventArgs e)
    {
        // フォームを最前面に表示する設定を切り替える
        TopMost = !TopMost;
    }

    /// <summary>
    /// コンテキストメニューを開いたときのイベント処理
    /// </summary>
    private void ContextMainOpenedEvent(object sender, EventArgs e)
    {
        menuItemOpacity.Visible = OSFeature.Feature.IsPresent(OSFeature.LayeredWindows);
        menuItemTopMost.Checked = TopMost;
    }

    /// <summary>
    /// フォント変更イベント処理
    /// </summary>
    private void FontChangeEvent(object sender, EventArgs e)
    {
        using var dialog = new FontDialog();

        // ウィンドウのフォントを初期値として設定する
        dialog.Font = Font;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            // ウィンドウのフォントを設定する
            Font = dialog.Font;

            // コントロール配置を設定する
            InitControlPos();

            // フォームサイズを調整する
            AdjustFormSize();
        }
    }

    /// <summary>
    /// フォームの不透明度を変更するイベント
    /// </summary>
    private void OpacityChangeEvent(object sender, EventArgs e)
    {
        // トラックバーの設定値をフォームの不透明度に反映する
        TrackBar trackBar = menuItemOpacityValue.TrackBar;
        Opacity = (double)trackBar.Value / (trackBar.Maximum - trackBar.Minimum);

        // フォームの不透明度をテキストで表示する
        menuItemOpacityText.Text = string.Format(Resources.OpacityTextFormat, (int)(Opacity * 100.0));
    }

    /// <summary>
    /// 不透明度設定メニューのドロップダウンが開いたときのイベント処理
    /// </summary>
    private void OpacityMenuDropDownOpenedEvent(object sender, EventArgs e)
    {
        // フォームの不透明度をトラックバーに反映する
        TrackBar trackBar = menuItemOpacityValue.TrackBar;
        trackBar.Value = trackBar.Minimum + (int)((trackBar.Maximum - trackBar.Minimum) * Opacity);

        // フォームの不透明度をテキストで表示する
        menuItemOpacityText.Text = string.Format(Resources.OpacityTextFormat, (int)(Opacity * 100.0));
    }

    /// <summary>
    /// ウィンドウ位置指定のドロップダウンが開いたときのイベント処理
    /// </summary>
    private void PosMenuDropDownOpenedEvent(object sender, EventArgs e)
    {
        ToolStripMenuItem[] menuItems = { menuItemPosNone, menuItemPosTopLeft, menuItemPosBottomLeft,
            menuItemPosTopRight, menuItemPosBottomRight, menuItemPosMiddleCenter };

        foreach (ToolStripMenuItem menuItem in menuItems)
        {
            menuItem.Checked = Alignment.Equals(menuItem.Tag);
        }
    }

    /// <summary>
    /// ウィンドウ位置指定メニューが選択されたときのイベント処理
    /// </summary>
    private void PosSubMenuClickEvent(object sender, EventArgs e)
    {
        // ウィンドウ位置を設定する
        Alignment = (FormAlignment)((ToolStripMenuItem)sender).Tag;

        // ウィンドウ位置を自動調整する
        AutoFormPosition();
    }

    /// <summary>
    /// ウィンドウ位置を自動調整する
    /// </summary>
    private void AutoFormPosition()
    {
        // ウィンドウが通常表示以外の場合は何も処理しない
        if (WindowState != FormWindowState.Normal)
        {
            return;
        }

        // ウィンドウ位置を指定しない場合は何も処理しない
        if (Alignment == FormAlignment.None)
        {
            return;
        }

        // プライマリディスプレイが取得できない場合は何も処理しない
        if (Screen.PrimaryScreen is null)
        {
            return;
        }

        Rectangle workArea = Screen.PrimaryScreen.WorkingArea;

        Location = Alignment switch
        {
            FormAlignment.TopLeft => new(workArea.Left, workArea.Top),
            FormAlignment.BottomLeft => new(workArea.Left, workArea.Bottom - Height),
            FormAlignment.TopRight => new(workArea.Right - Width, workArea.Top),
            FormAlignment.BottomRight => new(workArea.Right - Width, workArea.Bottom - Height),
            FormAlignment.MiddleCenter => new(workArea.Left + (workArea.Width - Width) / 2,
                                              workArea.Top + (workArea.Height - Height) / 2),
            _ => throw new InvalidOperationException()
        };
    }
}
