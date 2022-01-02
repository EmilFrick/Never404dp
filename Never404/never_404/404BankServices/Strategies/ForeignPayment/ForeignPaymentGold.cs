using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.ForeignPayment
{
    class ForeignPaymentGold : IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            decimal goldFee = 0.07m * data.Amount;
            TransactionRepository.GetRepository().CreateTransaction(data, goldFee);
        }
    }
}
