using System;
using BankAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAPI.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void UserService_TestUserUpdate_ShouldReturnValid()
        {
            var user = new User {Name = "Not Updated"};
            var userService = new UserService();

            user = userService.TestUserUpdate(user);

            Assert.AreEqual(user.Name, "Updated");
            Assert.AreNotEqual(user.Name, "Not Updated");
        }
    }
}
