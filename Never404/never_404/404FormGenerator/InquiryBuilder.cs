using never_404._404Accounts;
using never_404._404BankServices;
using never_404._404Users;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404FormGenerator
{
    public class InquiryBuilder
    {
        private ActionModel _actionModelReference;
        public InquiryBuilder(ActionModel amRef)
        {
            _actionModelReference = amRef;
        }


        public InquiryBuilder OtherReceiverInquiry()
        {
            UIConsole.GetFieldInput("Enter account number you wish to transer to")
                                                 .ConvertToValidNumBetween("Receiver Account Number", 9999, 1000000000)
                                                 .ConfirmingAccount();
            _actionModelReference.ReceiverAccount = StoredAccounts.GetOthers().AccountNumber;
            _actionModelReference.ReceiverLabel = UIConsole.GetFieldInput("Enter Receiver Name").RequiredMaxLength("Receiver Name", 20);
            return this;
        }

        public InquiryBuilder ReceiverInquiry()
        {
            int receiverAccountNumber = UIConsole.GetFieldInput("Enter account number you wish to transer to")
                                                 .ConvertToValidNumBetween("Receiver Account Number", 9999, 1000000000)
                                                 .ConfirmingAccount();


            string receivername;
            Account result = AccountRepository.GetRepository().GetAccount(receiverAccountNumber);
            
            if (result == null)
            {
                receiverAccountNumber = StoredAccounts.GetOthers().AccountNumber;
                receivername = UIConsole.GetFieldInput("Enter Receiver Account Name").RequiredMaxLength("Receiver Account Name", 20);
            }
            else
            {
                User recipient = UserRepository.GetRepository().GetUser(receiverAccountNumber);
                receivername = $"{recipient.FirstName} {recipient.LastName}";
                Console.WriteLine($"We are preparing a transfer to {receivername}!");
                receiverAccountNumber = result.AccountNumber;
            }

            _actionModelReference.ReceiverAccount = receiverAccountNumber;
            _actionModelReference.ReceiverLabel = receivername;
            return this;
        }

        public InquiryBuilder DebitAmountInquiry()
        {
            decimal amount;
            _actionModelReference.SenderAccount = ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber;
            _actionModelReference.SenderLabel = $"{ActiveUser.GetActiveUser().FirstName} {ActiveUser.GetActiveUser().LastName}";
            while (true)
            {
                amount = UIConsole.GetFieldInput("Enter Amount").ConvertToValidNumBetween("Enter Amount", 20, 100000);
                if (amount.SufficientBalance())
                {
                    break;
                }
                Console.WriteLine("Not enough in your account to make this transaction.");
            }
            _actionModelReference.Amount = amount;
            return this;
        }

        public InquiryBuilder CreditAmountInquiry()
        {
            _actionModelReference.SenderAccount = StoredAccounts.GetBank().AccountNumber;
            _actionModelReference.SenderLabel = "Never404 Bank";
            _actionModelReference.ReceiverAccount = ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber;
            _actionModelReference.ReceiverLabel = $"{ActiveUser.GetActiveUser().FirstName} {ActiveUser.GetActiveUser().LastName}";
            decimal amount = UIConsole.GetFieldInput($"How much do you want to {_actionModelReference.TransactionType}")
                                      .ConvertToValidNumBetween("Enter Amount", 20, 100000);
            _actionModelReference.Amount = amount;
            return this;
        }
    }
}
