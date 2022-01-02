using Microsoft.Win32;
using never_404._404BankServices;
using never_404._404BankServices.BankServices;
using never_404._404FormGenerator;
using never_404._404Users;
using System;

namespace never_404.Repository
{
    public class RegisterFormGenerator : IFormGenerator
    {
        private readonly string type;

        public RegisterFormGenerator(string type)
        {
            this.type = type;
        }

        public string GenerateForm()
        {
            ActionModel am = new ActionModel();
            InquiryBuilder ib = new InquiryBuilder(am);
            am.TransactionType = type;
            UIConsole.AddHeader(type);
            
            switch (this.type)
            {
                case "Deposit":
                case "Loan":
                    ib.CreditAmountInquiry();
                    ExecuteBankService(am);
                    return "User Menu";
                case "Withdraw":
                    ib.DebitAmountInquiry();
                    ExecuteBankService(am);
                    return "User Menu";
                case "Foregin Payment":
                case "Foreign Transfer":
                case "Pay Invoice":
                    ib.OtherReceiverInquiry().DebitAmountInquiry();
                    ExecuteBankService(am);
                    return "User Menu";
                case "Transfer":
                    ib.ReceiverInquiry().DebitAmountInquiry();
                    ExecuteBankService(am);
                    return "User Menu";
                case "Register User":
                    RegisterUserForm();
                    return "Login";
                case "Add new account":
                    RegisterAccountForm();
                    return "User Menu";
                default:
                    return "Form not implemented";
            }
        }

        private void ExecuteBankService(ActionModel am)
        {
            ActiveUser.GetActiveUser().ActiveAssembledAccount.ExecuteService(am.TransactionType, am);
            Console.WriteLine($"{am.TransactionType} successful");
            Console.ReadLine();
        }

        private void RegisterUserForm()
        {
            var firstName = UIConsole.GetFieldInput("Enter firstname").RequiredMaxLength("Firstname", 20);
            var lastName = UIConsole.GetFieldInput("Enter lastname").RequiredMaxLength("Firstname", 20);
            var password = UIConsole.GetFieldInput("Enter password").RequiredMaxLength("Password", 20);
            var socSecurityNum = UIConsole.GetFieldInput("Enter SSN").RegexSSN("Social security number");

            var membershipTypes = UserRepository.GetRepository().GetMebershipType();
            UIConsole.AddField("Select Membership Type");
            var selectedMembershipIndex = UIConsole.GetSelectedOption(membershipTypes).ConvertToValidNumBetween("Select Membership Type", 1, membershipTypes.Count);

            UserRepository.GetRepository().CreateUser(socSecurityNum, firstName, lastName, password, membershipTypes[selectedMembershipIndex - 1]); //Does not work yet:
        }

        private void RegisterAccountForm()
        {
            var userID = ActiveUser.GetActiveUser().UserID;
            
            var accountTypes = AccountRepository.GetRepository().GetAccountType();
            UIConsole.AddField("Select Membership Type");
            var selectedAccountTypeIndex = UIConsole.GetSelectedOption(accountTypes).ConvertToValidNumBetween("Select Membership Type", 1, accountTypes.Count);
            
            decimal initialAmount = UIConsole.GetFieldInput("Enter Initial Amount").ConvertToValidNumBetween("Initial Amount", 20, 10000);
            
            Account a = AccountRepository.GetRepository().CreateAccount(userID, accountTypes[selectedAccountTypeIndex - 1], initialAmount);
            Console.WriteLine($"Your {a.AccountType} account was successfully created!");
            Console.ReadLine();
        }
    }
}