using System.Web.Http;
using BankAPI.Models;
using BankAPI.Models.JSON;

namespace BankAPI.Controllers
{
    [RoutePrefix("api/v1/accounts")]
    public class AccountController : ApiController
    {
        [HttpPut]
        [Route("")]
        public Account CreateAccount(AccountRequest accountRequest)
        {
            return new AccountService(new BankAPIContext()).CreateAccount(accountRequest.AccountName,
                accountRequest.UserId);
        }

        [HttpDelete]
        [Route("")]
        public bool DeleteAccount(AccountRequest accountRequest)
        {
            return new AccountService(new BankAPIContext()).DeleteAccount(accountRequest.AccountId,
                accountRequest.UserId);
        }
    }
}