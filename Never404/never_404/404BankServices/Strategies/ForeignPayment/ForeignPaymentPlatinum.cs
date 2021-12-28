using never_404._404Transaction;
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
            decimal platinumFee = 0.05m;
            Transaction newTransaction = new TransactionModel(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType).GenerateTransaction();
            TransactionRepository.GetRepository().CreateTransaction(newTransaction, platinumFee);
            Console.WriteLine("Foreign payment Platinum");
        }
    }
}
