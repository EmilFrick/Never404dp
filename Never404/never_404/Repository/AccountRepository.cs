using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404.Repository
{
    public class AccountRepository
    {
        private static AccountRepository accountRepo;

        private AccountRepository()
        {

        }

        public static AccountRepository GetRepository()
        {
            if (accountRepo == null)
            {
                accountRepo = new AccountRepository();
            }
            return accountRepo;
        }

        public Account GetAccount(int accountNumber)
        {
            BankDBContext db = new BankDBContext();
            return db.Account.Where(x => x.AccountNumber == accountNumber).FirstOrDefault();
        }
        
        public List<Account> GetAccounts(int userId)
        {   
            BankDBContext db = new BankDBContext();
            return db.Account.Where(x => x.UserID == userId).ToList();
        }
        static void CreateAccount(Account account)
        {
            BankDBContext db = new BankDBContext();
            db.Account.Add(account);
            db.SaveChanges();
        }
        //static Account GenerateAccont(int accountNum, int userId, string accountType, decimal balance)
        //{
        //    Account account = new Account();
        //    account.AccountNumber = accountNum;
        //    account.UserID = userId;
        //    account.AccountType = accountType;
        //    account.Balance = balance;

        //    return account;
        //}
    }
}
