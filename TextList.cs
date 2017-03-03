using System.Collections.Generic;
using System;

namespace mc
{
    class TextList : UIElement
    {
        public List<string> TheList { get; }

        public TextList(int PosX, int PosY, int Width, int Height) : base(PosX, PosY, Width, Height)
        {
            TheList = new List<string>();
        }
        public TextList(int PosX, int PosY, int Width, int Height, List<string> ListOfFiles) : base(PosX, PosY, Width, Height)
        {
            TheList = new List<string>(ListOfFiles);
        }

        public override void DrawContents()
        {
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
    }
}