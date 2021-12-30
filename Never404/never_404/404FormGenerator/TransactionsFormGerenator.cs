using System;
using never_404._404Users;

namespace never_404.Repository
{
    public class TransactionsFormGerenator : IFormGenerator
    {
        public string GenerateForm()
        {
            var spefications = SpecificationRepository.GetRepository().GetSpecifications();

            foreach (var s in spefications)
            {
                Console.WriteLine($"{s.Transaction.TransactionDate} From {s.Transaction.SenderAccount} to {s.Transaction.ReceiverAccount}");
            }

            Console.ReadLine();

            return ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber.ToString();
        }
    }
}