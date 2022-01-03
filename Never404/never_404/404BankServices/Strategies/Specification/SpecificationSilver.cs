using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.Specification
{
    public class SpecificationSilver : ISpecificationStrategy
    {
        public decimal ConvertValue(ActionModel data)
        {
            switch (data.TransactionType)
            {
                case "Pay Invoice":
                    return MembershipRates.PayInvoiceSilver * data.Amount;
                case "Foreign Transfer":
                    return MembershipRates.ForeignTransferSilver + data.Amount;
                case "Foreign Payment":
                    return MembershipRates.ForeignPaymentSilver * data.Amount;
                default:
                    return data.Amount;
            }
        }
    }
}
