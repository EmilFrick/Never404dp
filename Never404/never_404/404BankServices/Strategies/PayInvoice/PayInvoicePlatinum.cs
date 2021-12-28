using never_404._404Transaction;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.PayInvoice
{
    public class PayInvoicePlatinum : IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            decimal silverFee = 0.01m;
            Transaction newTransaction = new TransactionModel(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType).GenerateTransaction();
            TransactionRepository.GetRepository().CreateTransaction(newTransaction, silverFee);
            Console.WriteLine("I Pay Silver");
        }
    }
}
