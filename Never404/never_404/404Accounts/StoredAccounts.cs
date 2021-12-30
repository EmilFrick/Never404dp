using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Accounts
{
    static class StoredAccounts
    {
        private static Account Bank;
        private static Account Others;

        public static Account GetBank()
        {
            if (Bank == null)
            {
                Others = AccountRepository.GetRepository().GetAccount(512885004);

            }
            return Others;
        }

        public static Account GetOthers()
        {
            if (Others == null)
            {
                Others = AccountRepository.GetRepository().GetAccount(512885027);

            }
            return Others;
        }
    }
}
