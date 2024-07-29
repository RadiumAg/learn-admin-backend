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
                .HasMany<User>()
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.Role)
                .IsRequired(false);
        }

        public DbSet<Role> roles { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Pdf> Pdf { get; set; }

    }
}

