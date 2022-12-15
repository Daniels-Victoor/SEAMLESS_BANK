using BanksCore.Account_Management;
using BanksCore.Model;
using BanksCore.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.Utilities
{
    public static class Error_Handling
    {

        //Success method for green background
        public static void SuccessMessage(string message)
        {
            Background_Color.colorGreen(message);

        }


        public static decimal AmountError(decimal amount)
        {

            while (true)
            {

                if (amount < 0)
                {
                    Background_Color.colorRed("Invalid amount");
                    Console.Write("Enter a valid amount: ");
                    amount = Convert.ToDecimal(Console.ReadLine());
                }

                return amount;

            }
        }

        public static void TryAgain(string message)
        {
            Background_Color.colorRed(message);
            Console.Write("Please Enter a Reply Here: ");
        }


        public static void BackMain(UsersModel users)
        {
            Console.Write("Press 0 To Go Back or Press 1 to Display Menu: ");
            string Response = Console.ReadLine();
            while (Response != "0" && Response != "1")
            {

                Background_Color.colorRed("Please Enter a Valid Response");
                Response = Console.ReadLine();
            }
            if (Response == "0")
            {
                Account_Operations.CurrentMethod(users);
            }
            else
            {
                Create_Account.View(users);
            }

        }

        public static void cBack(UsersModel users)
        {
            Console.Write("press 0 to go to Main Menu or 1 to go back: ");

            string response = Console.ReadLine();

            while (response != "0" && response != "1")
            {
                Console.WriteLine("Inavlid Input!!!!");
                response = Console.ReadLine();
            }
            if (response == "0")
            {
                Main_Display.ShowBankDisplay();
            }
            else
            {
                Create_Account.View(users);
            }

        }
        public static void csBack()
        {
            Console.Write("press 0 to go back: ");

            string response = Console.ReadLine();

            while (response != "0")
            {
                Console.WriteLine("Inavlid Input!!!!");
                response = Console.ReadLine();
            }
            if (response == "0")
            {
                Main_Display.ShowBankDisplay();
            }

            else
            {
                Error_Handling.TryAgain("Invalid Response");
            }
        }

        public static void Heading()
        {
            Background_Color.colorMagenta("WELCOME TO SEAMLESS BANK");
            Background_Color.colourBlue("GIVING YOU THE QUALITY YOU DESERVE");

            Background_Color.colourYellow("PLEASE SELECT AN OPTION");
            Console.WriteLine();
        }


        public static void HelpBack()
        {
            Background_Color.colourYellow("1:If you have account(s) and want to perform a Transaction, Response 1");

            Background_Color.colorGreen("2:To Register As A User, Response 2");

            Background_Color.colourYellow("Reply 0 To go Back to the Main Menu.");
            Console.Write("Please Enter a Reply Here: ");


            string Reply = Console.ReadLine();
            while (Reply != "1" && Reply != "2" && Reply != "0")
            {
                Console.Clear();
                Error_Handling.TryAgain("Invalid Response. Reply should be 0, 1, or  2, Please Try Again");
                Reply = Console.ReadLine();
                Console.ResetColor();
            }
            switch (Reply)
            {
                case "0":
                    Main_Display.ShowBankDisplay();
                    Error_Handling.csBack();

                    break;
                case "1":
                    Main_Display.ShowBankDisplay();
                    Error_Handling.csBack();
                    break;
                case "2":
                    Main_Display.ShowBankDisplay();
                    Error_Handling.csBack();
                    break;
                default:
                    Error_Handling.TryAgain("Invalid Input, Try Again (1,2 or 0 )");
                    Reply = Console.ReadLine();
                    break;
            }

        }


    }
}
