using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class ForeignPayment : AccountDecorator, IBankService
    {
        public ForeignPayment(IAccount account) : base(account)
        {
            ServiceName = "Foreign Payment";
        }

        public override void Action(params string[] data)
        {
            Console.WriteLine("I made a payment to an account outside of Sweden");
        }
    }
}
