namespace Oldcare.Core.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=127.0.0.1;Database=oldcare;User ID=sa;Password=1q2w3e4r@#$");
}

