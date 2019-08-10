using System;
using System.ComponentModel;
using System.Windows.Forms;
using UptimeCheck.MyLib.WindowsShell;

namespace UptimeCheck.MyLib.CustomControls
{
    /// <summary>
    /// ウィンドウ状態についてのイベントを追加したカスタムフォーム
    /// </summary>
    public class CustomForm : Form
    {
        // ウィンドウメッセージ定数の定義
        private const int WM_NULL = 0x0000;
        private const int WM_INITMENUPOPUP = 0x0117;
        private const int WM_SYSCOMMAND = 0x0112;

        private const int SC_MOVE = 0xF010;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_RESTORE = 0xF120;

        /// <summary>
        /// ウィンドウを移動できるかどうかを示す値を取得または設定する
        /// </summary>
        [DefaultValue(true)]
        public bool CanMove { get; set; }

        /// <summary>
        /// CustomFormクラスの新しいインスタンスを初期化する
        /// </summary>
        public CustomForm()
        {
            this.CanMove = true;
        }

        /// <summary>
        /// Windows メッセージを処理する
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (!this.CanMove)
            {
                switch (m.Msg)
                {
                    case WM_INITMENUPOPUP:
                        SystemMenuOperator.SetMoveMenuEnabled(this, false);
                        break;

                    case WM_SYSCOMMAND:
                        if ((m.WParam.ToInt32() & 0xFFF0) == SC_MOVE)
                        {
                            // ウィンドウメッセージを破棄する
                            m.Msg = WM_NULL;

                            // フォームの移動をキャンセルしたことをイベントとして伝える
                            OnMoveCanceled(EventArgs.Empty);
                        }
                        break;
                }
            }

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    switch (m.WParam.ToInt32() & 0xFFF0)
                    {
                        case SC_MAXIMIZE:
                            OnMaximize(EventArgs.Empty);
                            break;

                        case SC_MINIMIZE:
                            OnMinimize(EventArgs.Empty);
                            break;

                        case SC_RESTORE:
                            OnRestore(EventArgs.Empty);
                            break;
                    }
                    break;
            }

            // 基本クラスのメソッドを呼び出す
            base.WndProc(ref m);
        }

        /// <summary>
        /// フォームの移動がキャンセルされたときに発生するイベント
        /// </summary>
        public event EventHandler MoveCanceled;

        /// <summary>
        /// フォームが最大化したときに発生するイベント
        /// </summary>
        public event EventHandler Maximize;

        /// <summary>
        /// フォームが最小化したときに発生するイベント
        /// </summary>
        public event EventHandler Minimize;

        /// <summary>
        /// ウィンドウを元の位置とサイズに戻したときに発生するイベント
        /// </summary>
        public event EventHandler Restore;

        /// <summary>
        /// MoveCanceledイベントを発生させる
        /// </summary>
        /// <param name="e">イベントデータを格納しているEventArgs</param>
        protected virtual void OnMoveCanceled(EventArgs e)
        {
            if (this.MoveCanceled != null)
            {
                this.MoveCanceled(this, e);
            }
        }

        /// <summary>
        /// Maximizeイベントを発生させる
        /// </summary>
        /// <param name="e">イベントデータを格納しているEventArgs</param>
        protected virtual void OnMaximize(EventArgs e)
        {
            if (this.Maximize != null)
            {
                this.Maximize(this, e);
            }
        }

        /// <summary>
        /// Minimizeイベントを発生させる
        /// </summary>
        /// <param name="e">イベントデータを格納しているEventArgs</param>
        protected virtual void OnMinimize(EventArgs e)
        {
            if (this.Minimize != null)
            {
                this.Minimize(this, e);
            }
        }

        /// <summary>
        /// Restoreイベントを発生させる
        /// </summary>
        /// <param name="e">イベントデータを格納しているEventArgs</param>
        protected virtual void OnRestore(EventArgs e)
        {
            if (this.Restore != null)
            {
                this.Restore(this, e);
            }
        }
    }
}
