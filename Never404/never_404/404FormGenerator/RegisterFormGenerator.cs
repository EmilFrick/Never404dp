using Microsoft.Win32;
using System;

namespace never_404.Repository
{
    public class RegisterFormGenerator : IFormGenerator
    {
        private readonly string type;

        public RegisterFormGenerator(string type)
        {
            this.type = type; 
        }

        public string GenerateForm()
        {
            switch (this.type)
{
                case "Register User":
                    return RegisterUserForm();
                case "Save":
                    return RegisterUserForm();
                default:
                    return "";
            }
        }
        public string RegisterUserForm()
        {
            UIConsole.AddHeader("Register new user");

            var firstName = UIConsole.GetFieldInput("Enter firstname").RequiredMaxLength("Firstname", 20);
            var lastName = UIConsole.GetFieldInput("Enter lastname").RequiredMaxLength("Firstname", 20);
            var password = UIConsole.GetFieldInput("Enter password").RequiredMaxLength("Password", 20);
            var socSecurityNum = UIConsole.GetFieldInput("Enter SSN").RegexSSN("Social security number");
            var membershipType = UIConsole.GetFieldInput("Enter Membership type"); //Lägg till extension för membershiptype

            UserRepository.GetRepository().GenerateUser(socSecurityNum, firstName, lastName, password, membershipType); //Does not work yet:

            return "Login";
        }
    }
}