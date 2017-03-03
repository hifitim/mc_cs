using System;

namespace mc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            string HomeDirectory = Environment.GetEnvironmentVariable("HOME");

            Pane LeftPane = new Pane(0, 0, 39, 29, HomeDirectory);
            Pane RightPane = new Pane(40, 0, 39, 29, HomeDirectory);

            RightPane.SetCurrentLocation(HomeDirectory);
            LeftPane.SetCurrentLocation(HomeDirectory);

            LeftPane.DrawContents();
            RightPane.DrawContents();

            Console.ReadKey();
        }
    }

    class Button
    {

    }
}
