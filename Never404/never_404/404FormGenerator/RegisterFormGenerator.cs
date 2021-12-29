﻿using Microsoft.Win32;
using never_404._404BankServices.BankServices;
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
            //Account number to transfer:
            //Amount:
            throw new NotImplementedException();
        }

        private string RegisterPayInvoiceForm()
        {
            //PayInvoice
            //Account number to Pay invoice:
            //Amount:
            throw new NotImplementedException();
        }

        private string RegisterLoanForm()
        {
            //Loan
            //Amount to borrow:
            throw new NotImplementedException();
        }

        private string RegisterForeignTransferForm()
        {
            //ForeignTransfer
            //Foreginaccount number:
            //Amount: 
            //Message:
            throw new NotImplementedException();
        }

        private string RegisterForeignPaymentForm()
        {
            //ForeginPayment
            //Foreginaccount number:
            //Amount: 
            //Message:
            throw new NotImplementedException();
        }

        private string RegisterWithdrawtForm()
        {
            //Withdraw
            //Accountnumber to deposit:
            //amount:
            throw new NotImplementedException();
        }

        private string RegisterDepositForm()
        {
            //Deposit
            //Accountnumber to deposit:
            //amount:
            throw new NotImplementedException();
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