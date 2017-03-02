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
            Pane LeftPane = new Pane(0, 0, 39, 29);
            Pane RightPane = new Pane(40, 0, 39, 29);
            RightPane.SetCurrentLocation(Environment.GetEnvironmentVariable("HOME"));
            LeftPane.SetCurrentLocation(Environment.GetEnvironmentVariable("PSModulePath"));
            LeftPane.DrawContents();
            RightPane.DrawContents();
            Console.ReadKey();
        }
    }

    class TextList
    {

    }

    class Button
    {

    }
}
