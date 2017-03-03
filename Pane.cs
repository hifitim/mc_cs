namespace mc
{
    class Pane : UIElement
    {


        public Pane(int PosX, int PosY, int PaneWidth, int PaneHeight, string Location) : base(PosX, PosY, PaneWidth, PaneHeight)
        {
            DrawBorder();
        }

        public override void DrawContents() { }
        public override void MoveCursorToEnd() { }
        public override void MoveCursorToBegin() { }
        public override void MoveCursorToPreferred() { }
    }
}
