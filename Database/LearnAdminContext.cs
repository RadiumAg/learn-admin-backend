using learn_admin_backend.Database;
using Microsoft.EntityFrameworkCore;

public class LearnAdminContext : DbContext
{

    public string DbPath { get; }
    public DbSet<User> Blogs { get; set; }

    public DbSet<Pdf> Pdfs { get; set; }

    public LearnAdminContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "learn-admin-context.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}