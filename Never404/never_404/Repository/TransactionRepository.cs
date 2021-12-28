﻿using never_404._404Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404.Repository
{
    public class TransactionRepository
    {
        private static TransactionRepository transactionRepo;

        public TransactionRepository()
        {

        }
        public static TransactionRepository GetRepository()
        {
            if (transactionRepo == null)
            {
                transactionRepo = new TransactionRepository();
            }
            return transactionRepo;
        }

        public Account GetTransaction(int accountNumber)
        {
            BankDBContext db = new BankDBContext();
            return db.Account.Where(x => x.AccountNumber == accountNumber).FirstOrDefault();
        }
        public  void CreateTransaction(Transaction transaction)
        {
            BankDBContext db = new BankDBContext();
            db.Account.FirstOrDefault(x => x.AccountNumber == transaction.ReceiverAccount).Balance += transaction.Amount;
            db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= transaction.Amount;
            db.Transaction.Add(transaction);
            db.SaveChanges();
        }
        public  void CreateTransaction(Transaction transaction, decimal fee)
        {
            BankDBContext db = new BankDBContext();
            var bankFee = (transaction.Amount * fee) - transaction.Amount;
            db.Account.FirstOrDefault(x => x.AccountNumber == transaction.ReceiverAccount).Balance += transaction.Amount;
            db.Account.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount).Balance -= (transaction.Amount * fee);
            db.Account.FirstOrDefault(x => x.AccountNumber == 512885004).Balance += bankFee;
            db.Transaction.Add(transaction);
            db.SaveChanges();
        }
    }
}