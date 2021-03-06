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
                    ActiveUser.GetActiveUser().UserLogout();
                    return new List<string> { "Login", "Register User", "Exit" };
                case "User Menu":
                    return new List<string> { "Personal details", "Manage accounts", "Add new account", "Logout" };
                //case "Register User":
                //    return 
                case "Manage accounts":
                    return ActiveUser.GetActiveUser().GetStrAccounts().AddOptions("Back to main menu");
                default:
                    if (ActiveUser.GetActiveUser().UserAccountExist(type))
                    {
                        return ActiveUser.GetActiveUser().ActiveAssembledAccount.ShowServices().AddOptions("Show Transactions", "Back to main menu");
                    }
                    else
                    {
                        return new List<string> { "Back to main menu" };
                    }
            }
        }

        private static List<string> GetAccountTypes()
        {
            var accountTypes = ActiveUser.GetActiveUser().AssembledAccounts.Select(x => x.AccountType + " Account $" + x.Balance).ToList();
            accountTypes.Add("Back");
            return accountTypes;
        }
    }
}
