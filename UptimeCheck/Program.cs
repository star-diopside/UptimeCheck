using System;
using System.Windows.Forms;
using UptimeCheck.Forms;

namespace UptimeCheck
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ToolStripManager.VisualStylesEnabled = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UptimeCheckForm());
        }
    }
}
