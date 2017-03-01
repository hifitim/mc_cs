using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
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

        public TextBox(int PosX, int PosY, int TextBoxWidth, int TextBoxHeight) : base(PosX, PosY, TextBoxWidth, TextBoxHeight)
        {
            DrawBorder();
        }

        public void DrawBorder(bool ExtendUp, bool ExtendDown, bool ExtendLeft, bool ExtendRight)
        {
            Console.SetCursorPosition(X, Y);

            //Draw the outline top and bottom
            for (int k = X; k < Width; k++)
            {
                Console.SetCursorPosition(k, Y);
                System.Console.Write('\u2500');

                Console.SetCursorPosition(k, Y + Height);
                System.Console.Write('\u2500');
            }

            //Draw the outline left and right
            for (int k = Y; k < Height; k++)
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

            if(ExtendDown)
            {
                BottomRight.South = true;
                BottomLeft.South = true;
            }

            if(ExtendLeft)
            {
                TopLeft.West = true;
                BottomLeft.West = true;
            }

            if(ExtendRight)
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
    }
}
