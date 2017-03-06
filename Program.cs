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
        static int LeftPaneWidth = (Console.WindowWidth / 2) - 1;
        static int LeftPaneHeight = Console.WindowHeight - 2;

        static int RightPanePosX = (Console.WindowWidth / 2);
        const int RightPanePosY = 0;
        static int RightPaneWidth = (Console.WindowWidth / 2) - 1;
        static int RightPaneHeight = Console.WindowHeight - 2;

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
            int FocusedUIElement = 0;

            UIElements.Add(LeftFileList);
            UIElements.Add(RightFileList);

            UIElements.Add(LeftCurrentLocation);
            UIElements.Add(RightCurrentLocation);

            LeftPane.DrawContents();
            RightPane.DrawContents();

            LeftCurrentLocation.OnReturnKeyPressed += LeftCurrentLocation_OnReturnKeyPressed;
            
            Console.SetCursorPosition(UIElements[0].X + 1, UIElements[0].Y + 1);

            ConsoleKeyInfo ReadKey;
            do
            {
                ReadKey = Console.ReadKey(true);
                switch (ReadKey.Key)
                {
                    case ConsoleKey.Tab:
                        if ((ReadKey.Modifiers & ConsoleModifiers.Shift) == 0)
                        {
                            if (++FocusedUIElement > (UIElements.Count - 1))
                            {
                                FocusedUIElement = 0;
                            }
                        }
                        else
                        {
                            if (--FocusedUIElement < 0)
                            {
                                FocusedUIElement = UIElements.Count - 1;
                            }
                        }

                        UIElements[FocusedUIElement].MoveCursorToPreferred();

                        break;
                    case ConsoleKey.LeftArrow:
                        UIElements[FocusedUIElement].MoveCursorLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        UIElements[FocusedUIElement].MoveCursorRight();
                        break;
                    
                    default:
                        // Printable key
                        if(ReadKey.KeyChar >= 0x20 &&
                            ReadKey.KeyChar <= 0x7F)
                        {
                            UIElements[FocusedUIElement].PrintableKeyPressed(ReadKey);
                        }
                        else
                        {
                            UIElements[FocusedUIElement].MiscKeyPressed(ReadKey);
                        }
                        break;
                }

            } while (ReadKey.Key != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine();
        }

        private static void LeftCurrentLocation_OnReturnKeyPressed(object sender, TextBoxReturnKeyEventArgs e)
        {
            List<string> NewFileList = new List<string>(Directory.GetFiles(e.Text));
            for (int k = 0; k < NewFileList.Count; k++)
            {
                NewFileList[k] = NewFileList[k].Substring(NewFileList[k].LastIndexOf("\\") + 1, NewFileList[k].Length - NewFileList[k].LastIndexOf("\\") - 1);
            }

            LeftFileList.TheList = NewFileList;
            LeftFileList.DrawContents();
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

            List<string> NewFileList = new List<string>(Directory.GetFiles(HomeDirectory));
            for (int k = 0; k < NewFileList.Count; k++)
            {
                NewFileList[k] = NewFileList[k].Substring(NewFileList[k].LastIndexOf("\\") + 1, NewFileList[k].Length - NewFileList[k].LastIndexOf("\\") - 1);
            }

            LeftFileList = new TextList(LeftPanePosX + 1,
                                        LeftPanePosY + 1,
                                        LeftPaneWidth - 1,
                                        LeftPaneHeight - 5,
                                        NewFileList);

            LeftCurrentLocation = new TextBox(LeftPanePosX,
                                              LeftPanePosY + LeftPaneHeight - CurrentLocationHeight,
                                              LeftPaneWidth,
                                              CurrentLocationHeight);

            RightFileList = new TextList(RightPanePosX + 1,
                                         RightPanePosY + 1,
                                         RightPaneWidth - 1,
                                         RightPaneHeight - 5,
                                         NewFileList);

            RightCurrentLocation = new TextBox(RightPanePosX,
                                               RightPanePosY + RightPaneHeight - CurrentLocationHeight,
                                               RightPaneWidth,
                                               CurrentLocationHeight);
            LeftCurrentLocation.DrawBorder(true, false, false, false);
            LeftCurrentLocation.Text = Environment.GetEnvironmentVariable("VS110COMNTOOLS");

            RightCurrentLocation.DrawBorder(true, false, false, false);
            RightCurrentLocation.Text = HomeDirectory;

            RightFileList.DrawContents();
            LeftFileList.DrawContents();

            RightCurrentLocation.DrawContents();
            LeftCurrentLocation.DrawContents();
        }
    }

    class Button
    {

    }
}
