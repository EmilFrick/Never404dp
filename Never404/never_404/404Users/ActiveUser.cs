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

        public string membership;
        private ActiveUser()
        {

        }

        public static ActiveUser GetActiveUser()
        {
            if (_activeUser == null)
            {
                return new ActiveUser();
            }

            return _activeUser;
        }
    }
}
