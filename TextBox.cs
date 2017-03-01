using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
    class TextBox : UIElement
    {
        private int X;
        private int Y;
        private int Width;
        private int Height;

        public TextBox(int PosX, int PosY, int TextBoxWidth, int TextBoxHeight)
        {
            X = PosX;
            Y = PosX;
            Width = TextBoxWidth;
            Height = TextBoxHeight;

            DrawBorder();
        }
    }
}
