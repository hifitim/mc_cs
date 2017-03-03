using System;
using System.Collections.Generic;
using System.IO;

namespace mc
{
    class Program
    {
        const int CurrentLocationHeight = 2;
        const int LeftPanePosX = 0;
        const int LeftPanePosY = 0;
        const int LeftPaneWidth = 39;
        const int LeftPaneHeight = 29;

        const int RightPanePosX = 40;
        const int RightPanePosY = 0;
        const int RightPaneWidth = 39;
        const int RightPaneHeight = 29;

        static Pane LeftPane;
        static TextList LeftFileList;
        static TextBox LeftCurrentLocation;
        static Pane RightPane;
        static TextList RightFileList;
        static TextBox RightCurrentLocation;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            BuildUI();

            List<UIElement> UIElements = new List<UIElement>();
            UIElements.Add(LeftPane);
            UIElements.Add(RightPane);

            LeftPane.DrawContents();
            RightPane.DrawContents();

            ConsoleKeyInfo ReadKey;
            do
            {
                ReadKey = Console.ReadKey();
                switch (ReadKey.Key)
                {
                    case ConsoleKey.Tab:
                        if ((ReadKey.Modifiers & ConsoleModifiers.Shift) != 0)
                        {

                        }
                        else
                        {

                        }
                        break;
                    default:
                        break;
                }

            } while (ReadKey.Key != ConsoleKey.Escape);
        }

        private static void BuildUI()
        {
            string HomeDirectory = Environment.GetEnvironmentVariable("HOME");

            LeftPane = new Pane(LeftPanePosX,
                                LeftPanePosY,
                                LeftPaneWidth,
                                LeftPaneHeight,
                                HomeDirectory);

            RightPane = new Pane(RightPanePosX,
                                 RightPanePosY,
                                 RightPaneWidth,
                                 RightPaneHeight,
                                 HomeDirectory);

            LeftFileList = new TextList(LeftPanePosX + 1,
                                        LeftPanePosY + 1,
                                        LeftPaneWidth - 1,
                                        LeftPaneHeight - 2,
                                        new List<string>(Directory.GetFiles(HomeDirectory)));

            LeftCurrentLocation = new TextBox(LeftPanePosX,
                                              LeftPanePosY + LeftPaneHeight - CurrentLocationHeight,
                                              LeftPaneWidth,
                                              CurrentLocationHeight);

            RightFileList = new TextList(RightPanePosX + 1,
                                         RightPanePosY + 1,
                                         RightPaneWidth - 1,
                                         RightPaneHeight - 2,
                                         new List<string>(Directory.GetFiles(HomeDirectory)));

            RightCurrentLocation = new TextBox(RightPanePosX,
                                               RightPanePosY + RightPaneHeight - CurrentLocationHeight,
                                               RightPaneWidth,
                                               CurrentLocationHeight);
            LeftFileList.DrawContents();
            LeftCurrentLocation.DrawBorder(true, false, false, false);
            LeftCurrentLocation.Text = HomeDirectory;

            RightFileList.DrawContents();
            RightCurrentLocation.DrawBorder(true, false, false, false);
            RightCurrentLocation.Text = HomeDirectory;
        }
    }

    class Button
    {

    }
}
