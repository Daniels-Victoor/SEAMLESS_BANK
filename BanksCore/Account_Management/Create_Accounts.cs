using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BanksCore.Utilities;
using BanksCore.Model;
using BanksCore.BankTransactionsModel;
using BanksCore.UI;


namespace BanksCore.Account_Management
{
    public class Create_Account
    {

        public static readonly List<Account_Transaction_Methods> CustomerAccount = new List<Account_Transaction_Methods>();


        public static void View(UsersModel users)
        {
            Console.Clear();
            Error_Handling.Heading();
            Console.WriteLine("1: Create Account");
            Console.WriteLine("2: Perform Transactions/Operations");
            Console.WriteLine("3: Log Out");
            Console.Write("Please Enter a Reply Here: ");
            string reply = Console.ReadLine();
            while (reply != "1" && reply != "2" && reply != "3")
            {
                Error_Handling.TryAgain("Wrong input format");
                reply = Console.ReadLine();
            }

            if (reply == "1")
            {
                Console.Clear();
                Error_Handling.Heading();
                int accountType;

                while (true)
                {
                    Console.Write("Choose Account Type 0 for Saving or 1 for Current: ");
                    string checkTypes = Console.ReadLine();
                    while (checkTypes != "0" && checkTypes != "1")
                    {
                        Background_Color.colorRed("Invalid account Type, type 0 or 1");
                        Console.Write("Enter a valid response here: ");
                        checkTypes = Console.ReadLine();
                    }
                    bool checkType = int.TryParse(checkTypes, out accountType);
                    if (checkType)
                    {
                        break;
                    }


                }
                Console.WriteLine("This will take just a few seconds.");
                Console.WriteLine("Please wait while your account is being created......");


                var Create_Account = new Account_Transaction_Methods(users.User_Id, accountType, users.Email);
                CustomerAccount.Add(Create_Account);
                Thread.Sleep(3000); //dramatic pause

                Console.Clear();
                Error_Handling.Heading();
                Error_Handling.SuccessMessage($" You have Succeffully created a {Create_Account.account.AccountType} Account");
                Error_Handling.SuccessMessage($"Your Account Number is : {Create_Account.account.AccountNumber}");
                Error_Handling.SuccessMessage($" Your AccountName is: {users.FullName}");
                Error_Handling.SuccessMessage($" Your account balance is:  {Create_Account.account.Balance}");
                Error_Handling.cBack(users);

            }
            else if (reply == "2")
            {
                Account_Operations.CurrentMethod(users);
                Error_Handling.cBack(users);
            }
            else if (reply == "3")
            {
                Main_Display.ShowBankDisplay();

                Error_Handling.cBack(users);
            }

        }
    }
    public class Account_Operations : Create_Account
    {
        public static void CurrentMethod(UsersModel users)
        {
            Console.Clear();
            Error_Handling.Heading();
            Console.WriteLine("1: Deposit");
            Console.WriteLine("2: Withdrawal");
            Console.WriteLine("3: Transfer");
            Console.WriteLine("4: Check Balance");
            Console.WriteLine("5: Print Details");
            Console.WriteLine("6: Print Statement");
            Console.WriteLine("7: Log Out");
            Console.WriteLine();
            Console.Write("Please Enter a Reply Here: ");
            string Reply = Console.ReadLine();

            while (Reply != "1" && Reply != "2" && Reply != "3" && Reply != "4" && Reply != "5" && Reply != "6" && Reply != "7")
            {
                Error_Handling.TryAgain("Inavalid Response, Please Try With a Valid Response");
                Reply = Console.ReadLine();
            }

            switch (Reply)
            {
                case "1":
                    Console.Clear();
                    Background_Color.colorMagenta("SEAMLESS BANK");
                    Deposit.DepositM(users);

                    break;
                case "2":
                    Console.Clear();
                    Background_Color.colorMagenta("SEAMLESS BANK");
                    Withdraw.Withdrawal(users);

                    break;
                case "3":

                    Console.Clear();
                    Background_Color.colorMagenta("SEAMLESS BANK");
                    Transfer.TransferMoney(users);

                    break;
                case "4":
                    Console.Clear();
                    Background_Color.colorMagenta("SEAMLESS BANK");
                    GetBalance.GetBal(users);

                    break;
                case "5":
                    Console.Clear();
                    Background_Color.colorMagenta("SEAMLESS BANK");
                    GetAccountDetails.GetAccountDetail(users);

                    break;
                case "6":
                    Console.Clear();    
                    Background_Color.colorMagenta("SEAMLESS BANK");
                    GetAccountStatement.AccountStatment(users);

                    break;
                case "7":
                    Main_Display.ShowBankDisplay();
                    Error_Handling.BackMain(users);
                    break;

                default:
                    Error_Handling.BackMain(users);
                    break;

            }
        }
    }
    public class Deposit : Create_Account
    {
        public static void DepositM(UsersModel users)
        {

            string AccNum = ViewAccounts.View_accounts(users, CustomerAccount);
            Console.Clear();
            string reply = "";
            Background_Color.colorMagenta("SEAMLESS BANK");
            Background_Color.colourBlue($"Account Number:{AccNum}");
            foreach (var item in CustomerAccount)
            {
                if (item.account.AccountNumber == AccNum)
                {
                    if (users != null)
                    {
                        Console.Write($"Please Enter the Amount to Deposit to {users.FullName} account: ");
                        string amount1 = Console.ReadLine();

                        decimal amount = Error_Handling.AmountError(Convert.ToDecimal(amount1));

                        if (amount > 300000 && item.account.AccountType == "SAVING")
                        {
                            reply = "Account can not take such large amount. Maximum deposit for a savings account is 300,000";

                        }
                        else
                        {
                            item.Deposit_Money(amount);
                            reply = $"{amount} successfully deposited!";
                            item.AddTransactions(amount, $"Your account was credited with {amount}");
                        }


                    }
                }
            }
            Console.WriteLine(reply);
            Error_Handling.BackMain(users);
        }
    }

    public class GetAccountDetails : Create_Account
    {
        public static void GetAccountDetail(UsersModel users)
        {
            var Table = new Print_Table("ACCOUNT NUMBER", "ACCOUNT NAME", "ACCOUNT TYPE", "BALANCE");
            Console.WriteLine($"ACCOUNT DETAILS FOR {users.FullName}");
            foreach (var item in CustomerAccount)
            {
                if (item.account.Email == users.Email)
                {
                    Table.AddRow(item.account.AccountNumber, users.FullName, item.account.AccountType, item.account.Balance);
                }
            }

            Table.Print();
            Error_Handling.BackMain(users);
        }
    }
    public class GetAccountStatement : Create_Account
    {
        public static void AccountStatment(UsersModel users)
        {
            string CheckAccNos = ViewAccounts.View_accounts(users, CustomerAccount);
            Console.Clear();
            Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NUMBER {CheckAccNos}");
            foreach (var item in CustomerAccount)
            {

                if (item.account.AccountNumber == CheckAccNos)
                {

                    var Tables = new Print_Table("Date", "Description", "Amount", "Balance");
                    var Statement = item.account.TransactionHolder;
                    foreach (var s in Statement)
                    {
                        if (s.AccountNumber == CheckAccNos)
                        {
                            Tables.AddRow(s.Date, s.Description, s.Amount, s.Balance);
                        }
                    }
                    Tables.Print();
                }
            }
            Error_Handling.BackMain(users);
        }
    }
    public class GetBalance : Create_Account
    {
        public static void GetBal(UsersModel users)
        {
            string CheckAccNo = ViewAccounts.View_accounts(users, CustomerAccount);
            Console.Clear();
            Background_Color.colorMagenta("SEAMLESS BANK");
            Background_Color.colourBlue($"Account Number:{CheckAccNo}");
            string Answer = "";
            foreach (var item in CustomerAccount)
            {
                if (item.account.AccountNumber == CheckAccNo)
                {
                    Answer = $"AccountName: {users.FullName}, \n AccountNumber: {item.account.AccountNumber}\n Account Balance : {item.account.Balance}";
                }
            }
            Error_Handling.SuccessMessage(Answer);
            Error_Handling.BackMain(users);
        }
    }
    public class Transfer : Create_Account
    {
        public static void TransferMoney(UsersModel users)
        {
            string sender = ViewAccounts.View_accounts(users, CustomerAccount);

            Background_Color.colorMagenta("SEAMLESS BANK");

            Background_Color.colourBlue($"Account Number:{sender}");
            Console.Write("Enter the Receiver's Account Number: ");
            decimal amountSent;
            int receiver;
            string AccountReceiving = Console.ReadLine();
            while (!int.TryParse(AccountReceiving, out receiver))
            {
                Console.Clear();

                Error_Handling.TryAgain("Please input a valid account number");

                AccountReceiving = Console.ReadLine();
            }


            while (AccountReceiving.Length < 10 && AccountReceiving.Length > 13)
            {
                Error_Handling.TryAgain("Please input a valid account number format. Account number should be in the range of 10 t0 13 digits numbers");

                AccountReceiving = Console.ReadLine();
            }


            Console.Write("Enter the Amount: ");
            string Amount2 = Console.ReadLine();
            amountSent = Error_Handling.AmountError(Convert.ToDecimal(Amount2));

            bool check = false;

            foreach (var item in CustomerAccount)
            {
                if (item.account.AccountNumber == sender)
                {
                    check = item.Withdrawal(amountSent, item.account.AccountType);
                    if (check)
                    {
                        item.AddTransactions(amountSent, $"Send {amountSent} to {AccountReceiving}");

                    }

                }
            }
            Error_Handling.SuccessMessage($"{amountSent} sucessfully transferred to {AccountReceiving}");
            if (check)
            {
                foreach (var item in CustomerAccount)
                {
                    if (item.account.AccountNumber == AccountReceiving)
                    {
                        item.Deposit_Money(amountSent);
                        item.AddTransactions(amountSent, $"Recieved {amountSent} from {sender}");

                    }
                }
            }
            else
            {
                Background_Color.colorRed("Insufficient funds");
            }
            Error_Handling.BackMain(users);
        }
    }
    public class ViewAccounts
    {
        public static string View_accounts(UsersModel users, List<Account_Transaction_Methods> CustomerAccount)
        {
            Console.Clear();
            int counts = 0;
            Background_Color.colorMagenta("WELCOME TO SEAMLESS BANK");
            Background_Color.colourBlue("PLEASE SELECT AN OPTION FROM THE LIST OF ACCOUNTS");
            int i = 1;

            List<string> accString = new List<string>();

            foreach (var item in CustomerAccount)
            {
                if (item.account.Email == users.Email)
                {
                    Console.WriteLine($"{i}:Account Type: {item.account.AccountType}\t   Account Number: {item.account.AccountNumber}");
                    accString.Add(item.account.AccountNumber);
                    i++;
                }
            }
            Background_Color.colourYellow("Select An Account to Access");
            if (accString.Count == 0)
            {
                Background_Color.colorRed("You do not have any account created please, Create an account.");
            }
            else
            {
                Console.Write("Enter a Valid Response Enter: ");



                string great = Console.ReadLine();
                int greatInt;


                while (!int.TryParse(great, out greatInt))
                {
                    Console.Write("Input a Response, Please Try Again with a Valid Number.");
                    great = Console.ReadLine();
                    counts = greatInt - 1;
                }


            }


            return accString[counts];

            Console.Clear();
        }
    }
    public class Withdraw : Create_Account
    {
        public static void Withdrawal(UsersModel users)
        {
            string AccNums = ViewAccounts.View_accounts(users, CustomerAccount);
            Console.Clear();
            Background_Color.colorMagenta("SEAMLESS BANK");
            Background_Color.colourBlue($"Account Number:{AccNums}");
            string replys = "";
            foreach (var item in CustomerAccount)
            {
                if (item.account.AccountNumber == AccNums)
                {
                    if (users != null)
                    {
                        Console.Write($"Please Enter the Amount to Withdraw:");
                        string AMTs = Console.ReadLine();
                        decimal AMT = Error_Handling.AmountError(Convert.ToDecimal(AMTs));
                        bool checks = item.Withdrawal(AMT, item.account.AccountType);
                        if (checks)
                        {
                            replys = $"{AMT} successfully Withdraw!";
                            item.AddTransactions(AMT, $"{AMT} was withdrawn");
                        }
                        else
                        {
                            replys = "Insufficient funds";
                        }
                    }

                }
            }
            Error_Handling.SuccessMessage(replys);
            Error_Handling.BackMain(users);
        }
    }
}
