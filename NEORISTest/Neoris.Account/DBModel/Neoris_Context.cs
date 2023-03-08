using Microsoft.EntityFrameworkCore;
using Neoris.Accounts.DBModel.Tables;

namespace Neoris.Accounts.DBModel
{
    public class Neoris_Context : DbContext
    {
        public Neoris_Context(DbContextOptions options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(x => { x.HasIndex(y => y.Id).IsUnique(); });
        }

        public virtual DbSet<Account> Account { get; set; }
    }
}
