using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Accounts
{
    public class AccountModel : IAccount
    {
        public string AccountType { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public AccountModel(string accountType, int accountNumber, decimal balance)
        {
            AccountType = accountType;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Action(params string[] data)
        {
            //I Excecute BankService
        }
    }
}
