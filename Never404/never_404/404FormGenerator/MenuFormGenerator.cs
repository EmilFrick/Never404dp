using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace never_404.Repository
{
    public class MenuFormGenerator : IFormGenerator
    {
        private readonly string _title;
        private readonly string _prevType;
        private readonly List<string> _options;


        public MenuFormGenerator(string prevType, string title, List<string> options)
        {
            _title = title == "Logout" ? "Bank 404" : title;
            _prevType = prevType;
            _options = options;
        }

        public string GenerateForm()
        {
            UIConsole.AddHeader(_title);
            var choice = UIConsole.GetSelectedOption(_options).ConvertToValidNumBetween("Your choice", 1, _options.Count); ;

            //If choice == "Log out". Logga isåfall ut activeUser osv.

            

            return _options[choice - 1] == "Back" ? _prevType : _options[choice - 1];
        }

    }
}
