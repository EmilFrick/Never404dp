using never_404._404Accounts;
using never_404._404BankServices;
using System;
using System.Linq;

namespace never_404.Repository
{
    public class TransactionRepository
    {
        private static TransactionRepository transactionRepo;
        private int bank404AccountNumber= StoredAccounts.GetBank().AccountNumber;
        private int othersAccount = StoredAccounts.GetOthers().AccountNumber;

        private TransactionRepository()
        {

        }
        public static TransactionRepository GetRepository()
        {
            if (transactionRepo == null)
            {
                transactionRepo = new TransactionRepository();
            }
            return transactionRepo;
        }

        public void CreateTransaction(ActionModel data, decimal fee = 0)
        {
            Transaction transaction = GenerateTransaction(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType);
            BankDBContext db = new BankDBContext();
            if (transaction.ReceiverAccount == othersAccount)
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= transaction.Amount;
            }
            else
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.ReceiverAccount).Balance += transaction.Amount;
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= (transaction.Amount + fee);
            }
            db.Account.FirstOrDefault(x => x.AccountNumber == bank404AccountNumber).Balance += fee;
            db.Transaction.Add(transaction);
            db.SaveChanges();

            SpecificationRepository.GetRepository().CreateSpecification(transaction, data);
        }
        private Transaction GenerateTransaction(int senderAccount, int receiverAccount, decimal amount, string transactionType)
        {
            Transaction transaction = new Transaction();
            transaction.SenderAccount = senderAccount;
            transaction.ReceiverAccount = receiverAccount;
            transaction.Amount = amount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = transactionType;

            return transaction;
        }
    }
}
