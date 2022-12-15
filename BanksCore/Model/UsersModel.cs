using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.Model
{
    public class UsersModel
    {
        public string User_Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
