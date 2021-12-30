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
            decimal platinumfee = 0.01m * data.Amount;
            Transaction newTransaction = new TransactionModel(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType).GenerateTransaction();
            TransactionRepository.GetRepository().CreateTransaction(newTransaction, platinumfee);
            Console.WriteLine("I Pay Platinum");
        }
    }
}
