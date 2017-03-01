using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
    class UIElement
    {
        protected int X;
        protected int Y;
        protected int Width;
        protected int Height;

        public UIElement(int PosX, int PosY, int ElementWidth, int ElementHeight)
        {
            X = PosX;
            Y = PosY;
            Width = ElementWidth + 1;
            Height = ElementHeight + 1;
        }

        public virtual void DrawBorder()
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

                Console.SetCursorPosition(X + 1, k);
                System.Console.Write('A');

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
    }
}
