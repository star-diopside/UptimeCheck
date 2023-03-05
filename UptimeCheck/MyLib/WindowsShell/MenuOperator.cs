using System.Runtime.InteropServices;

namespace UptimeCheck.MyLib.WindowsShell;

/// <summary>
/// システムメニュー操作用クラス
/// </summary>
public static partial class SystemMenuOperator
{
    [LibraryImport("user32.dll")]
    private static partial IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

    [LibraryImport("user32.dll")]
    private static partial int EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool DrawMenuBar(IntPtr hWnd);

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
        // システムメニューを取得する
        IntPtr sysMenu = GetSystemMenu(owner.Handle, false);

        // システムメニューの「移動」の表示を設定する
        EnableMenuItem(sysMenu, SC_MOVE, MF_BYCOMMAND | (enable ? MF_ENABLED : MF_DISABLED | MF_GRAYED));

        // システムメニューを再描画する
        DrawMenuBar(sysMenu);
    }
}
