using OldCare.Contexts.AccountContext.Entities;
using OldCare.Data.Contexts.AccountContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    #region Account

    public DbSet<Bedroom> Bedrooms { get; set; } = null!;
    public DbSet<BlackList> BlackLists { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Resident> Residents { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Account

        builder.ApplyConfiguration(new BlackListMap());
        builder.ApplyConfiguration(new BedroomMap());
        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new UserRoleMap());
        builder.ApplyConfiguration(new PersonMap());
        builder.ApplyConfiguration(new ResidentMap());

        #endregion
    }
}