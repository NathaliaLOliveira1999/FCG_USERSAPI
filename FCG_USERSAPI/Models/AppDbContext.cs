using Microsoft.EntityFrameworkCore;

namespace FCG_USERSAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessProfile> AccessProfiles { get; set; }
        public DbSet<Access> Accesses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.IdClient);
            modelBuilder.Entity<User>().HasKey(g => g.IdUser);
            modelBuilder.Entity<AccessProfile>().HasKey(g => g.IdAccessProfile);
            modelBuilder.Entity<Access>().HasKey(g => g.IdAccess);

            base.OnModelCreating(modelBuilder);
        }
    }
}
