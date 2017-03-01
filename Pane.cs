using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
    class Pane : UIElement
    {
        private int X;
        private int Y;
        private int Width;
        private int Height;
        private TextList FileList;
        private TextBox CurrentLocation;

        public Pane(int PosX, int PosY, int PaneWidth, int PaneHeight)
        {
            X = PosX;
            Y = PosY;
            Width = PaneWidth;
            Height = PaneHeight;
            DrawBorder();
        }
    }
}
