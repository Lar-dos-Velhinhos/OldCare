using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Data.Contexts.ResidentContext.Mappings;

public class ResidentMap : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        #region Identifiers

        builder.ToTable("Resident");
        builder.HasKey(x => x.Id);

        #endregion
        
        #region Relationships
        
        builder.HasOne(x => x.Person);
        builder.HasOne(x => x.Bedroom);
        builder.HasMany(r => r.Occurrences);

        #endregion

        #region Properties
        
        builder.Property(x => x.AdmissionDate)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(x => x.EducationLevel)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.DepartureDate)
            .HasColumnType("DATETIME");

        builder.Property(x => x.HealthInsurance)
            .IsRequired()
            .HasDefaultValue("SUS")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasColumnType("BIT");

        builder.Property(x => x.MaritalStatus)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.Mobility)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.Note)
            .IsRequired(false)
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Profession)
            .IsRequired(false)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.SUS)
            .HasColumnType("BIGINT");

        builder.Property(x => x.VoterRegCardNumber)
            .HasColumnType("BIGINT");

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