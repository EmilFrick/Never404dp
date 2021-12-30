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
            ActionModel amRef = new ActionModel();
            InquiryBuilder ib = new InquiryBuilder(amRef);

            switch (this.type)
            {
                case "Deposit":
                    return RegisterDepositForm();

                case "Withdraw":
                    return RegisterWithdrawtForm();

                case "Foregin Payment":
                    return RegisterForeignPaymentForm();

                case "Foreign Transfer":
                    return RegisterForeignTransferForm();

                case "Loan":
                    return RegisterLoanForm();

                case "Pay Invoice":
                    return RegisterPayInvoiceForm();

                case "Transfer":
                    amRef.TransactionType = "Transfer";
                    UIConsole.AddHeader(amRef.TransactionType);
                    ActiveUser.GetActiveUser().ActiveAssembledAccount.ExecuteService(amRef.TransactionType, amRef);
                    return "User Menu";

                case "Register User":
                    return RegisterUserForm();

                case "Save":
                    return RegisterUserForm();

                case "Add new account":
                    return RegisterAccountForm();

                default:
                    return "Form not implemented!";
            }
        }



        private string RegisterTransferForm()
        {
            UIConsole.AddHeader("Transfer");
            ActionModel am = new ActionModel();
         //   UIConsole.GetFieldInput("Enter account number you wish to transer to:")     //Receiver
         //            .ReceiverInquiry(am);
         //   UIConsole.GetFieldInput("Enter account number you wish to transer to:")     //Receiver
         //.ReceiverInquiry(am);


            //Declaring all vars for transaction


            //Creating Action Model
            //am.SenderAccount = sender;
            //am.ReceiverAccount = receiver;
            //am.Amount = amount;
            //am.TransactionType = transactionType;

            //Executing transaction
            ActiveUser.GetActiveUser().ActiveAssembledAccount.ExecuteService("Transfer", am);

            
            Console.WriteLine("Transfer succesful");
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