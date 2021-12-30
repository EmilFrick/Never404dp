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
        public void CreateTransaction(Transaction transaction, decimal fee = 0)
        {
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

            SpecificationRepository.GetRepository().CreateSpecification(transaction);
        }
    }
}
