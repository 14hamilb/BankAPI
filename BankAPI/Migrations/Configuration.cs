using System.Collections.Generic;
using System.Data.Entity.Migrations;
using BankAPI.Models;

namespace BankAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BankAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BankAPIContext context)
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
                },
                Preferences = new Preferences
                {
                    Color = Color.Grey,
                    FontSize = FontSize.Medium,
                    RememberMe = true
                }
            };
            context.Users.Add(user);
        }
    }
}