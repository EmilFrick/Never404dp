using System;

namespace never_404.Repository
{
    public class RegisterFormGenerator : IFormGenerator
    {
        private readonly UserRegisterViewModel _userRegisterViewModel;

        public RegisterFormGenerator(UserRegisterViewModel userRegisterViewModel)
        {
            _userRegisterViewModel = userRegisterViewModel;
        }

        public string GenerateForm()
        {

            UIConsole.AddHeader("Register new user");

            var firstName = UIConsole.GetFieldInput("Enter firstname").RequiredMaxLength("Firstname", 20);
            var lastName = UIConsole.GetFieldInput("Enter lastname").RequiredMaxLength("Firstname", 20);
            var password = UIConsole.GetFieldInput("Enter password").RequiredMaxLength("Password", 20);
            var socSecurityNum = UIConsole.GetFieldInput("Enter SSN").RegexSSN("Social security number");
            var membershipType = UIConsole.GetFieldInput("Enter Membership type"); //Lägg till extension för membershiptype


            UserRepository.CreateUser(UserRepository.GenerateUser(socSecurityNum, firstName, lastName, password, membershipType));

            //Lägg till i databasen...

            return "User Menu";
        }
    }
}