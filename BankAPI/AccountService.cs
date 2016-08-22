using System;
using System.Linq;
using BankAPI.Models;

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
    }
}