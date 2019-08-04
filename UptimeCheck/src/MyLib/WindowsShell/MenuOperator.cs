using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyLib.WindowsShell
{
    /// <summary>
    /// システムメニュー操作用クラス
    /// </summary>
    public static class SystemMenuOperator
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        // Constants used for menu position
        private const uint SC_MOVE = 0xF010;

        // Constants used for flags
        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_BYPOSITION = 0x00000400;

        // Constants used for EnableMenuItem
        private const uint MF_ENABLED = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;
        private const uint MF_DISABLED = 0x00000002;

        /// <summary>
        /// システムメニューの「移動」の表示を設定する
        /// </summary>
        public static void SetMoveMenuEnabled(IWin32Window owner, bool enable)
        {
            HandleRef windowHandle = new HandleRef(owner, owner.Handle);

            // システムメニューを取得する
            IntPtr sysMenu = GetSystemMenu(HandleRef.ToIntPtr(windowHandle), false);

            // システムメニューの「移動」の表示を設定する
            uint enableValue;

            if (enable)
            {
                enableValue = MF_ENABLED;
            }
            else
            {
                enableValue = MF_DISABLED | MF_GRAYED;
            }

            EnableMenuItem(sysMenu, SC_MOVE, MF_BYCOMMAND | enableValue);

            // システムメニューを再描画する
            DrawMenuBar(sysMenu);
        }
    }
}
