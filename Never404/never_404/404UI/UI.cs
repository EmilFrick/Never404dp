using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using never_404._404Users;

namespace never_404.Repository
{
    public class UI
    {
        public void ShowForm(string formType)
        {
            while (formType != "Exit")
            {
                IFormGenerator formGenerator = FormFactory.GetFormGenerator(formType);
                formType = formGenerator.GenerateForm();
            }
        }
    }
}
