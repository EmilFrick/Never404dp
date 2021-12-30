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
                    break;

                case "Withdraw":
                    break;

                case "Foregin Payment":
                    break;

                case "Foreign Transfer":
                    break;

                case "Loan":
                    break;

                case "Pay Invoice":
                    break;

                case "Transfer":
                    ib.ReceiverInquiry().AmountInquiry();
                    break;

                case "Register User":
                    RegisterUserForm();
                    return "Login";


                case "Add new account":
                    RegisterAccountForm();
                    return "User Menu";

            }

            ActiveUser.GetActiveUser().ActiveAssembledAccount.ExecuteService(am.TransactionType, am);
            Console.WriteLine($"{am.TransactionType} successful");
            Console.ReadLine();
            return "User Menu";
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

            UserRepository.GetRepository().GenerateUser(socSecurityNum, firstName, lastName, password, membershipTypes[selectedMembershipIndex - 1]); //Does not work yet:
        }

        private void RegisterAccountForm()
        {
            var accountTypes = AccountRepository.GetRepository().GetAccountType();
            UIConsole.AddField("Select Membership Type");
            var selectedMembershipIndex = UIConsole.GetSelectedOption(accountTypes).ConvertToValidNumBetween("Select Membership Type", 1, accountTypes.Count);
            var initialAmount = UIConsole.GetFieldInput("Enter Initial Amount").RequiredMaxLength("Initial Amount", 20);
            //AccountRepository.GetRepository();
            Console.WriteLine("RegisterAccountForm Fired");
            Console.ReadLine();
        }
    }
}