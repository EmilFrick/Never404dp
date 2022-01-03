using never_404._404Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.Specification
{
    public class SpecificationValueConverter
    {
        ISpecificationStrategy strategy;

        public decimal ConvertValue(ActionModel data)
        {
            string membership = ActiveUser.GetActiveUser().MembershipType;
            switch (membership)
            {
                case "Platinum":
                    strategy = new SpecificationPlatinum();
                    return strategy.ConvertValue(data);
                case "Gold":
                    strategy = new SpecificationGold();
                    return strategy.ConvertValue(data);
                case "Silver":
                    strategy = new SpecificationSilver();
                    return strategy.ConvertValue(data);
                default:
                    return data.Amount;
            }

        }
    }
}
