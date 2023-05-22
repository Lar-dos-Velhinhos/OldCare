using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        #region Identifiers

        builder.ToTable("Role");
        builder.HasKey(x => x.Id);

        #endregion

        #region Properties

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .IsRequired(true)
            .HasMaxLength(40)
            .HasColumnType("VARCHAR");
        
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