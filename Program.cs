using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Pane p = new Pane(0, 0, 10, 10);
        }
    }

    class Pane
    {
        private int X;
        private int Y;
        private int Width;
        private int Height;
        private TextList FileList;
        private TextBox CurrentLocation;

        public Pane(int PosX, int PosY, int PaneWidth, int PaneHeight)
        {
            X = PosX;
            Y = PosY;
            Width = PaneWidth;
            Height = PaneHeight;
            DrawPane();
        }

        private void DrawPane()
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

    class TextList
    {

    }

    class TextBox
    {

    }

    class Button
    {

    }
}
