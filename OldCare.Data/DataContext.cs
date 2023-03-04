using Microsoft.EntityFrameworkCore;
using OldCare.Data.Contexts.AccountContext.Mappings;
using OldCare.Data.Contexts.PersonContext.Mappings;
using OldCare.Data.Contexts.ResidentContext.Mappings;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.AccountContext.Entities;

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

    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Document> Documents { get; set; }

    #endregion

    #region Resident

    public DbSet<Resident> Residents { get; set; }
    public DbSet<Bedroom> Bedrooms { get; set; }
    public DbSet<Occurrence> Occurrences { get; set; }

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
        builder.ApplyConfiguration(new DocumentMap());

        builder.Entity<Document>()
            .HasKey(x => x.Id);

        #endregion

        #region Resident

        builder.ApplyConfiguration(new ResidentMap());
        builder.ApplyConfiguration(new BedroomMap());
        builder.ApplyConfiguration(new OccurrenceMap());

        builder.Entity<Resident>()
            .HasOne(r => r.Bedroom)
            .WithMany(r => r.Residents);

        builder.Entity<Resident>()
            .HasMany(r => r.Occurrences)
            .WithOne(r => r.Resident);

        #endregion
    }
}