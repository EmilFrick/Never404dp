using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using never_404._404BankServices.Strategies;
using never_404._404BankServices.Strategies.ForeignTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class ForeignTransfer : AccountDecorator, IBankService
    {
        private IMembershipStrategy Strategy;
        public ForeignTransfer(IAccount account) : base(account)
        {
            ServiceName = "Foreign Transfer";
            IdentifyStrategy(null);
        }

        public override void Action(ActionModel data)
        {
            Strategy.Action(data);
            //Console.WriteLine("I transfered money to an account outside of Sweden.");
        }
        public void IdentifyStrategy(string membership)
        {
            if (membership == "Platinum")
            {
                Strategy = new ForeignTransferPlatinum();
            }
            else if (membership == "Gold")
            {
                Strategy = new ForeignTransferGold();
            }
            else if (membership == "Silver")
            {
                Strategy = new ForeignTransferSilver();
            }
        }
    }
}
