using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
    class Pane : UIElement
    {       
        private TextList FileList;
        private TextBox CurrentLocation;

        public Pane(int PosX, int PosY, int PaneWidth, int PaneHeight) : base(PosX, PosY, PaneWidth, PaneHeight)
        {
            DrawBorder();

            CurrentLocation = new TextBox(base.X, base.Y + PaneHeight - 1, PaneWidth, 1);
            CurrentLocation.DrawBorder(true, false, false, false);
        }
    }
}
