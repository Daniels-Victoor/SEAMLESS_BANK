using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BanksCore.Utilities
{
    public static class Validations
    {
        public static bool ValidateEmail(string email)
        {
            string strRegex = @"^[a-z]+[0-9a-zA-Z_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(email))
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }

        public static bool ValidateName(string name)
        {
            string strRegex = @"^[A-Z]";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(name))
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }
        public static bool ValidatePassword(string password)
        {
            string strRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";

            Regex re = new Regex(strRegex);

            if (re.IsMatch(password))
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }
        private static bool PerformRegExMethod(string pattern, string value)
        {
            Regex re = new Regex(pattern);

            if (re.IsMatch(value))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
