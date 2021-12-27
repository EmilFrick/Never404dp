﻿using never_404._404BankServices.BankServices;
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
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Private":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Business":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Enterprise":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Trade":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Foreign":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Student":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Senior":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Nine-To-Five":
                    ab.AddSave();
                    return ab.FinalizeAccount();

                case "Bank":
                    ab.AddSave();
                    return ab.FinalizeAccount();

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