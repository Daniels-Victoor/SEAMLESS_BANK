using System;
using System.Collections.Generic;
using System.Text;

namespace BanksCore.Model
{
    public class TransactionalModel
    {
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
    }
}
