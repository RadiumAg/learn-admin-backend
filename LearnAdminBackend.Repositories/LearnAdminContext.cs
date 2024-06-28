using LearnAdmin.Model.Models;
using Microsoft.EntityFrameworkCore;

public class LearnAdminContext : DbContext
{
    public LearnAdminContext(DbContextOptions<LearnAdminContext> config) : base(config)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Pdf> Pdfs { get; set; }

}