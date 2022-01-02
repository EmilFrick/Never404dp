using never_404._404BankServices;
using never_404._404Users;
using System.Collections.Generic;
using System.Linq;

namespace never_404.Repository
{
    public class SpecificationRepository
    {
        private static SpecificationRepository specificationRepo;

        private SpecificationRepository()
        {

        }

        public static SpecificationRepository GetRepository()
        {
            if (specificationRepo == null)
            {
                specificationRepo = new SpecificationRepository();
            }
            return specificationRepo;
        }

        public void CreateSpecification(Transaction transaction, ActionModel data)
        {
            BankDBContext db = new BankDBContext();
            int receiver = transaction.ReceiverAccount.GetValueOrDefault();
            int sender = transaction.SenderAccount.GetValueOrDefault();

            if (AccountRepository.GetRepository().GetAccount(receiver).AccountType != "Bank")
            {
                db.Specification.Add(GenerateSpecification(transaction.TransactionID, receiver, data));
            }
            if (AccountRepository.GetRepository().GetAccount(sender).AccountType != "Bank")
            {
                db.Specification.Add(GenerateSpecification(transaction.TransactionID, sender, data));
            }

            db.SaveChanges();
        }

        private Specification GenerateSpecification(int transactionId, int specOwner, ActionModel data)
        {
            Specification specification = new Specification();
            specification.SpecificationOwner = specOwner;
            specification.TransactionID = transactionId;
            specification.Sender = data.SenderLabel;
            specification.Receiver = data.ReceiverLabel;

            return specification;
        }

        public List<Specification> GetSpecifications()
        {
            var accountNum = ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber;

            BankDBContext db = new BankDBContext();
            return db.Specification.Where(x => x.SpecificationOwner == accountNum).ToList();
        }
    }
}
