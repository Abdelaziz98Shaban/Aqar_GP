using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RealState> RealStates { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealState>().OwnsOne(c => c.Address);
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
