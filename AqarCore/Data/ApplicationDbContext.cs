using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RealState>? RealStates { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<Transactions>? Transactions { get; set; }
        public DbSet<FavoriteList> FavoriteList { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealState>().OwnsOne(c => c.Address);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transactions>()
                .HasKey(deal => new { deal.UserId, deal.RealstateId });
            modelBuilder.Entity<FavoriteList>()
                .HasKey(favlist => new { favlist.UserId, favlist.RealstateId });
        }
    }

    
}
