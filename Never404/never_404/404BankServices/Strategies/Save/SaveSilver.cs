using never_404._404Transaction;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.Save
{
    public class SaveSilver : IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            Transaction trans = new TransactionModel(121212, 12121, 10, "Invoce").GenerateTransaction();

            TransactionRepository.GetRepository().CreateTransaction(trans);
            Console.WriteLine("I Save Silver");
        }
     }
}
