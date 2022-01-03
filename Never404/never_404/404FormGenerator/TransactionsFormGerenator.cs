using System;
using never_404._404BankServices;
using never_404._404BankServices.Strategies.Specification;
using never_404._404Users;

namespace never_404.Repository
{
    public class TransactionsFormGerenator : IFormGenerator
    {
        public string GenerateForm()
        {
            var spefications = SpecificationRepository.GetRepository().GetSpecifications();
            
            
            UIConsole.AddHeader("Transaction history");
            UIConsole.AddTableHeader(20, "Date", "From", "To", "Amount", "Transaction type");
           
            foreach (var s in spefications)
            {
                var data = new ActionModel();
                data.Amount = s.Transaction.Amount.GetValueOrDefault();
                data.TransactionType = s.Transaction.TransactionType;
                var specValueConverter = new SpecificationValueConverter();

                string op;
                if (s.Transaction.SenderAccount == ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber)
                {
                    op = "-";
                    UIConsole.SetColor(ConsoleColor.Red);
                }
                else
                {
                    op = "+";
                    UIConsole.SetColor(ConsoleColor.Green);
                }
                
                UIConsole.AddTableRow(20, $"{s.Transaction.TransactionDate:d}", $"{s.Sender}", $"{s.Receiver}", $"{op}${specValueConverter.ConvertValue(data)}", $"{s.Transaction.TransactionType}");
            }

            Console.ReadLine();
            UIConsole.SetDefaultColor();

            return ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber.ToString();
        }
    }
}