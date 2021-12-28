using System;
using System.Collections.Generic;
using never_404;

namespace never_404.Repository
{
    public static class FormFactory
    {
        
        public static IFormGenerator GetFormGenerator(string type, string prevType)
        {
            var menuOptionsGenerator = new MenuOptionsGenerator();
            switch (type)
            {
                case "Login":
                    return new LogInFormGenerator(new UserLogInViewModel());

                case "Register User":
                    return new RegisterFormGenerator(new UserRegisterViewModel());

                default:
                    return new MenuFormGenerator(type,prevType, menuOptionsGenerator.GetMenuOptions(type));
            }
        }
    }
}
