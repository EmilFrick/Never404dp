using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using never_404._404Accounts;
using never_404._404BankServices;
using never_404._404Users;

namespace never_404.Repository
{
    public class MenuFormGenerator : IFormGenerator
    {
        private readonly string _title;
        private readonly List<string> _options;


        public MenuFormGenerator(string title, List<string> options)
        {
            _title = title == "Logout" ? "Bank 404" : title;
            _options = options;
        }

        public string GenerateForm()
        {
            UIConsole.AddHeader(_title);
            var choice = UIConsole.GetSelectedOption(_options).ConvertToValidNumBetween("Your choice", 1, _options.Count); ;

            //If choice == "Log out". Logga isåfall ut activeUser osv.
            //var actionModel = new ActionModel();
            //ActiveUser.GetActiveUser().Accounts;
            if (_title == "Manage accounts" && _options[choice - 1] != "Back to main menu")
            {
                ActiveUser.GetActiveUser().SetActiveAccount(_options[choice - 1]);
            }



            //AssembledAccount account = AccountFactory.AssembleAccount(Convert.ToInt32(_title));

            //account.ExecuteService("Save", actionModel);


            return _options[choice - 1] == "Back to main menu" ? "User Menu" : _options[choice - 1];
        }

    }
}
