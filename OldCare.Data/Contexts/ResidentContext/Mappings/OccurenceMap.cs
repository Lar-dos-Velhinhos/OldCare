using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.Enums;

namespace OldCare.Data.Contexts.ResidentContext.Mappings;

public class OccurrenceMap : IEntityTypeConfiguration<Occurrence>
{
    public void Configure(EntityTypeBuilder<Occurrence> builder)
    {
        #region Identifiers

        builder.ToTable("Occurrence");
        builder.HasKey(x => x.Id);

        #endregion
        
        #region Relationships
        
        builder.HasOne(x => x.Resident);

        #endregion

        #region Properties
        
        builder.Property(x => x.Description)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(500);

        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasColumnType("BIT");
        
        builder.Property(x => x.OccurrenceDate)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(x => x.OccurrenceType)
            .HasDefaultValue(EOccurrenceType.General)
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