using Microsoft.EntityFrameworkCore;
using Neoris.Transactions.DBModel.Tables;

namespace Neoris.Transactions.DBModel
{
    public class Neoris_Context : DbContext
    {
        public Neoris_Context(DbContextOptions options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(x => {
                x.ToTable("Transaction");
                x.HasIndex(y => y.Id).IsUnique(); });
        }

        public virtual DbSet<Transaction> Transaction { get; set; }
    }
}
