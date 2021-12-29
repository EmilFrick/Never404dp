using System;
using System.Collections.Generic;
using never_404;
using never_404._404Users;

namespace never_404.Repository
{
    public static class FormFactory
    {

        public static IFormGenerator GetFormGenerator(string type, string prevType)
        {
            switch (type)
            {
                case "Login":
                    return new LogInFormGenerator();
                case "Transfer":
                case "Invoice":
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
                    return new MenuFormGenerator(prevType, type, MenuOptionsGenerator.GetMenuOptions(type));
            }
        }
    }
}
