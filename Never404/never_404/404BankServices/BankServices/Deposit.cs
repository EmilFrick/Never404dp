﻿using never_404._404Accounts;
using never_404._404BankServices.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.BankServices
{
    public class Deposit : AccountDecorator, IBankService
    {
        public Deposit(IAccount account) : base(account)
        {
            ServiceName = "Deposit";
        }

        public override void Action(params string[] data)
        {
            Console.WriteLine("I deposit money from this account.");
        }
    }
}