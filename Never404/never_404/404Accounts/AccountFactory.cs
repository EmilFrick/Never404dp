using never_404._404BankServices.BankServices;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Accounts
{
    public static class AccountFactory
    {
        public static AssembledAccount AssembleAccount(int accountNumber)
        {
            //Step 1 - Get Account from DB
            Account account = AccountRepository.GetRepository().GetAccount(accountNumber);
            //Step 2 - Build account model (decorated)
            IAccount decoratedAccount = BuildAccount(account);
            //Step 3 - Listing Functionality
            List<IBankService> listAllAccountServices = BundleServices(decoratedAccount);
            //Step 4 - Building assembledAccount
            return new AssembledAccount(decoratedAccount.AccountType, decoratedAccount.AccountNumber, decoratedAccount.Balance, listAllAccountServices);
        }


        public static IAccount BuildAccount(Account account)
        {
            IAccount baseAccount = new AccountModel(account.AccountType, account.AccountNumber, account.Balance.Value);
            AccountBuilder ab = new AccountBuilder(baseAccount);
            switch (account.AccountType)
            {
                case "Saving":
                    return ab.AddApplyInterest().AddDeposit().AddForeignPayment().AddForeignTransfer().AddInvestment().AddInvoice().AddLoan().AddTransfer().AddWithdraw().FinalizeAccount();

                case "Private":
                    return ab.AddDeposit().AddWithdraw().AddInvoice().AddTransfer().FinalizeAccount();

                case "Business":
                    return ab.AddDeposit().AddWithdraw().AddInvoice().AddLoan().FinalizeAccount();

                case "Enterprise":
                    return ab.AddDeposit().AddInvoice().AddForeignPayment().AddForeignTransfer().AddInvestment().FinalizeAccount();

                case "Trade":
                    return ab.AddDeposit().AddInvestment().FinalizeAccount();

                case "Foreign":
                    return ab.AddDeposit().AddForeignPayment().AddForeignTransfer().FinalizeAccount(); ;

                case "Student":
                    return ab.AddDeposit().AddWithdraw().FinalizeAccount();

                case "Senior":
                    return ab.AddWithdraw().FinalizeAccount();

                case "Nine-To-Five":
                    return ab.AddDeposit().FinalizeAccount();

                case "Bank":
                    return ab.AddApplyInterest().AddDeposit().AddForeignPayment().AddForeignTransfer().AddInvestment().AddInvoice().AddLoan().AddTransfer().AddWithdraw().FinalizeAccount();

                default:
                    return baseAccount;
            }
        }

        public static List<IBankService> BundleServices(IAccount account)
        {
            IBankService accountServices = account as IBankService;
            List<IBankService> listAllAccountServices = new List<IBankService>();
            accountServices?.GetServices(listAllAccountServices);
            return listAllAccountServices;
        }
    }
}
