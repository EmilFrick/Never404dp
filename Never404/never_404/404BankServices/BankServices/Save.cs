using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using never_404._404BankServices.Strategies;
using never_404._404BankServices.Strategies.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class Save : AccountDecorator, IBankService
    {
        private IMembershipStrategy Strategy;

        public Save(IAccount account) : base(account)
        {
            ServiceName = "Save";
            IdentifyStrategy("Gold"); 
        }

        public override void Action(params string[] data)
        {
            Strategy.Action();
        }

        public void IdentifyStrategy(string membership)
        {
            if (membership == "Platinum")
            {
                Strategy = new SavePlatinum();
            }
            else if (membership == "Gold")
            {
                Strategy = new SaveGold();
            }
            else if (membership == "Silver")
            {
                Strategy = new SaveSilver();
            }
        }
    }
}
