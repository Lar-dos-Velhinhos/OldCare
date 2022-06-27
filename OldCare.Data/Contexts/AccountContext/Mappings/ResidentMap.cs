using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class ResidentMap : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        builder.ToTable("Resident");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Person);

        builder.HasOne(x => x.Bedroom);
        
        builder.Property(x => x.AdmissionDate)
            .IsRequired()
            .HasColumnType("DATETIME2");
        
        builder.Property(x => x.DepartureDate)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.Father)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");
        
        builder.Property(x => x.HealthInsurance)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");
        
        builder.Property(x => x.MaritalStatus)
            .IsRequired()
            .HasColumnType("TINYINT");
        
        builder.Property(x => x.Mobility)
            .IsRequired()
            .HasColumnType("TINYINT");

        builder.Property(x => x.Mother)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Note)
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR");
        
        builder.Property(x => x.Profession)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");
        
        builder.Property(x => x.EducationLevel)
            .IsRequired()
            .HasColumnType("TINYINT");
        
        builder.Property(x => x.SUS)
            .HasColumnType("INT");
        
        builder.Property(x => x.VoterRegCardNumber)
            .HasColumnType("INT");
    }
}