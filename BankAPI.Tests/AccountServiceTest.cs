using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAPI.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public void AccountService_CreateAccount_CreateAccountReturnsValidAccount()
        {
            var mockContext = ContextService.GetContext().Object;

            var user = mockContext.Users.FirstOrDefault(u => u.Id == 1);

            var accountService = new AccountService(mockContext);
            var account = accountService.CreateAccount("Custom Name", 1);

            Assert.IsTrue(user.Accounts.Any(a => a.Name == "Custom Name"));
            Assert.AreEqual(user.Accounts.Count(), 3);
        }
    }
}