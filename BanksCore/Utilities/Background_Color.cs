using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.Utilities
{
    public static class Background_Color
    {

        //Display blue background and a black font
        public static void colourBlue(string value)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(PadBoth(value, Console.WindowWidth - 1));
            Console.ResetColor();
        }



        //Display Yellow background and a black font
        public static void colourYellow(string value)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }



        //Display Red background and a black font
        public static void colorRed(string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
        //Display Green background and a black font
        public static void colorGreen(string value)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
        }
        //Display magenta background and a black font
        public static void colorMagenta(string value)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(PadBoth(value, Console.WindowWidth - 1));
            Console.ResetColor();
        }

        //Centralize Text
        public static string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);

        }
    }
}
