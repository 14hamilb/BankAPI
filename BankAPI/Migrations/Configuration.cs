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
                        Balance = 200000.00,
                        GUID = "46BE7CE2-4C0B-4F4D-B0B1-F3604F5BC3C8"
                    },
                    new Account
                    {
                        Name = "Credit",
                        Balance = -10000.00,
                        GUID = "1227F3F0-4171-4A58-9820-92E7DB2F29DE"
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