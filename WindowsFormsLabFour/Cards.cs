using Medallion;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLabFour
{
    public partial class Cards : Form
    {
        private Point MouseDownLocation;
        bool[] FaceUp = new bool[36];
        string[] CardValue ={ "🂡","🂦","🂧","🂨","🂩","🂪","🂫","🂬","🂭","🂮",
"🂱","🂶","🂷","🂸","🂹","🂺","🂻","🂼","🂽","🂾",
"🃁","🃆","🃇","🃈","🃉","🃊","🃋","🃌","🃍","🃎",
"🃑","🃖","🃗","🃘","🃙","🃚","🃛","🃜","🃝","🃞"
};
        String suit = "🂠";
        NoPaddingLabel[] Labels = new NoPaddingLabel[36];
        Panel[] panels = new Panel[36];
        public Cards()
        {
            InitializeComponent();
            DoubleBuffered = true;
            LoadCards();
            this.DoubleBuffered = true;
        }
        private void Cards_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.LimeGreen,
                                                               Color.DarkGreen,
                                                               45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void LoadCards()
        {
            for(int i = 0; i < FaceUp.Length; i++)
            {
                FaceUp[i] = false;
            }
            for (int i = 0; i < panels.Length; i++)
            {
                
                var lbl = new Panel();
                panels[i] = lbl;
                lbl.Name = i.ToString();
                lbl.Location = new Point(172, 100);
                lbl.Visible = true;
                lbl.Padding = new Padding(0);
                lbl.Margin = new Padding(0);
                lbl.BackColor = Color.White;
                lbl.Size = GetTextSize();
                lbl.MouseDown += new MouseEventHandler(this.MouseDown);
                lbl.MouseMove += new MouseEventHandler(this.MouseMove);
                lbl.MouseUp += new MouseEventHandler(this.MouseClick);
                lbl.Paint += new PaintEventHandler(panel_Paint);
              
            }
            panels.Shuffle();
            foreach (Panel l in panels)
            {
                this.Controls.Add(l);
                this.Refresh();
            }
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            int num = int.Parse(p.Name);
            var g = e.Graphics;
            Font fy = new Font("Microsoft Sans Serif", 100);
           
            TextRenderer.DrawText(g, FaceUp[num]?CardValue[num]: suit, fy, new Point(0, 0), (num > 9 && num < 28 && FaceUp[num])?Color.Red:Color.Black, TextFormatFlags.NoPadding| TextFormatFlags.NoPrefix);
            e.Graphics.TranslateTransform(100.0F, 0.0F);
            e.Graphics.RotateTransform(30.0F, MatrixOrder.Append);
        }
        private void LoadPanels()
        {
            for (int i = 0; i < FaceUp.Length; i++)
            {
                FaceUp[i] = false;
            }
            for (int i = 0; i < Labels.Length; i++)
            {

                var lbl = new NoPaddingLabel();
                Labels[i] = lbl;
                lbl.Text = suit;
                lbl.Name = i.ToString();
                lbl.Location = new Point(172, 100);
                lbl.Font = new Font("Microsoft Sans Serif", 100);
                lbl.ForeColor = Color.Black;
                lbl.AutoSize = true;
                lbl.Visible = true;
                lbl.RotateAngle = 45;
                lbl.Padding = new Padding(0);
                lbl.Margin = new Padding(0);
                lbl.FlatStyle = FlatStyle.System;
                lbl.TextAlign = ContentAlignment.TopCenter;
                lbl.MouseDown += new MouseEventHandler(this.MouseDown);
                lbl.MouseMove += new MouseEventHandler(this.MouseMove);
                lbl.MouseUp += new MouseEventHandler(this.MouseClick);
            }
            Labels.Shuffle();
            foreach (Label l in Labels)
            {
                this.Controls.Add(l);
                this.Refresh();
            }
        }
        private void MouseClick(object sender, MouseEventArgs e)
        {
            Panel lbl = sender as Panel;
            int num = int.Parse(lbl.Name);
            if (FaceUp[num])
            {
                FaceUp[num] = false;
            }
            else
            {
                FaceUp[num] = true;
            }
            lbl.Refresh();

        }
        private void MouseDown(object sender, MouseEventArgs e)
        {  
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                MouseDownLocation = e.Location;
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            Panel lbl = sender as Panel;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                lbl.Left = e.X + lbl.Left - MouseDownLocation.X;
                lbl.Top = e.Y + lbl.Top - MouseDownLocation.Y;
            }
        }
        private void Cards_Resize(object sender, EventArgs e)
        {

            this.Invalidate();
        }

        public void Cards_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.F2)
            {
                this.Controls.Clear();
                LoadCards();
            }
        }

        private void GenerateTexture(float rotation)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;

            Bitmap img = new Bitmap(this.Height, this.Width);
            Graphics G = Graphics.FromImage(img);

            G.Clear(this.BackColor);

            SolidBrush brush_text = new SolidBrush(this.ForeColor);
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            G.DrawString(this.Name, this.Font, brush_text, new Rectangle(0, 0, img.Width, img.Height), format);
            brush_text.Dispose();


            this.BackgroundImage = RotateImage(img, rotation);
        }
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
        private Size GetTextSize()
        {
            Size textSize = TextRenderer.MeasureText("🂡", new Font("Microsoft Sans Serif", 100));
            return new Size(textSize.Width-65, textSize.Height);
        }
    }
}
