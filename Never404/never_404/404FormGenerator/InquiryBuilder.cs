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
        
        public void ReceiverInquiry()
        {
            int receiverAccountNumber = UIConsole.GetFieldInput("Enter account number you wish to transer to:").ReceiverAccountValidation();
            string receivername;
            Account result = AccountRepository.GetRepository().GetAccount(receiverAccountNumber);
            if (result == null)
            {
                receiverAccountNumber = StoredAccounts.GetOthers().AccountNumber;
                receivername = UIConsole.GetFieldInput("Enter Receiver Name").RequiredMaxLength("Receiver Name", 20);
            }
            else
            {
                receiverAccountNumber = result.AccountNumber;
                User resultUserDetails = UserRepository.GetRepository().GetUser(result.UserID.GetValueOrDefault());
                receivername = $"{resultUserDetails.FirstName} {resultUserDetails.LastName}";
            }

            _actionModelReference.ReceiverAccount = receiverAccountNumber;
            _actionModelReference.ReceiverLabel = receivername;
        }
    }
}

//int sender = ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber;
//string receiverStr; //cant transfer to same account you're transfering from. convert to Into
//int receiver = 5;
//string amountStr = UIConsole.GetFieldInput("Enter Amount:");
//decimal amount = Convert.ToDecimal(amountStr);
//string transactionType = "Transfer";

//if (AccountRepository.GetRepository().GetAccount(receiver) == null)
//{
//    int othersAccount = 512885027;
//    receiver = othersAccount;
//}