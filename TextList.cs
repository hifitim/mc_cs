using System.Collections.Generic;
using System;

namespace mc
{
    class TextList : UIElement
    {
        public List<string> TheList { get; set; }

        public TextList(int PosX, int PosY, int Width, int Height) : base(PosX, PosY, Width, Height)
        {
            TheList = new List<string>();
        }
        public TextList(int PosX, int PosY, int Width, int Height, List<string> ListOfFiles) : base(PosX, PosY, Width, Height)
        {
            TheList = new List<string>(ListOfFiles);
        }

        private void ClearContents()
        {
            string ClearString = string.Empty;
            for (int col = 0; col < Width; col++)
                ClearString += ' ';
            for (int row = 0; row < (Height + Y); row++)
            {
                Console.SetCursorPosition(X, Y + row + 1);
                Console.Write(ClearString);
            }
        }
        public override void DrawContents()
        {
            ClearContents();
            Console.SetCursorPosition(X + 1, Y + 1);
            int CurrentRow = 0;
            foreach (string FullFilePath in TheList)
            {
                Console.SetCursorPosition(X + 1, Y + 1 + CurrentRow);

                string FileName = FullFilePath.Substring(FullFilePath.LastIndexOf(@"/") + 1);
                if (FileName.Length < Width)
                {
                    Console.Write(FileName);
                }
                else
                {
                    int CurrentPosition = 0;

                    Console.Write(FileName.Substring(CurrentPosition, (Width - 1)));
                    CurrentPosition += Width - 1;
                }
                if (++CurrentRow > Height)
                {
                    break;
                }
            }
        }
        public override void MoveCursorToEnd() { }
        public override void MoveCursorToBegin()
        {
            Console.SetCursorPosition(X + 1, Y + 1);
        }
        public override void MoveCursorToPreferred() { MoveCursorToBegin(); }
        public override void MoveCursorUp() { }
        public override void MoveCursorDown() { }
        public override void MoveCursorLeft() { }
        public override void MoveCursorRight() { }
        public override void MiscKeyPressed(ConsoleKeyInfo ReadKey) { }
        public override void PrintableKeyPressed(ConsoleKeyInfo ReadKey) { }
    }
}