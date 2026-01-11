using Microsoft.EntityFrameworkCore;

namespace FCG_USERSAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.IdClient);
            modelBuilder.Entity<User>().HasKey(g => g.IdUser);

            base.OnModelCreating(modelBuilder);
        }
    }
}
