using never_404._404Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public interface IBankService
    {
        string ServiceName { get; set; }
        void Action(ActionModel data);
        void GetServices(List<IBankService> list);
    }
}
