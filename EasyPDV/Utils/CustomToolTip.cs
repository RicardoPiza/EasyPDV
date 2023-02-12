using System.Drawing;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;

namespace EasyPDV.Utils {
    public class CustomToolTip : Control {
        private string _toolTipText;
        private Size _toolTipSize;

        public CustomToolTip() {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(100, 50);
        }

        public string ToolTipText {
            get { return _toolTipText; }
            set { _toolTipText = value; Invalidate(); }
        }

        public Size ToolTipSize {
            get { return _toolTipSize; }
            set { _toolTipSize = value; Size = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.DrawString(ToolTipText, Font, new SolidBrush(ForeColor), 0, 0);
        }
    }
}
