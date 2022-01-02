using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.ForeignTransfer
{
    class ForeignTransferGold: IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            int bankFixedRate = 100;
            TransactionRepository.GetRepository().CreateTransaction(data, bankFixedRate);
        }
    }
}
