using never_404._404BankServices.BankServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Accounts
{
    public class AccountBuilder
    {
        public IAccount Account { get; set; }

        public AccountBuilder(IAccount baseAccount)
        {
            Account = baseAccount;
        }

        public AccountBuilder AddApplyInterest()
        {
            Account = new ApplyInterest(Account);
            return this;
        }

        public AccountBuilder AddDeposit()
        {
            Account = new Deposit(Account);
            return this;
        }

        public AccountBuilder AddForeignPayment()
        {
            Account = new ForeignPayment(Account);
            return this;
        }

        public AccountBuilder AddForeignTransfer()
        {
            Account = new ForeignTransfer(Account);
            return this;
        }

        public AccountBuilder AddInvestment()
        {
            Account = new Investment(Account);
            return this;
        }

        public AccountBuilder AddLoan()
        {
            Account = new Loan(Account);
            return this;
        }

        public AccountBuilder AddInvoice()
        {
            Account = new PayInvoice(Account);
            return this;
        }

        public AccountBuilder AddTransfer()
        {
            Account = new Transfer(Account);
            return this;
        }
        public AccountBuilder AddWithdraw()
        {
            Account = new Withdraw(Account);
            return this;
        }


        public IAccount FinalizeAccount()
        {
            return Account;
        }
    }
}
