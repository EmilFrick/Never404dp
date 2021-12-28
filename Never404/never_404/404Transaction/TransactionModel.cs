using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Transaction
{
    public class TransactionModel
    {
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }

        public TransactionModel(int senderAccount, int receiverAccount, decimal amount, string transactionType)
        {
            SenderAccount = senderAccount;
            ReceiverAccount = receiverAccount;
            Amount = amount;
            Date = DateTime.Now;
            TransactionType = transactionType;
        }
        public Transaction GenerateTransaction()
        {
            Transaction transaction = new Transaction();
            transaction.SenderAccount = SenderAccount;
            transaction.ReceiverAccount = ReceiverAccount;
            transaction.Amount = Amount;
            transaction.TransactionDate = Date;
            transaction.TransactionType = TransactionType;

            return transaction;
        }
    }
}
