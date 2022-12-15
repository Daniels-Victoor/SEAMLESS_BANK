using System;
using BanksCore.Model;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.Account_Management
{
    //Authentication
    public class Login_User 
    {

        public static UsersModel User_Login(List<UsersModel> Users, string email, string password)
        {
            foreach (var item in Users)
            {

                if (item.Email == email && item.Password == password)
                {
                    return item;
                }
            }


            return null;


        }
    }
}
