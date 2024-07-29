using LearnAdmin.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAdmin.Repositories
{
    public class LearnAdminContext : DbContext
    {
        public LearnAdminContext(DbContextOptions<LearnAdminContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Ignore(u => u.User)
                .HasMany(u => u.User)
                .WithMany(r => r.Role)
                .UsingEntity<UserRole>()
                .Ignore(ur => ur.Role)
                .Ignore(ur => ur.User);
        }

        public DbSet<Role> Role { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Pdf> Pdf { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

    }
}

