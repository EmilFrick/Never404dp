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
        public List<Account> Accounts { get; set; }

        private ActiveUser()
        {
            Accounts = new List<Account>();
        }
        public void GetUserAccounts()
        {
            Accounts = AccountRepository.GetRepository().GetAccounts(this.UserID);
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
            foreach (Account a in this.Accounts)
            {
                strAccount.Add(a.AccountNumber.ToString());
            }
            return strAccount;
        }

    }
}
