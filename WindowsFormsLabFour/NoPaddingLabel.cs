using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLabFour
{
   
    public partial class NoPaddingLabel : Label
    {
        private TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.NoPadding | TextFormatFlags.GlyphOverhangPadding| TextFormatFlags.HorizontalCenter | TextFormatFlags.Top;
        public int RotateAngle { get; set; }  // to rotate your text
        public string NewText { get; set; }   // to draw text

        public bool RightAlignment
        {
            get
            {
                return (flags & TextFormatFlags.Right) == TextFormatFlags.Right;
            }
            set
            {
                if (value)
                {
                    flags = flags |= TextFormatFlags.Right;
                }
                else
                {
                    flags = flags &= ~TextFormatFlags.Right;
                }
                Invalidate();
            }
        }


        public NoPaddingLabel()
        {
           // InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush b = new SolidBrush(this.ForeColor);
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, this.Font, b, 0f, 0f);
            base.OnPaint(e);
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, Color.Transparent, flags);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.AutoSize = false;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.Size = GetTextSize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = GetTextSize();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Size = GetTextSize();
        }

        private Size GetTextSize()
        {
            Size padSize = TextRenderer.MeasureText("🂡", this.Font);
            Size textSize = TextRenderer.MeasureText(this.Text + "🂡", this.Font);
            return new Size(textSize.Width - padSize.Width, textSize.Height);
        }
    }
}