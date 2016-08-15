using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.Http;
using BankAPI.Models;

namespace BankAPI.Controllers
{
    [RoutePrefix("api/v1/users")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<User> GetUsers()
        {
            return new Models.BankAPIContext().Users.ToList();
        }

        [HttpPost]
        [Route("{userId:int}")]
        public User UpdateUser(User updateUser, int userId)
        {
            var model = new Models.BankAPIContext();

            var currentUser = model.Users.FirstOrDefault(u => u.Id == userId);

            if (currentUser == null)
                throw new NullReferenceException("User not found.");

            //Update Name
            if (!string.IsNullOrEmpty(updateUser.Name) && updateUser.Name != currentUser.Name)
            {
                currentUser.Name = updateUser.Name;
                model.SaveChanges();
            }

            return currentUser;
        }
    }
}