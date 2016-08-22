using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BankAPI.Models;
using Moq;

namespace BankAPI.Tests
{
    public static class ContextService
    {
        public static Mock<BankAPIContext> GetContext()
        {
            var userMockSet = CreateUserMockSet();

            var mockContext = new Mock<BankAPIContext>();

            mockContext.Setup(c => c.Users).Returns(userMockSet.Object);

            return mockContext;
        }

        private static Mock<DbSet<User>> CreateUserMockSet()
        {
            var data = new List<User>
            {
                new User
                {
                    Name = "Test",
                    Id= 1,
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
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();

            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
    }
}