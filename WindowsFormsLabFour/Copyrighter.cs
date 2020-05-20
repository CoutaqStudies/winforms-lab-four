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
    public partial class Copyrighter : Form
    {
        String copyright =  "(c) "+ Environment.UserName;
        Bitmap panelBitmap;
        List<ImageWithName> images = new List<ImageWithName>();
        List<DataGridViewItem> data = new List<DataGridViewItem>();
        ImageWithName selectedImage;
        int selectedPos;
        String path = String.Empty;
        bool overridePath = true;
        Font font = new Font("Comic Sans MS", 60);
        public Copyrighter()
        {
            InitializeComponent();
            toolStrip1.Renderer = new FluentDesignRenderer();
            
        }
        #region Style
        public class FluentDesignRenderer : ToolStripProfessionalRenderer
        {
            public FluentDesignRenderer()
                : base(new MyColorTable())
            {
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
                r.Inflate(-4, -6);
                e.Graphics.DrawLines(Pens.Black, new Point[]{
        new Point(r.Left, r.Bottom - r.Height /2),
        new Point(r.Left + r.Width /3,  r.Bottom),
        new Point(r.Right, r.Top)});
            }
        }
        public class MyColorTable : ProfessionalColorTable
        {
            public new bool UseSystemColors = true;
            /*public override Color MenuItem
            {
                get { return Color.White; }
            }*/
            public override Color StatusStripGradientBegin
            {
                get { return Color.White; }
            }
            public override Color StatusStripGradientEnd
            {
                get { return Color.White; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ButtonSelectedBorder
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ButtonSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ButtonSelectedGradientEnd
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.White; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color MenuItemSelected
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.White; }
            }
            public override Color ToolStripGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ToolStripGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ToolStripGradientEnd
            {
                get { return Color.White; }
            }
            public override Color ToolStripBorder
            {
                get { return Color.WhiteSmoke; }
            }
        }
        #endregion
        public void OpenDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = false;
                if (overridePath)
                    path = fbd.SelectedPath;
                int i = 0;
                foreach (string imageFile in Directory.EnumerateFiles(path))
                {
                    try
                    {
                        Bitmap img = new Bitmap(imageFile);
                        i++;
                    }
                    catch (Exception ex)
                    {
                    }
                }

                //panelBitmap = new Bitmap(panel1.Width, 90 * i + 15);
                panel1.AutoScrollMinSize = new Size(0, 90 * i + 15);
                i = 0;
                foreach (string imageFile in Directory.EnumerateFiles(fbd.SelectedPath))
                {
                    try
                    {
                        if(i==0)
                            images.Clear();
                        Bitmap image = new Bitmap(imageFile);
                        FileInfo info = new FileInfo(imageFile);
                        images.Add(new ImageWithName(info.Name, image.Width, image.Height, image, false));  
                        i++;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                DrawImageArray(images.ToArray());
                this.Enabled = true;
            }
        }

        public void SelectText(object sender, EventArgs e)
        {
      
            if (InputBox.Show("Test Input Box",
                "&Enter a new copyright value:", ref copyright) == DialogResult.OK)
            {
            }
        }
        public void SelectDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                overridePath = false;
            }
        }
        void DrawImageArray(ImageWithName[] images)
        {
            int i = 0;
            panelBitmap = new Bitmap(panel1.Width, 90 * images.Length + 15);
            panel1.Refresh();
            foreach (ImageWithName image in images)
            {
                Graphics dc = Graphics.FromImage(panelBitmap);
                dc.DrawImage(image.Bitmap, 10, 90 * i + 15, 90, 90);
                i++;
            }
            panel1.Refresh();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Transform = new Matrix(1, 0, 0, 1, panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
            if(panelBitmap != null)
            {
               e.Graphics.DrawImage(panelBitmap, 0, 0);
            }
        }
        private void panel1_Click(object sender, MouseEventArgs e)
        {
            int realY = e.Y - panel1.AutoScrollPosition.Y;
            try
            {
                pictureBox1.Image = images[(realY - 15) / 90].Bitmap;
                selectedImage = images[(realY - 15) / 90];
                selectedPos = realY;
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "image files(*.PNG;*.JPG;*.TIFF;*.PSD;*.BMP)|*.PNG;*.JPG;*.TIFF;*.PSD;*.BMP";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(overridePath)
                 path = openFileDialog1.FileName.Replace(openFileDialog1.SafeFileName, "");
                Bitmap image = new Bitmap(openFileDialog1.FileName);
                FileInfo info = new FileInfo(openFileDialog1.FileName);
                images.Clear();
                images.Add(new ImageWithName(info.Name, image.Width, image.Height, image, false));
                DrawImageArray(images.ToArray());
                selectedImage = images[0];
                pictureBox1.Image = image;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void SelectFont(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;
            }
            if(font.Size< 20)
            {
                font = new Font(font.FontFamily, 20);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            addCopyright(pictureBox1.Image);
            pictureBox1.Refresh();
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            DataGridViewItem item = new DataGridViewItem(selectedImage.Name, selectedImage.Width.ToString(), selectedImage.Height.ToString(), copyright + " [" + currentTime.Hours +":"+currentTime.Minutes+"]");
            if (!selectedImage.Copyrighted)
            {
                data.Add(item);
                fillGrid();
                try
                {
                    Graphics gr = Graphics.FromImage(panelBitmap);
                    var bmp = new Bitmap(Properties.Resources.StatusOK);
                    gr.DrawImage(bmp, 15, selectedPos, 30, 30);
                    panel1.Refresh();
                }
                catch (Exception ex)
                {
                }
            }          
            selectedImage.Copyrighted = true;
        }
        public void addCopyright(Image image)
        {
            Graphics g = Graphics.FromImage(image);
            g.DrawString(copyright, font, new SolidBrush(Color.Red), image.Width / 50, image.Height / 2);
        }
        public Image copyrightedImage(Image image)
        {
            pictureBox1.Image = image;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.DrawString(copyright, font, new SolidBrush(Color.Red), image.Width / 50, image.Height / 2);
            return (pictureBox1.Image);
        }

        public void fillGrid()
        {
            int i = 0;
            dataGridView1.RowCount = data.Count;
            foreach(var item in data)
            {
                var cells = dataGridView1.Rows[i].Cells;
                cells[0].Value = item.File;
                cells[1].Value = item.Width;
                cells[2].Value = item.Height;
                cells[3].Value = item.Text;
                i++;
            }
        }
        public void DeleteSelectedImage()
        {
            images.Remove(selectedImage);
            DrawImageArray(images.ToArray());
        }
        public void Copyrighter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (panelBitmap != null)
                {
                    DeleteSelectedImage();
                    pictureBox1.Image = null;
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog {
                DefaultExt = ".PNG",
                Filter = "image files(*.PNG;*.JPG;*.TIFF;*.PSD;*.BMP)|*.PNG;*.JPG;*.TIFF;*.PSD;*.BMP",
                FileName = selectedImage.Name+"(C)"
            };
            if (save.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(save.FileName);
        }
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            List<ImageWithName> copyrightedImages = new List<ImageWithName>();
            this.Enabled = false;
            foreach(var image in images)
            {
                copyrightedImages.Add(new ImageWithName(image.Name, copyrightedImage(image.Bitmap)));
            }
            
            foreach (var image in copyrightedImages)
            {
                string namePath = path + "\\" + image.Name.Insert(image.Name.LastIndexOf('.'), "(C)");
                try
                {
                    image.Image.Save(namePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {

                }
            }
            this.Enabled = true;
            MessageBox.Show("Succesfully saved all images to "+path);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Michael Melikov \n (c) 2020");
        }
    }
}
