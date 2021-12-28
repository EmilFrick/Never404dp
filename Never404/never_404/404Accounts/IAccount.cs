using never_404._404BankServices;
using never_404._404Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Accounts
{
    public interface IAccount
    {
        string AccountType { get; set; }

        int AccountNumber { get; set; }

        decimal Balance { get; set; }

        void Action(ActionModel data);
    }
}
