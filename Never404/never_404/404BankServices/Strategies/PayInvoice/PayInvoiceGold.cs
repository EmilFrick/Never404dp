﻿using never_404._404Transaction;
using never_404.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies.PayInvoice
{
    public class PayInvoiceGold : IMembershipStrategy
    {
        public void Action(ActionModel data)
        {
            decimal goldfee = 0.05m;
            Transaction newTransaction = new TransactionModel(data.SenderAccount, data.ReceiverAccount, data.Amount, data.TransactionType).GenerateTransaction();
            TransactionRepository.GetRepository().CreateTransaction(newTransaction, goldfee);
            Console.WriteLine("I Pay Gold");
        }
    }
}
