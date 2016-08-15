using System.Data.Entity;

namespace BankAPI.Models
{
    public class BankAPI : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public BankAPI()
            : base("name=BankAPI.Model") {}
    }
}