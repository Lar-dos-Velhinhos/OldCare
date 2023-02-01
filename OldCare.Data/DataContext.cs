using OldCare.Contexts.AccountContext.Entities;
using OldCare.Data.Contexts.AccountContext.Mappings;
using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Data.Contexts.PersonContext.Mappings;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Data.Contexts.ResidentContext.Mappings;

namespace OldCare.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    #region Account
    
    public DbSet<BlackList> BlackLists { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;
    
    #endregion

    #region Person

    public DbSet<Person?> People { get; set; } = null!;

    #endregion

    #region Resident

    public DbSet<Resident> Residents { get; set; }
    public DbSet<Bedroom> Bedrooms { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Account

        builder.HasDefaultSchema("backoffice");
        builder.ApplyConfiguration(new BlackListMap());
       // builder.ApplyConfiguration(new BedroomMap());
        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new UserRoleMap());
        //builder.ApplyConfiguration(new ResidentMap());

        #endregion

        #region Person

        builder.ApplyConfiguration(new PersonMap());

        #endregion

        #region Resident

        builder.ApplyConfiguration(new ResidentMap());
        builder.ApplyConfiguration(new BedroomMap());

        #endregion
    }
}