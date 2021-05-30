using NullLib.ConsForms;
using NullLib.ConsForms.Controls;
using System;
using System.Drawing;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePage page = new ConsolePage("This is a console page\n this is the second line of page")
            {
                BackColor = ConsoleColor.Black,
                ForeColor = ConsoleColor.White
            };
            page.Controls.Add(new Control()
            {
                Margin = new Thickness(20, 10, 0, 0),
                Width = 20,
                Height = 10,
                BackColor = ConsoleColor.White,
                ForeColor = ConsoleColor.Green,
                Text = "this is a control\n中文测试"
            });
            page.Controls.Add(new Control()
            {
                Margin = new Thickness(45, 10, 0, 0),
                Width = 50,
                Height = 10,
                BackColor = ConsoleColor.DarkGreen,
                ForeColor = ConsoleColor.Red,
                Text = "this is a control,\nand this is the second line of this control\nthird line\roverwrite"
            });
            GroupBox groupBox = new GroupBox()
            {
                Text = "GroupBoxHeader",
                Margin = new Thickness(10, 0, 10, 5),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Height = 3,
                HeaderBackColor = ConsoleColor.Yellow,
                HeaderForeColor = ConsoleColor.DarkRed,
                BackColor = ConsoleColor.Cyan,
                ForeColor = ConsoleColor.Black
            };
            groupBox.Controls.Add(new Control()
            {
                BackColor = ConsoleColor.Cyan,
                ForeColor = ConsoleColor.Black,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Text = "this is a very long text in a control, test for auto break line, and text visibility when text is overflow about control bounds. badly, it's not supported to scroll text int console application, because we can't capture mouse events in a appropriate way."
            });
            page.Controls.Add(groupBox);
            page.Controls.Add(new Control()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(1, 0),
                Height = 1,
                Text = "Bottom alignment control",
                BackColor = ConsoleColor.Yellow,
                ForeColor = ConsoleColor.DarkBlue,
            });
            while(true)
            {
                Console.CursorVisible = false;
                Console.Title = "refreshing";
                //page.DrawContent();
                ShowConsoleColors();
                Console.Title = "refreshed";
                Console.ReadKey(true);

            }
        }
        static void ShowConsoleColors()
        {
            Control[] colors = ((ConsoleColor[])Enum.GetValues(typeof(ConsoleColor))).Select(color => new Control()
            {
                Height = 1,
                Width = 10,
                BackColor = color,
                ForeColor = 15 - color,
                Text = Enum.GetName(typeof(ConsoleColor), color)
            }).ToArray();
            for (int i = 0; i < 16; i += 2)
            {
                var tmp = new Point();
                colors[i].Margin = new Thickness(0, i / 2, 0, 0);
                colors[i + 1].Margin = new Thickness(10, i / 2, 0, 0);
            }
            ConsolePage page = new ConsolePage()
            {
                BackColor = ConsoleColor.Black,
                ForeColor = ConsoleColor.White
            };
            page.Controls.AddRange(colors);
            page.DrawContent();
        }
    }
}
