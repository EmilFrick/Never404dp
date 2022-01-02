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
        public Account CreateAccount(int userId, string accountType, decimal balance)
        {
            Account account = GenerateAccont(userId, accountType, balance);
            BankDBContext db = new BankDBContext();
            db.Account.Add(account);
            db.SaveChanges();

            return account;
        }

        private Account GenerateAccont(int userId, string accountType, decimal balance)
        {
            Account account = new Account();
            
            account.UserID = userId;
            account.AccountType = accountType;
            account.Balance = balance;

            return account;
        }

        public List<string> GetAccountType()
        {
            List<string> accountType = new List<string>();
            BankDBContext db = new BankDBContext();
            var list = db.AccountType.Where(x => x.AccountTypeName != "Bank");
            foreach (var name in list)
            {
                accountType.Add(name.AccountTypeName);
            }
            return accountType;
        }

        public int GetAccountId(Account account)
        {
            int accountNumber;
            using (BankDBContext db = new BankDBContext())
            {
                db.Account.Add(account);
                db.SaveChanges();
                accountNumber = account.AccountNumber;
            }
            return accountNumber;
        }
    }
}
