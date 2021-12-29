using System;
using System.Collections.Generic;
using System.Text;
using never_404._404Users;
using System.Linq;

namespace never_404.Repository
{
    public static class MenuOptionsGenerator
    {
        public static List<string> GetMenuOptions(string type)
        {
            switch (type)
            {
                case "404 Bank":
                case "Logout":
                    return new List<string> { "Login", "Register User", "Exit" };
                case "User Menu":
                    return new List<string> { "Personal details", "Manage accounts", "Add new account", "Logout" };
                case "Manage accounts":
                    return ActiveUser.GetActiveUser().GetStrAccounts();
                //case "Inside account":
                //    return ActiveUser.GetActiveUser().ActiveAccount.Show...
                default:
                    return new List<string> { "Back" };
            }
        }

        private static List<string> GetAccountTypes()
        {
            var accountTypes = ActiveUser.GetActiveUser().Accounts.Select(x => x.AccountType + " Account $" + x.Balance).ToList();
            accountTypes.Add("Back");
            return accountTypes;
        }
    }
}
