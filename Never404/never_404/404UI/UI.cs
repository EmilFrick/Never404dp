using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404.Repository
{
    public class UI
    {
        public void ShowForm(string formType)
        {
            while (formType != "Exit")
            {
                var prevType = "";
                IFormGenerator formGenerator = FormFactory.GetFormGenerator(formType, prevType);
                prevType = formType;
                formType = formGenerator.GenerateForm();
            }
        }
    }
}
