using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using never_404._404Users;
using never_404.Repository;

namespace never_404._404FormGenerator
{
    public class PersonalDetailsFormGenerator : IFormGenerator
    {
        public string GenerateForm()
        {
            var activeUser = ActiveUser.GetActiveUser();
            
            UIConsole.AddHeader("Personal details");
            UIConsole.AddFields($"User ID: {activeUser.UserID}",
                                $"Name: {activeUser.FirstName} {activeUser.LastName}",
                                $"Social security number: {activeUser.SSN}",
                                $"Membership type: {activeUser.MembershipType}",
                                $"Number of accounts: {activeUser.AssembledAccounts.Count}",
                                $"Total balance: {activeUser.AssembledAccounts.Sum(account => account.Balance)}"
                                );

            return "User Menu";
        }
    }
}
