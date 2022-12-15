using BanksCore.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.UI
{
    public class Help_Center
    {
        public static void Helper()
        {
            Console.Clear();
            Background_Color.colorMagenta("WELCOME TO SEAMLESS BANK");
            Background_Color.colourBlue("GIVING YOU THE QUALITY YOU DESERVE");

            Console.WriteLine();

            Error_Handling.HelpBack();

        }
    }
}
