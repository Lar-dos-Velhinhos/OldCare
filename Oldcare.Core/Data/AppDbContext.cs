namespace Oldcare.Core.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("DataSource=app.db;Cache=Shared");
}

