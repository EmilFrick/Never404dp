using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using never_404._404BankServices.Strategies;
using never_404._404BankServices.Strategies.PayInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class PayInvoice : AccountDecorator, IBankService
    {
        private IMembershipStrategy strategy;
        public PayInvoice(IAccount account) : base(account)
        {
            ServiceName = "Pay Invoice";
            IdentifyStrategy("Gold");
        }

        public override void Action(ActionModel data)
        {
            strategy.Action(data);
        }
        public void IdentifyStrategy(string membership)
        {
            if (membership == "Platinum")
            {
                strategy = new PayInvoicePlatinum();
            }
            else if (membership == "Gold")
            {
                strategy = new PayInvoiceGold();
            }
            else if (membership == "Silver")
            {
                strategy = new PayInvoiceSilver();
            }
        }
    }
}
