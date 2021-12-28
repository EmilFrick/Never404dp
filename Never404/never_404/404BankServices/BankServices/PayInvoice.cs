using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class PayInvoice : AccountDecorator, IBankService
    {
        public PayInvoice(IAccount account) : base(account)
        {
            ServiceName = "Pay Invoice";
        }

        public override void Action(ActionModel data)
        {
            Console.WriteLine("I was a good boi and paid an invoice in time!.");
        }
    }
}
