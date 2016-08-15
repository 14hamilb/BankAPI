using System;
using System.Collections.Generic;
using System.Linq;
using BankAPI.Models;

namespace BankAPI
{
    public class UserService
    {
        private BankAPIContext _context { get; }

        public UserService(BankAPIContext context)
        {
            _context = context;
        }

        public UserService() {}

        public User UpdateUser(User updateUser, int userId)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
                throw new NullReferenceException("User not found.");

            //Update Name
            if (!string.IsNullOrEmpty(updateUser.Name) && updateUser.Name != currentUser.Name)
            {
                currentUser.Name = updateUser.Name;
                _context.SaveChanges();
            }

            return currentUser;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User TestUserUpdate(User user)
        {
            user.Name = "Updated";

            return user;
        }
    }
}