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

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<BlackList> BlackLists { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Activity> Activities { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Account

        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new UserRoleMap());
        builder.ApplyConfiguration(new StudentMap());
        builder.ApplyConfiguration(new BlackListMap());
        builder.ApplyConfiguration(new TagMap());
        builder.ApplyConfiguration(new ActivityMap());

        #endregion
    }
}