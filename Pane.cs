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
        private const int CurrentLocationHeight = 2;

        public Pane(int PosX, int PosY, int PaneWidth, int PaneHeight) : base(PosX, PosY, PaneWidth, PaneHeight)
        {
            DrawBorder();

            CurrentLocation = new TextBox(base.X, base.Y + PaneHeight - CurrentLocationHeight, PaneWidth, CurrentLocationHeight);
            CurrentLocation.DrawBorder(true, false, false, false);
        }

        public void SetCurrentLocation(string NewLocation)
        {
            CurrentLocation.Text = NewLocation;
        }

        public override void DrawContents()
        {
            CurrentLocation.DrawContents();
        }
    }
}
