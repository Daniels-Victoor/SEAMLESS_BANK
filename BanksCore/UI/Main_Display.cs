using BanksCore.Account_Management;
using BanksCore.BankTransactionsModel;
using BanksCore.Model;
using BanksCore.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.UI
{
    public class Main_Display
    {

        static readonly List<UsersModel> Bank_Customers = new List<UsersModel>();

        public static void ShowBankDisplay()
        {
            Console.Clear();
            Error_Handling.Heading();

            Console.Write("1. REGISTER A USER ACCOUNT\n2. LOGIN\n3. HELP\n4: EXIT");
            Console.WriteLine();
            Console.Write("Please Enter a Reply Here: ");

            string Response = Console.ReadLine().ToUpper();
            while (Response != "1" && Response != "2" && Response != "3" && Response != "4")
            {
                Error_Handling.TryAgain("Invalid Response, Please try again with a valid response.");
                Response = Console.ReadLine().ToUpper();
            }



            if (Response == "1")
            {
                string fullName;
                string email;
                string password;

                //collects fullname and validates it
                while (true)
                {
                    Console.Write("Please Enter Your Full Name: ");
                    fullName = Console.ReadLine();
                    while (fullName.Split(" ").Length != 2)
                    {
                        Error_Handling.TryAgain("Wrong Name Format, Name should contain fullName(Firstname and LastName)");
                        fullName = Console.ReadLine();
                    }
                    string[] names = fullName.Split();
                    if (Validations.ValidateName(names[0]) && Validations.ValidateName(names[1]))
                    {
                        break;
                    }
                    Error_Handling.TryAgain("Please input the correct format\n Names should start with capital letter, Like Jane Doe");
                }

                //collects Email and validates it
                while (true)
                {
                    Console.Write("Please Enter Your Email: ");
                    email = Console.ReadLine();
                    if (Validations.ValidateEmail(email))
                    {
                        break;
                    }
                    Error_Handling.TryAgain("Please input the correct email format like johndoe@gmail.com");
                }
                while (true)
                {
                    Console.Write("Please Enter Your Password: ");
                    password = Console.ReadLine();
                    if (Validations.ValidatePassword(password))
                    {
                        break;
                    }
                    Error_Handling.TryAgain("Please input the correct format\n Password should minimum of 6 " +
                        "characters including special character");
                }

                try
                {
                    UsersModel Customer = new UsersModel()
                    {
                        FullName = fullName,
                        Email = email,
                        Password = password
                    };
                    Bank_Customers.Add(Customer);
                    Error_Handling.SuccessMessage("User successfully Registered.");
                    Error_Handling.csBack();

                }
                catch (Exception)
                {
                    Error_Handling.TryAgain("Try again");
                }
                Error_Handling.csBack();


            }
            else if (Response == "2")
            {
                string email;
                string password;

                Console.Write("Please Enter Your Email: ");
                while (true)
                {

                    email = Console.ReadLine();
                    if (Validations.ValidateEmail(email))
                    {
                        break;
                    }
                    Error_Handling.TryAgain("Please input the correct email format like johndoe@gmail.com");
                }

                Console.Write("Please Enter Your Password: ");
                while (true)
                {

                    password = Console.ReadLine();
                    if (Validations.ValidatePassword(password))
                    {
                        break;
                    }
                    Error_Handling.TryAgain("Please input the correct format\n Password should minimum of 6 " +
                    "characters including special character");
                }


                UsersModel logins = Login_User.User_Login(Bank_Customers, email, password);
                if (logins != null)
                {
                    Console.Clear();
                    Background_Color.colorMagenta($"WELCOME {logins.FullName} TO SEAMLESS BANK");
                    Background_Color.colourBlue("GIVING YOU THE QUALITY YOU DESERVE");
                    Create_Account.View(logins);

                }
                else
                {
                    while (true)
                    {
                        Background_Color.colorRed("Please Invalid Credentials");
                        Error_Handling.csBack();
                        Console.ReadLine();
                    }

                }
            }

            else if (Response == "3")
            {
                Help_Center.Helper();
            }
            else if (Response == "4")
            {

            }



        }

    }
}
