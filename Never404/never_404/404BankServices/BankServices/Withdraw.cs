using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class Withdraw : AccountDecorator, IBankService
    {
        public Withdraw(IAccount account) : base(account)
        {
            ServiceName = "Withdraw";
        }

        public override void Action(params string[] data)
        {
            Console.WriteLine("I withdrew money from this account.");
        }
    }
}
