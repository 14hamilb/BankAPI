using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAPI.Models.JSON
{
    public class AccountRequest
    {
        public string AccountName { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
    }
}