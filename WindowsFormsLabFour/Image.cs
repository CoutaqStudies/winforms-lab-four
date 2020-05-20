using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLabFour
{
    class ImageWithName
    {
        private Image image;

        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap Bitmap { get; set; }
        public Image Image { get; set; }
        public bool Copyrighted { get; set; }
    public ImageWithName()
        {

        }
        public ImageWithName(string name, int width, int height, Bitmap bitmap, bool copyrighted)
        {
            Name = name;
            Width = width;
            Height = height;
            Bitmap = bitmap;
            Copyrighted = copyrighted;
        }
        public ImageWithName(string name, Image image)
        {
            Name = name;
            Image = image;
        }
    }
    
}
