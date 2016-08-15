using System.Collections.Generic;
using System.Data.Entity.Migrations;
using BankAPI.Models;

namespace BankAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.BankAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.BankAPIContext context)
        {
            var user = new User
            {
                Name = "Test",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        Name = "Savings",
                        Balance = 200000.00
                    },
                    new Account
                    {
                        Name = "Credit",
                        Balance = -10000.00
                    }
                }
            };
            context.Users.Add(user);
        }
    }
}