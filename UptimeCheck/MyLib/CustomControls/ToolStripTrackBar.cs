using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace UptimeCheck.MyLib.CustomControls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripTrackBar : ToolStripControlHost
    {
        public ToolStripTrackBar() : base(new TrackBar())
        {
        }

        /// <summary>
        /// ホストしているTrackBarコントロール
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TrackBar TrackBar => (TrackBar)Control;

        /// <summary>
        /// TrackBarコントロールのValueプロパティ変更イベント
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// ホストされるコントロールからイベントをサブスクライブする
        /// </summary>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            ((TrackBar)control).ValueChanged += TrackBarValueChangedEvent;
        }

        /// <summary>
        /// ホストされるコントロールからのイベントをアンサブスクライブする
        /// </summary>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            ((TrackBar)control).ValueChanged -= TrackBarValueChangedEvent;
        }

        /// <summary>
        /// ホストされたTrackBarのValueChangedイベントを処理する
        /// </summary>
        private void TrackBarValueChangedEvent(object sender, EventArgs e) => ValueChanged?.Invoke(this, e);
    }
}
