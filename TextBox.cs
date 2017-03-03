using System;
using System.ComponentModel;

namespace mc
{
    class TextBox : UIElement, INotifyPropertyChanged
    {
        class BorderCorner
        {
            public bool North;
            public bool South;
            public bool East;
            public bool West;

            public char UnicodeChar;
        }

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TextBox(int PosX, int PosY, int TextBoxWidth, int TextBoxHeight) : base(PosX, PosY, TextBoxWidth, TextBoxHeight)
        {
            DrawBorder();
            Text = string.Empty;
        }

        protected void OnPropertyChanged(string PropertyName)
        {
            int a = 7;
            int b = a++;
        }

        public void DrawBorder(bool ExtendUp, bool ExtendDown, bool ExtendLeft, bool ExtendRight)
        {
            Console.SetCursorPosition(X, Y);

            //Draw the outline top and bottom
            for (int k = X; k < (Width + X); k++)
            {
                Console.SetCursorPosition(k, Y);
                System.Console.Write('\u2500');

                Console.SetCursorPosition(k, Y + Height);
                System.Console.Write('\u2500');
            }

            //Draw the outline left and right
            for (int k = Y; k < (Height + Y); k++)
            {
                Console.SetCursorPosition(X, k);
                System.Console.Write('\u2502');

                Console.SetCursorPosition(X + Width, k);
                System.Console.Write('\u2502');
            }

            BorderCorner TopLeft = new BorderCorner(),
                         TopRight = new BorderCorner(),
                         BottomLeft = new BorderCorner(),
                         BottomRight = new BorderCorner();
            TopLeft.East = true;
            TopLeft.South = true;
            TopLeft.UnicodeChar = '\u250C';

            TopRight.West = true;
            TopRight.South = true;
            TopRight.UnicodeChar = '\u2510';

            BottomLeft.North = true;
            BottomLeft.East = true;
            BottomLeft.UnicodeChar = '\u2514';

            BottomRight.West = true;
            BottomRight.North = true;
            BottomRight.UnicodeChar = '\u2518';

            if (ExtendUp)
            {
                TopLeft.North = true;
                TopRight.North = true;
            }

            if (ExtendDown)
            {
                BottomRight.South = true;
                BottomLeft.South = true;
            }

            if (ExtendLeft)
            {
                TopLeft.West = true;
                BottomLeft.West = true;
            }

            if (ExtendRight)
            {
                TopRight.East = true;
                BottomRight.East = true;
            }

            /**
             * \u251C - ├
             *
             * \u252C - ┬
             *
             * \u2524 - ┤
             *
             * \u2434 - ┴
             *
             * \u253C - ┼
             **/

            TopLeft.UnicodeChar = (TopLeft.North) ? '\u251C' : TopLeft.UnicodeChar;
            TopLeft.UnicodeChar = (TopLeft.West) ? '\u252C' : TopLeft.UnicodeChar;
            TopLeft.UnicodeChar = (TopLeft.North && TopLeft.West) ? '\u253C' : TopLeft.UnicodeChar;

            TopRight.UnicodeChar = (TopRight.North) ? '\u2524' : TopRight.UnicodeChar;
            TopRight.UnicodeChar = (TopRight.East) ? '\u252C' : TopRight.UnicodeChar;
            TopRight.UnicodeChar = (TopRight.North && TopRight.East) ? '\u253C' : TopRight.UnicodeChar;

            BottomLeft.UnicodeChar = (BottomLeft.South) ? '\u251C' : BottomLeft.UnicodeChar;
            BottomLeft.UnicodeChar = (BottomLeft.West) ? '\u2534' : BottomLeft.UnicodeChar;
            BottomLeft.UnicodeChar = (BottomLeft.South && BottomLeft.West) ? '\u253C' : BottomLeft.UnicodeChar;

            BottomRight.UnicodeChar = (BottomRight.South) ? '\u2524' : BottomRight.UnicodeChar;
            BottomRight.UnicodeChar = (BottomRight.East) ? '\u2534' : BottomRight.UnicodeChar;
            BottomRight.UnicodeChar = (BottomRight.South && BottomRight.East) ? '\u253C' : BottomRight.UnicodeChar;

            //Replace the corners
            //Top left
            Console.SetCursorPosition(X, Y);
            System.Console.Write(TopLeft.UnicodeChar);
            //Bottom right
            Console.SetCursorPosition(X + Width, Y + Height);
            System.Console.Write(BottomRight.UnicodeChar);
            //Top right
            Console.SetCursorPosition(X + Width, Y);
            System.Console.Write(TopRight.UnicodeChar);
            //Bottom left
            Console.SetCursorPosition(X, Y + Height);
            System.Console.Write(BottomLeft.UnicodeChar);
        }

        public override void DrawContents()
        {
            Console.SetCursorPosition(X + 1, Y + 1);
            if (Text.Length < Width)
            {
                Console.Write(Text);
            }
            else
            {
                int CurrentPosition = 0;
                int CurrentRow = 0;

                do
                {
                    Console.Write(Text.Substring(CurrentPosition, (Width - 1)));
                    CurrentPosition += Width - 1;
                } while (++CurrentRow < (Height - 1));
            }
        }

        public override void MoveCursorToEnd()
        {
            if (Text.Length > (Width - 1))
            {
                Console.SetCursorPosition(X + Width - 1, Y + 1);
            } else
            {
                Console.SetCursorPosition(X + Text.Length, Y + 1);
            }
        }
        public override void MoveCursorToBegin() { }
        public override void MoveCursorToPreferred() { MoveCursorToEnd(); }
        public override void MoveCursorUp()
        {
            int CurrentY = Console.CursorTop;
            if (Height > 2 && ((CurrentY - Y) > 0))
            {
                Console.CursorTop -= 1;
            }
        }
        public override void MoveCursorDown()
        {
            int CurrentY = Console.CursorTop;
            if (Height > 2 && ((CurrentY - Y) < Height))
            {
                Console.CursorTop += 1;
            }
        }
        public override void MoveCursorLeft()
        {
            int CurrentX = Console.CursorLeft;
            if (CurrentX > 0 && ((CurrentX - X) > 0))
            {
                Console.CursorLeft -= 1;
            }
        }
        public override void MoveCursorRight()
        {
            int CurrentX = Console.CursorLeft;
            // + 1 so that you can type at the end of the string
            if ((CurrentX < (Text.Length + X + 1)) &&
                (CurrentX < (Width + X)))
            {
                Console.CursorLeft += 1;
            }
        }
    }
}
