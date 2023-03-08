using Microsoft.EntityFrameworkCore;
using Neoris.User.DBModel.Tables;

namespace Neoris.User.DBModel
{
    public class Neoris_Context : DbContext
    {
        public Neoris_Context(DbContextOptions options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(x => { x.HasIndex(y => y.Id).IsUnique(); });
            modelBuilder.Entity<Client>(x => { x.HasIndex(y => y.Id).IsUnique();
                x.HasOne(y => y.Person).WithOne(z => z.Client).HasForeignKey<Client>(q => q.PersonID);           
            });
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Client> Client { get; set; }
    }
}
