using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Account> Accounts { get; set; }

        public string UpdateUserName { get; set; }
    }
}