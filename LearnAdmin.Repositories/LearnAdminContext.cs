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
            modelBuilder.Entity<User>().Ignore(u => u.Role);
        } 

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Pdf> Pdf { get; set; }

    }
}

