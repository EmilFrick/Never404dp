using System;
using System.Collections.Generic;
using System.Text;
using never_404._404Users;
using System.Linq;

namespace never_404.Repository
{
    public class MenuOptionsGenerator
    {
        public List<string> GetMenuOptions(string type)
        {
            var kristoffer = ActiveUser.GetActiveUser();
            switch (type)
            {
                case "404 Bank":
                case "Logout":
                    return new List<string> { "Login", "Register User", "Exit" };
                case "User Menu":
                    return new List<string> { "Personal details", "Manage accounts", "Add new account", "Logout" };
                case "Manage accounts":
                    return kristoffer.Accounts.Select(x => x.AccountType).ToList();
                default:
                    return new List<string> { "Back" };
            }
        }
    }
}
