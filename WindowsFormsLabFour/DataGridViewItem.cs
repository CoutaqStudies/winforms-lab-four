using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLabFour
{
    class DataGridViewItem
    {
        public string File { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Text { get; set; }

        public DataGridViewItem()
        {
        }

        public DataGridViewItem(string file, string width, string height, string text)
        {
            File = file;
            Width = width;
            Height = height;
            Text = text;
        }
    }
}
