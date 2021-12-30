using never_404._404Transaction;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.ForeignTransfer
{
    class ForeignTransferSilver: IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            int bankFixedRate = 150;
            Transaction newTransaction = new TransactionModel(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType).GenerateTransaction();
            TransactionRepository.GetRepository().CreateTransaction(newTransaction, bankFixedRate);
            Console.WriteLine("Foreign transfer with Gold");
        }
    }
}
