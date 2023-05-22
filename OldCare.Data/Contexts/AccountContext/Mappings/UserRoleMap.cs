using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class UserRoleMap : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        #region Identifiers

        builder.ToTable("UserRole");
        builder.HasKey(x => x.Id);
        
        #endregion
        
        #region Relationships
        
        builder.HasOne(x => x.User);
        builder.HasOne(x => x.Role);
        
        #endregion

        #region Properties

        builder.Property(x => x.RoleId)
            .HasColumnName("RoleId")
            .IsRequired(true)
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired(true)
            .HasColumnType("UNIQUEIDENTIFIER");

        builder.Property(x => x.StartDate)
            .HasColumnName("StartDate")
            .IsRequired(false)
            .HasColumnType("SMALLDATETIME");

        builder.Property(x => x.EndDate)
            .HasColumnName("EndDate")
            .IsRequired(false)
            .HasColumnType("SMALLDATETIME");
        
        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.Notes)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");
        
        #endregion
    }
}