using System;

namespace mc
{
    abstract class UIElement
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public UIElement(int PosX, int PosY, int ElementWidth, int ElementHeight)
        {
            X = PosX;
            Y = PosY;
            Width = ElementWidth;
            Height = ElementHeight;
        }

        public virtual void DrawBorder()
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

            //Replace the corners
            //Top left
            Console.SetCursorPosition(X, Y);
            System.Console.Write('\u250C');
            //Bottom right
            Console.SetCursorPosition(X + Width, Y + Height);
            System.Console.Write('\u2518');
            //Top right
            Console.SetCursorPosition(X + Width, Y);
            System.Console.Write('\u2510');
            //Bottom left
            Console.SetCursorPosition(X, Y + Height);
            System.Console.Write('\u2514');
        }

        public abstract void DrawContents();
        public abstract void MoveCursorToEnd();
        public abstract void MoveCursorToBegin();
        public abstract void MoveCursorToPreferred();
    }
}
