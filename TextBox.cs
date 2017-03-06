using System;
using System.ComponentModel;

namespace mc
{
    public delegate void TextBoxReturnKeyEventHandler(object sender, TextBoxReturnKeyEventArgs e);

    public class TextBoxReturnKeyEventArgs : EventArgs
    {
        public string Text { get; }
        public TextBoxReturnKeyEventArgs(string t) { Text = t; }        
    }
    class TextBox : UIElement
    {
        class BorderCorner
        {
            public bool North;
            public bool South;
            public bool East;
            public bool West;

            public char UnicodeChar;
        }

        public string Text { get; set; }
        public delegate void TextBoxReturnKeyPressed(object sender, TextBoxReturnKeyEventArgs e);
        public event TextBoxReturnKeyPressed OnReturnKeyPressed;

        public TextBox(int PosX, int PosY, int TextBoxWidth, int TextBoxHeight) : base(PosX, PosY, TextBoxWidth, TextBoxHeight)
        {
            DrawBorder();
            Text = string.Empty;
            CurrentCursorPosition = 0;
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
                CurrentCursorPosition = Text.Length;
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
            CurrentCursorPosition = Text.Length - (Text.Length % Width);
            ScrollRight(Text.Length - Width - 1);
            Console.SetCursorPosition(X + Width, Y + 1);
            CurrentCursorPosition = Text.Length;
        }
        public override void MoveCursorToBegin()
        {
            ScrollLeft(CurrentCursorPosition);
            Console.SetCursorPosition(X + 1, Y + 1);
            CurrentCursorPosition = 0;
        }
        public override void MoveCursorToPreferred() { MoveCursorToBegin(); }
        public override void MoveCursorUp()
        {
            int CurrentY = Console.CursorTop;
            if (Height > 2 && ((CurrentY - Y) > 0))
            {
                Console.CursorTop -= 1;
               CurrentCursorPosition -= Width - 2;
            }
        }
        public override void MoveCursorDown()
        {
            int CurrentY = Console.CursorTop;
            if (Height > 2 && ((CurrentY - Y) < Height))
            {
                Console.CursorTop += 1;
                CurrentCursorPosition += Width - 2;
            }
        }
        public override void MoveCursorLeft()
        {
            int CurrentX = Console.CursorLeft - X - 1;
            //Not at the beginning of the box, or the string
            if ((CurrentX > 0) &&
                (CurrentCursorPosition > 0))
            {
                Console.CursorLeft -= 1;
                CurrentCursorPosition -= 1;
            }
            //At the beginning of the box, not at the beginning of the string
            else if ((CurrentX == 0) &&
                    (CurrentCursorPosition > 0))
            {
                ScrollLeft(1);
                Console.CursorLeft = X + 1;
                CurrentCursorPosition -= 1;
            }
            //At the beginning of the box and the string
            else if (CurrentX == 0 &&
                     CurrentCursorPosition == 0)
            {
                // Do nothing, we're at the beginning of the string and the box.
                // I like having this as an explicit condition.
            }
        }
        public override void MoveCursorRight()
        {
            int CurrentX = Console.CursorLeft - X - 1;
            //Not at the end of the width, not at the end of the string
            if ((CurrentX < (Width - 2)) &&
                (CurrentCursorPosition < Text.Length))
            {
                Console.CursorLeft += 1;
                CurrentCursorPosition += 1;
            }
            // At the end of the width, not at the end of the string
            else if ((CurrentX >= (Width - 2)) &&
                    (CurrentCursorPosition < (Text.Length - 1)))
            {
                ScrollRight(1);
                Console.CursorLeft -= 1;
                CurrentCursorPosition += 1;
            }
            else if ((CurrentX >= (Width - 2)) &&
                  (CurrentCursorPosition == Text.Length - 1))
            {
                // Do nothing, we're at the end of the string and the box.
                // I like having this as an explicit condition.
            }
        }

        private void ScrollRight(int CharsToScroll)
        {
            Console.SetCursorPosition(X + 1, Y + 1);
            int NewBeginCharLocation = CurrentCursorPosition + CharsToScroll - Width + 2;
            if (NewBeginCharLocation < 0)
                return;
            if ((Width + NewBeginCharLocation - 2) < Text.Length)
            {
                Console.Write(Text.Substring(NewBeginCharLocation, Width - 1));
            }
        }

        private void ScrollLeft(int CharsToScroll)
        {
            Console.SetCursorPosition(X + 1, Y + 1);
            CurrentCursorPosition = X + 1;
            int NewBeginCharLocation = CurrentCursorPosition - 1;
            if (NewBeginCharLocation >= 0)
            {
                Console.Write(Text.Substring(NewBeginCharLocation, Width - 1));
            }
        }

        public override void MiscKeyPressed(ConsoleKeyInfo ReadKey)
        {
            if (ReadKey.Key == ConsoleKey.Enter && OnReturnKeyPressed != null)
            {
                OnReturnKeyPressed(this, new TextBoxReturnKeyEventArgs(Text));
            }
            else if (ReadKey.Key == ConsoleKey.Home)
            {
                MoveCursorToBegin();
            }
            else if(ReadKey.Key == ConsoleKey.End)
            {
                MoveCursorToEnd();
            } 
        }
        public override void PrintableKeyPressed(ConsoleKeyInfo ReadKey)
        {

        } 
    }
}
