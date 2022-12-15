using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.Model
{
   public class AccountsModel
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string User_Id { get; set; }
        public string Email { get; set; }
        public List<TransactionalModel> TransactionHolder { get; set; }
    }
}
