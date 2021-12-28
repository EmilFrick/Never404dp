using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using never_404._404Transaction;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class Transfer : AccountDecorator, IBankService
    {
        public Transfer(IAccount account) : base(account)
        {
            ServiceName = "Transfer";
        }

        public override void Action(ActionModel data)
        {
            Transaction newTransaction = new TransactionModel(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType).GenerateTransaction();
            TransactionRepository.GetRepository().CreateTransaction(newTransaction);
            Console.WriteLine("I transfered money from this account.");
        }
        
    }
}
