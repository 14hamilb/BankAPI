using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        
    }
}