using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.PayInvoice
{
    public class PayInvoiceSilver : IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            decimal silverFee = 0.12m * data.Amount;
            TransactionRepository.GetRepository().CreateTransaction(data, silverFee);
        }
    }
}
