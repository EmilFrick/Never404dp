using never_404._404Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void CreateSpecification(Transaction transaction)
        {
            BankDBContext db = new BankDBContext();
            Specification specificationReceiver = null;
            Specification specificationSender = null;
            int receiver = transaction.ReceiverAccount.GetValueOrDefault();
            int sender = transaction.SenderAccount.GetValueOrDefault();

            if (AccountRepository.GetRepository().GetAccount(receiver).AccountType != "Bank")
            {
                specificationReceiver = GenerateSpecification(transaction.TransactionID, receiver);
                db.Specification.Add(specificationReceiver);
            }
            if (AccountRepository.GetRepository().GetAccount(sender).AccountType != "Bank")
            {
                specificationSender = GenerateSpecification(transaction.TransactionID, sender);
                db.Specification.Add(specificationSender);
            }

            
            
            db.SaveChanges();
        }

        private Specification GenerateSpecification(int transactionId, int specOwner)
        {
            Specification specification = new Specification();
            specification.SpecificationOwner = specOwner;
            specification.TransactionID = transactionId;
            specification.Sender = "Label - sender";
            specification.Receiver = "Label - receiver";

            return specification;
        }

        public List<Specification> GetSpecifications()
        {
            //List<Specification> specificiations = new List<Specification>();
            var accountNum = ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber;
            
            BankDBContext db = new BankDBContext(); 
            return db.Specification.Where(x => x.SpecificationOwner == accountNum).ToList();

            //foreach (var spec in list)
            //{
            //    specificiations.Add(spec);
            //}
            //return specificiations;
        }
    }
}
