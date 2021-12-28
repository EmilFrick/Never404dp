using System;
using System.Linq;
using never_404._404Users;

namespace never_404.Repository
{
    public class LogInFormGenerator : IFormGenerator
    {
        private readonly UserLogInViewModel _userLogInViewModel;

        public LogInFormGenerator(UserLogInViewModel userLogInViewModel)
        {
            _userLogInViewModel = userLogInViewModel;
        }

        public string GenerateForm()
        {
            UIConsole.AddHeader("Login");

            var id = UIConsole.GetFieldInput("Enter your UID").ConvertToValidNumBetween("UID", 1);
            var password = UIConsole.GetFieldInput("Enter your password").RequiredMaxLength("Password", 20);

            _userLogInViewModel.Id = id;
            _userLogInViewModel.Password = password;

            Databasen1Entities db = new Databasen1Entities();
            try
            {
                var user = db.Users.FirstOrDefault(x => x.UserID == id && x.Password == password);
                var accounts = db.Accounts.Where(y => y.UserID == id).ToList();
                if (user == null)
                    return "Login";
                else
                {
                    var activeUser = ActiveUser.GetActiveUser();
                    activeUser.UserID = user.UserID;
                    activeUser.SSN = user.SSN;
                    activeUser.FirstName = user.FirstName;
                    activeUser.LastName = user.LastName;
                    activeUser.MembershipType = user.MembershipType;
                    activeUser.Accounts = accounts;
                    //new ActiveUser(user.UserID, user.SSN, user.FirstName, user.LastName, user.MembershipType, accounts);
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