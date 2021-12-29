using never_404._404Accounts;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404Users
{
    public class ActiveUser
    {

        private static ActiveUser _activeUser;


        public int UserID { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MembershipType { get; set; }
        public AssembledAccount ActiveAssembledAccount { get; set; }
        public List<AssembledAccount> AssembledAccounts { get; set; }

        private ActiveUser()
        {
            AssembledAccounts = new List<AssembledAccount>();
        }
        public void GetUserAccounts()
        {
            List<Account> accountList = AccountRepository.GetRepository().GetAccounts(this.UserID);
            foreach (Account a in accountList)
            {
                AssembledAccount assembleAccount = AccountFactory.AssembleAccount(a.AccountNumber);
                this.AssembledAccounts.Add(assembleAccount);
            }
        }
        public static ActiveUser GetActiveUser()
        {
            if (_activeUser == null)
            {
                _activeUser = new ActiveUser();
            }

            return _activeUser;
        }
        public ActiveUser InitiateActiveUser(int userid, string ssn, string firstname, string lastname, string membership)
        {
            SetActiveUser(userid, ssn, firstname, lastname, membership);
            GetUserAccounts();
            return _activeUser;
        }
        public void SetActiveUser(int userid, string ssn, string firstname, string lastname, string membership)
        {
            this.UserID = userid;
            this.SSN = ssn;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.MembershipType = membership;
        }
        public List<string> GetStrAccounts()
        {
            List<string> strAccount = new List<string>();
            foreach (AssembledAccount a in this.AssembledAccounts)
            {
                strAccount.Add(a.AccountNumber.ToString());
            }
            return strAccount;
        }
        public void SetActiveAccount(string accountNumber)
        {
            this.ActiveAssembledAccount = this.AssembledAccounts.Where(x => x.AccountNumber == Convert.ToInt32(accountNumber)).FirstOrDefault();
        }
        public void UserLogout()
        {
            _activeUser = null;
        }
    }
}
