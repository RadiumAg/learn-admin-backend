using LearnAdmin.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAdmin.Repositories
{
    public class LearnAdminContext : DbContext
    {
        public LearnAdminContext(DbContextOptions<LearnAdminContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Pdf> Pdf { get; set; }

    }
}

