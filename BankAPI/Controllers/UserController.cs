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
            return new UserService(new BankAPIContext()).GetUsers();
        }

        [HttpPost]
        [Route("{userId:int}")]
        public User UpdateUser(User updateUser, int userId)
        {
            return new UserService(new BankAPIContext()).UpdateUser(updateUser, userId);
        }
    }
}