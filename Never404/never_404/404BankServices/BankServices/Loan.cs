using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class Loan : AccountDecorator, IBankService
    {
        public Loan(IAccount account) : base(account)
        {
            ServiceName = "Loan";
        }

        public override void Action(ActionModel data)
        {
            Console.WriteLine("I borrowed some money");
        }
    }
}
