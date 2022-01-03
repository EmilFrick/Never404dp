using never_404._404Accounts;
using never_404._404BankServices.BankServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Decorator
{
    public class AccountDecorator : IAccount, IBankService
    {
        private IAccount Account { get; set; }
        public string AccountType { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public AccountDecorator(IAccount account)
        {
            Account = account;
            AccountType = account.AccountType;
            AccountNumber = account.AccountNumber;
            Balance = account.Balance;
        }

        public void GetServices(List<IBankService> list)
        {
            list.Add(this);
            IBankService accountService = Account as IBankService;
            accountService?.GetServices(list);
        }

        public string ServiceName { get; set; }

        public virtual void Action(ActionModel data)
        {
            //I Execute a BankService
        }

    }
}
