using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using never_404;
using never_404._404FormGenerator;
using never_404._404Users;

namespace never_404.Repository
{
    public static class FormFactory
    {

        public static IFormGenerator GetFormGenerator(string type)
        {
            switch (type)
            {
                case "Login":
                    return new LogInFormGenerator();
                case "Personal details":
                    return new PersonalDetailsFormGenerator();
                case "Show Transactions":
                    return new TransactionsFormGerenator();
                case "Transfer":
                case "Pay Invoice":
                case "Loan":
                case "Foreign Transfer":
                case "Foreign Payment":
                case "Withdraw":
                case "Deposit":
                case "Add new account":
                case "Save":
                case "Create Transaction":
                case "Create Account":
                case "Register User":
                    return new RegisterFormGenerator(type);

                default:
                    return new MenuFormGenerator(type, MenuOptionsGenerator.GetMenuOptions(type));
            }
        }
    }
}
