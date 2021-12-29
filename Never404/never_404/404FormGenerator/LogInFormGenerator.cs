using System;
using System.Linq;
using never_404._404Users;

namespace never_404.Repository
{
    public class LogInFormGenerator : IFormGenerator
    {


        public string GenerateForm()
        {
            UIConsole.AddHeader("Login");

            var id = UIConsole.GetFieldInput("Enter your UID").ConvertToValidNumBetween("UID", 1);
            var password = UIConsole.GetFieldInput("Enter your password").RequiredMaxLength("Password", 20);


            BankDBContext db = new BankDBContext();
            try
            {
                var user = db.User.FirstOrDefault(x => x.UserID == id && x.Password == password);
                var accounts = db.Account.Where(y => y.UserID == id).ToList();
                if (user == null)
                    return "Login";
                else
                {
                    var activeUser = ActiveUser.GetActiveUser().InitiateActiveUser(user.UserID, user.SSN, user.FirstName, user.LastName, user.MembershipType);
                    return "User Menu";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Kolla mot databasen om användaren finns.

            //Om det lyckas:
            return "Login";
        }
    }
}