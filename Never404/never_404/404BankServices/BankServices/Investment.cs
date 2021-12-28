using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class Investment : AccountDecorator, IBankService
    {
        public Investment(IAccount account) : base(account)
        {
            ServiceName = "Investment";
        }

        public override void Action(ActionModel data)
        {
            Console.WriteLine("I Made an investment, hope it was a good one...");
        }
    }
}
