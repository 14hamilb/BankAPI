using System;
using System.Collections.Generic;
using System.Linq;
using BankAPI.Models;
using BankAPI.Models.JSON;

namespace BankAPI
{
    public class AccountService
    {
        private readonly BankAPIContext _context;

        public AccountService(BankAPIContext context)
        {
            // Set the private context to the context passed in the constructor
            _context = context;
        }

        public Account CreateAccount(string AccountName, int UserId)
        {
            if (string.IsNullOrEmpty(AccountName))
            {
                AccountName = "Default Account Name";
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == UserId);

            if (user == null) return null;

            var account = new Account
            {
                Balance = 0d,
                GUID = Convert.ToString(Guid.NewGuid()),
                Name = AccountName
            };

            user.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }

        public List<Account> GetAccounts(int UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == UserId);

            if (user == null) return null;

            return user.Accounts.ToList();
        }

        public bool DeleteAccount(int AccountId, int UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == UserId);

            if (user == null) return false;

            var account = user.Accounts.FirstOrDefault(a => a.Id == AccountId);

            if (account == null) return false;

            user.Accounts.Remove(account);

            _context.SaveChanges();

            return true;
        }

        public Transaction PerformTransaction(TransferRequest transferRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == transferRequest.UserId);

            if (user == null) return null;

            var fromAccount = user.Accounts.FirstOrDefault(a => a.GUID == transferRequest.FromAccountGUID);

            if (fromAccount == null) return null;

            var toAccount = user.Accounts.FirstOrDefault(a => a.GUID == transferRequest.ToAccountGUID);

            if (toAccount == null) return null;

            if (fromAccount.Balance < transferRequest.TransferAmount)
                throw new ApplicationException("Insufficient Funds!");

            fromAccount.Balance -= transferRequest.TransferAmount;
            toAccount.Balance += transferRequest.TransferAmount;

            var transaction = new Transaction
            {
                Timestamp = DateTime.Now,
                UserId = transferRequest.UserId
            };

            user.Transactions.Add(transaction);

            _context.SaveChanges();

            return transaction;
        }
    }
}