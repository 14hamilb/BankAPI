using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Preferences Preferences { get; set; }
        public virtual List<Account> Accounts { get; set; } = new List<Account>();
    }
}