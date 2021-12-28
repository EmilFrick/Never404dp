using never_404._404BankServices;
using never_404._404BankServices.BankServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Accounts
{
    public class AssembledAccount
    {
        public string AccountType { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public List<IBankService> AccountServices;

        public AssembledAccount(string type, int number, decimal balance, List<IBankService> services)
        {
            AccountType = type;
            AccountNumber = number;
            Balance = balance;
            AccountServices = services;
        }

        public void ExecuteService(string cmd, ActionModel data)
        {
            AccountServices.FirstOrDefault(x => x.ServiceName == cmd)?.Action(data);
        }

        public List<string> ShowServices()
        {
            return AccountServices.Select(x => x.ServiceName).ToList();
        }
    }
}
