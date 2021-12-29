using Microsoft.Win32;
using never_404._404BankServices;
using never_404._404BankServices.BankServices;
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
                    return RegisterTransferForm();

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
         
            //Declaring all vars for transaction
            int sender = ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber;
            string receiverStr = UIConsole.GetFieldInput("Enter account you wish to transer to:"); //cant transfer to same account you're transfering from. convert to Into
            int receiver = Convert.ToInt32(receiverStr);
            string amountStr = UIConsole.GetFieldInput("Enter Amount:");
            decimal amount = Convert.ToDecimal(amountStr);
            string transactionType = "Transfer";

            if (AccountRepository.GetRepository().GetAccount(receiver) == null)
            {
                int othersAccount = 512885027;
                receiver = othersAccount;
            }

            //Creating Action Model
            ActionModel am = new ActionModel();
            am.SenderAccount = sender;
            am.ReceiverAccount = receiver;
            am.Amount = amount;
            am.TransactionType = transactionType;

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
            return "User Menu";
        }

        private string RegisterUserForm()
        {
            UIConsole.AddHeader("Register New User");

            var firstName = UIConsole.GetFieldInput("Enter firstname").RequiredMaxLength("Firstname", 20);
            var lastName = UIConsole.GetFieldInput("Enter lastname").RequiredMaxLength("Firstname", 20);
            var password = UIConsole.GetFieldInput("Enter password").RequiredMaxLength("Password", 20);
            var socSecurityNum = UIConsole.GetFieldInput("Enter SSN").RegexSSN("Social security number");
            var membershipType = UIConsole.GetFieldInput("Enter Membership type"); //Lägg till extension för membershiptype
            UserRepository.GetRepository().GenerateUser(socSecurityNum, firstName, lastName, password, membershipType); //Does not work yet:
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