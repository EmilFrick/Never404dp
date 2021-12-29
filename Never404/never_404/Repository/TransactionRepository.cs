using System.Linq;

namespace never_404.Repository
{
    public class TransactionRepository
    {
        private static TransactionRepository transactionRepo;
        private int bank404AccountNumber = 512885004;
        private int othersAccount = 512885027;

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

        public Account GetTransaction(int accountNumber)
        {
            BankDBContext db = new BankDBContext();
            return db.Account.Where(x => x.AccountNumber == accountNumber).FirstOrDefault();
        }
        public void CreateTransaction(Transaction transaction)
        {
            BankDBContext db = new BankDBContext();
            if (transaction.ReceiverAccount == othersAccount)
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= transaction.Amount;
            }
            else
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.ReceiverAccount).Balance += transaction.Amount;
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= transaction.Amount;
            }
            

            int receiver = transaction.ReceiverAccount.GetValueOrDefault();
            int sender = transaction.SenderAccount.GetValueOrDefault();

            if (AccountRepository.GetRepository().GetAccount(receiver).AccountType != "Bank")
            {
                // Create Specification for receiverAccount
            }
            if (AccountRepository.GetRepository().GetAccount(sender).AccountType != "Bank")
            {
                // Create Specification for SenderAccount
            }

            db.Transaction.Add(transaction);
            db.SaveChanges();
        }
        public void CreateTransaction(Transaction transaction, decimal fee)
        {
            BankDBContext db = new BankDBContext();
            var bankFee = (transaction.Amount * fee) - transaction.Amount;
            if (transaction.ReceiverAccount == othersAccount)
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= (transaction.Amount * fee);
            }
            else
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.ReceiverAccount).Balance += transaction.Amount;
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= (transaction.Amount * fee);
            }
            
            db.Account.FirstOrDefault(x => x.AccountNumber == bank404AccountNumber).Balance += bankFee;
            db.Transaction.Add(transaction);
            db.SaveChanges();
        }
        public void TransactionFixedRate(Transaction transaction, int fixedRate)
        {
            BankDBContext db = new BankDBContext();
            int bankFixedRate = fixedRate;
            if (transaction.ReceiverAccount == othersAccount)
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= (transaction.Amount + fixedRate);
            }
            else
            {
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.ReceiverAccount).Balance += transaction.Amount;
                db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= (transaction.Amount + fixedRate);
            }

            db.Account.FirstOrDefault(x => x.AccountNumber == bank404AccountNumber).Balance += fixedRate;
            db.Transaction.Add(transaction);
            db.SaveChanges();
        }
    }
}
