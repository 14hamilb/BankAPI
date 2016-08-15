using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class User
    {
        public User() { }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}