using never_404._404Accounts;
using never_404._404BankServices;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UI();
            userInterface.ShowForm("404 Bank");
        }
    }
}
