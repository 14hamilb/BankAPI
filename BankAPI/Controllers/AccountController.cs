using System.Collections.Generic;
using System.Web.Http;
using BankAPI.Models;
using BankAPI.Models.JSON;

namespace BankAPI.Controllers
{
    [RoutePrefix("api/v1/accounts")]
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("all")]
        public List<Account> GetAccount(AccountRequest accountRequest)
        {
            return new AccountService(new BankAPIContext()).GetAccounts(accountRequest.UserId);
        }

        [HttpPost]
        [Route("transfer")]
        public Transaction TransferFunds(TransferRequest transferRequest)
        {
            return new AccountService(new BankAPIContext()).PerformTransaction(transferRequest);
        }

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