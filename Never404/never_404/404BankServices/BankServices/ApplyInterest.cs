using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class ApplyInterest : AccountDecorator, IBankService
    {
        public ApplyInterest(IAccount account) : base(account)
        {
            ServiceName = "Apply Interest";
        }

        public override void Action(ActionModel data)
        {
            Console.WriteLine("Interest got added to this account");
        }
    }
}
