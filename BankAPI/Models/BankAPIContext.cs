using System.Data.Entity;

namespace BankAPI.Models
{
    public class BankAPIContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public BankAPIContext()
            : base("name=BankAPIContext") {}
    }
}