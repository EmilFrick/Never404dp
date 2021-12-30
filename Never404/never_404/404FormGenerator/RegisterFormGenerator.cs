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
                    return RegisterUserForm();

                case "Add new account":
                    return RegisterAccountForm();
            }
            
                ActiveUser.GetActiveUser().ActiveAssembledAccount.ExecuteService(am.TransactionType, am);
                Console.WriteLine($"{am.TransactionType} successful");
                Console.ReadLine();
                return "User Menu";
        }


        private string RegisterPayInvoiceForm()
        {
            //PayInvoice
            //Account number to Pay invoice:
            //Amount:
            UIConsole.AddHeader("Invoice");
            Console.WriteLine("Paying Invoice Fired");
            Console.ReadLine();
            return "User Menu";
        }

        private string RegisterLoanForm()
        {
            //Loan
            //Amount to borrow:
            UIConsole.AddHeader("Loan");
            Console.WriteLine("Taking a Loan Fired");
            Console.ReadLine();
            return "User Menu";
        }

        private string RegisterForeignTransferForm()
        {
            //ForeignTransfer
            //Foreginaccount number:
            //Amount: 
            //Message:
            UIConsole.AddHeader("Foreign Transfer");
            Console.WriteLine("Foreign Transfer fired");
            Console.ReadLine();
            return "User Menu";
        }

        private string RegisterForeignPaymentForm()
        {
            //ForeginPayment
            //Foreginaccount number:
            //Amount: 
            //Message:
            UIConsole.AddHeader("Foreign Payment");
            Console.WriteLine("Foreign Payment fired");
            Console.ReadLine();
            return "User Menu";
        }

        private string RegisterWithdrawtForm()
        {
            //Withdraw
            //Accountnumber to deposit:
            //amount:
            UIConsole.AddHeader("Withdraw");
            Console.WriteLine("Withdraw Fired");
            Console.ReadLine();
            return "User Menu";
        }

        private string RegisterDepositForm()
        {
            //Deposit
            //Accountnumber to deposit:
            //amount:
            UIConsole.AddHeader("Deposit");
            Console.WriteLine("Withdraw Fired");
            Console.ReadLine();
            return "User Menu";
        }

        private string RegisterUserForm()
        {
            UIConsole.AddHeader("Register New User");

            var firstName = UIConsole.GetFieldInput("Enter firstname").RequiredMaxLength("Firstname", 20);
            var lastName = UIConsole.GetFieldInput("Enter lastname").RequiredMaxLength("Firstname", 20);
            var password = UIConsole.GetFieldInput("Enter password").RequiredMaxLength("Password", 20);
            var socSecurityNum = UIConsole.GetFieldInput("Enter SSN").RegexSSN("Social security number");

            var membershipTypes = UserRepository.GetRepository().GetMebershipType();
            UIConsole.AddField("Select Membership Type");
            var selectedMembershipIndex = UIConsole.GetSelectedOption(membershipTypes).ConvertToValidNumBetween("Select Membership Type", 1, membershipTypes.Count);

            UserRepository.GetRepository().GenerateUser(socSecurityNum, firstName, lastName, password, membershipTypes[selectedMembershipIndex - 1]); //Does not work yet:
            return "Login";
        }

        private string RegisterAccountForm()
        {
            UIConsole.AddHeader("Register New Account");
            Console.WriteLine("RegisterAccountForm Fired");
            Console.ReadLine();
            return "User Menu";
        }
    }
}