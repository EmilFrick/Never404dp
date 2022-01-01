using System;
using never_404._404Users;

namespace never_404.Repository
{
    public class TransactionsFormGerenator : IFormGenerator
    {
        public string GenerateForm()
        {
            var spefications = SpecificationRepository.GetRepository().GetSpecifications();

            UIConsole.AddHeader("Transaction history");
            Console.WriteLine("Date          Sender         Receiver        Amount ");
            Console.WriteLine("---------------------------------------------------");
            var op = "";
            foreach (var s in spefications)
            {
                if (s.Transaction.SenderAccount == ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber)
                {
                    op = "-";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    op = "+";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                
                Console.WriteLine($"{s.Transaction.TransactionDate:d}    {s.Transaction.SenderAccount}      {s.Transaction.ReceiverAccount}       {op}${s.Transaction.Amount}");
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine();

            return ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber.ToString();
        }
    }
}