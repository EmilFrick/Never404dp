using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices
{
    public interface ISpecificationStrategy
    {
        decimal ConvertValue(ActionModel data);
    }
}
