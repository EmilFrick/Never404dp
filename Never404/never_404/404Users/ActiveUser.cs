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
        public void GetUserAccounts(int userid)
        {
            Accounts = Repository.AccountRepository.GetRepository().GetAccounts(userid);
        }
        public ActiveUser(int userid, string ssn, string firstName, string lastName, string membership, List<Account> accounts)
        {
            this.UserID = userid;
            this.SSN = ssn;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MembershipType = membership;
            this.Accounts = accounts;
        }
        public static ActiveUser GetActiveUser()
        {
            if (_activeUser == null)
            {
                _activeUser = new ActiveUser();
            }

            return _activeUser;
        }
        
    }
}
