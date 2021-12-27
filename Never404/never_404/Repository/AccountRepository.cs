using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404.Repository
{
    public class AccountRepository
    {
        private static AccountRepository AccountRepo;

        private AccountRepository()
        {

        }

        public static AccountRepository GetRepository()
        {
            if (AccountRepo == null)
            {
                AccountRepo = new AccountRepository();
            }
            return AccountRepo;
        }

        public Account GetAccount(int accountNumber)
        {
            BankDBContext db = new BankDBContext();
            return db.Account.Where(x => x.AccountNumber == accountNumber).FirstOrDefault();
        }
    }
}
