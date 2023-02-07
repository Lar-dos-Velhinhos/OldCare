using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Data.Contexts.ResidentContext.Mappings;

public class BedroomMap : IEntityTypeConfiguration<Bedroom>
{
    public void Configure(EntityTypeBuilder<Bedroom> builder)
    {
        #region Identifiers
        
        builder.ToTable("Bedroom");
        builder.HasKey(x => x.Id);
        
        #endregion
        
        #region Relationships
        
        // builder.HasMany(x => x.Residents);
        
        #endregion

        #region Properties
        
        builder.Property(x => x.Capacity)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.Gender)
            .IsRequired()
            .HasColumnType("BIT");

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnType("INT");

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