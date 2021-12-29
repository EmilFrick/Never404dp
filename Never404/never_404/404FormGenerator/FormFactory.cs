using System;
using System.Collections.Generic;
using never_404;
using never_404._404Users;

namespace never_404.Repository
{
    public static class FormFactory
    {
        
        public static IFormGenerator GetFormGenerator(string type, string prevType)
        {
            switch (type)
            {
                case "Login":
                    return new LogInFormGenerator();

                case "Register User":
                    return new RegisterFormGenerator(new UserRegisterViewModel());

                default:
                    return new MenuFormGenerator(prevType, type, MenuOptionsGenerator.GetMenuOptions(type));
            }
        }
    }
}
