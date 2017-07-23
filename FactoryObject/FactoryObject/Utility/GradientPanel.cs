using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace FactoryObject.Utility
{
    public partial class GradientPanel : Panel
    {
        private Color _FirstColor;
        private Color _SecondColor;
        private LinearGradientMode _Mode;
        [Description("First Gradient Color"), Category("Data")]
        public Color FirstColor
        {
            get { return _FirstColor; }
            set { this._FirstColor = value; }
        }

        [Description("Second Gradient Color"), Category("Data")]
        public Color SecondColor
        {
            get { return _SecondColor; }
            set { _SecondColor = value; }
        }

        [Description("Gradient Mode"), Category("Data")]
        public LinearGradientMode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        public GradientPanel()
        {
            this.ResizeRedraw = true;
        
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rct = this.ClientRectangle;
            if (rct.Width == 0) { rct = new Rectangle(this.ClientRectangle.X+1, this.ClientRectangle.Y+1, this.ClientRectangle.Width + 10, this.ClientRectangle.Height + 10); }
            using (var brush = new LinearGradientBrush(this.ClientRectangle,
                       _FirstColor, _SecondColor, Mode))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
            base.OnScroll(se);
        }
    }
}
