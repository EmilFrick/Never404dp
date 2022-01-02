using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using never_404._404BankServices.Strategies;
using never_404._404BankServices.Strategies.ForeignPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class ForeignPayment : AccountDecorator, IBankService
    {
        private IMembershipStrategy Strategy;

        public ForeignPayment(IAccount account) : base(account)
        {
            ServiceName = "Foreign Payment";
            IdentifyStrategy(null);
        }

        public override void Action(ActionModel data)
        {
            Strategy.Action(data);
        }
        public void IdentifyStrategy(string membership)
        {
            if (membership == "Platinum")
            {
                Strategy = new ForeignPaymentPlatinum();
            }
            else if (membership == "Gold")
            {
                Strategy = new ForeignPaymentGold();
            }
            else if (membership == "Silver")
            {
                Strategy = new ForeignPaymentSilver();
            }
        }
    }
}
