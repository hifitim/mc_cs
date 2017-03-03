using System.IO;
using System.Collections.Generic;

namespace mc
{
    class Pane : UIElement
    {
        private TextList FileList;
        private TextBox CurrentLocation;
        private const int CurrentLocationHeight = 2;

        public Pane(int PosX, int PosY, int PaneWidth, int PaneHeight, string Location) : base(PosX, PosY, PaneWidth, PaneHeight)
        {
            DrawBorder();

            FileList = new TextList(PosX + 1, PosY + 1, PaneWidth - 1, PaneHeight - 2, new List<string>(Directory.GetFiles(Location)));
            FileList.DrawContents();
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
