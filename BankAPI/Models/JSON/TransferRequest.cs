using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAPI.Models.JSON
{
    public class TransferRequest
    {
        public int UserId { get; set; }
        public string FromAccountGUID { get; set; }
        public string ToAccountGUID { get; set; }
        public double TransferAmount { get; set; }
    }
}