using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.ForeignPayment
{
    class ForeignPaymentPlatinum : IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            decimal platinumFee = 0.05m * data.Amount;
            TransactionRepository.GetRepository().CreateTransaction(data, platinumFee);
        }
    }
}
