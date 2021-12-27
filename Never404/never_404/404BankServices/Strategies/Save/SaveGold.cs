using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.Save
{
    public class SaveGold : IMembershipStrategy
    {
        public void Action(params string[] data)
        {
            Console.WriteLine("I Save Gold");
        }
    }
}
