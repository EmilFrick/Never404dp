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
            var prevType = "";
            while (formType != "Exit")
            {
                IFormGenerator formGenerator = FormFactory.GetFormGenerator(formType, prevType);
                prevType = formType;
                formType = formGenerator.GenerateForm();
            }
        }
    }
}
