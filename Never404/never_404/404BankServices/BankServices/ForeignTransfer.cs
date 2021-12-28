using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class ForeignTransfer : AccountDecorator, IBankService
    {

        public ForeignTransfer(IAccount account) : base(account)
        {
            ServiceName = "Foreign Transfer";
        }

        public override void Action(ActionModel data)
        {
            Console.WriteLine("I transfered money to an account outside of Sweden.");
        }
    }
}
