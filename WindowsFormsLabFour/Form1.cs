using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLabFour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.tableLayoutPanel1.Paint += tlp_Paint;
        }
        void tlp_Paint(object sender, PaintEventArgs e)
        {
            var tlp = tableLayoutPanel1;
            int[] rowHeights = tlp.GetRowHeights();
            int[] colmWidths = tlp.GetColumnWidths();

            int boxLeft = 0;
            int boxTop = 0;
            int boxRight = 0;
            int boxBottom = 0;

            Rectangle r = Rectangle.Empty;
            for (int y = 0; y < rowHeights.Length; ++y)
            {
                boxLeft = 0;
                boxRight = 0;
                boxBottom += rowHeights[y];
                for (int x = 0; x < colmWidths.Length; ++x)
                {
                    boxRight += colmWidths[x];
                    if (x == 0 && y == 0)
                    {
                        r.X = boxLeft;
                        r.Y = boxTop;
                    }
                    if (x == rowHeights.Length-1 && y == colmWidths.Length-1)
                    {
                        r.Width = boxRight - r.Left;
                        r.Height = boxBottom - r.Top;
                    }
                    boxLeft += colmWidths[x];
                }
                boxTop += rowHeights[y];
            }
            if (!r.IsEmpty)
            {
                e.Graphics.TranslateTransform(tlp.AutoScrollPosition.X,
                                              tlp.AutoScrollPosition.Y);
                using (var br = new LinearGradientBrush(
                                      r,
                                      Color.FromArgb(255, 38, 117),
                                      Color.FromArgb(255, 44, 88),

                                      LinearGradientMode.ForwardDiagonal))
                {
                    e.Graphics.FillRectangle(br, r);
                }
            }
        }

        private void buttonCopyrighter_Click(object sender, EventArgs e)
        {
            var frm = new Copyrighter();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        private void buttonCards_Click(object sender, EventArgs e)
        {
            var frm = new Cards();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }
    }
}
