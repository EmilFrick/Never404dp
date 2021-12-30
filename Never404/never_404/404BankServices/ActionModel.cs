using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices
{
    public class ActionModel
    {
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public int SenderLabel { get; set; }
        public int ReceiverLabel { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }

    }
}
