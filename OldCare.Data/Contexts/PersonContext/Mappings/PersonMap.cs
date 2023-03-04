using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Data.Contexts.PersonContext.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Address)
            .Property(x => x.ZipCode)
            .HasMaxLength(20)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Street)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Number)
            .HasMaxLength(20)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.District)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.City)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.State)
            .HasMaxLength(2)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Country)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Complement)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Code)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Notes)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(60)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Name)
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(60)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Nationality)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Phone)
            .Property(x => x.FullNumber)
            .IsRequired()
            .HasMaxLength(16)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Phone)
            .OwnsOne(x => x.Verification)
            .Property(x => x.IsVerified)
            .IsRequired()
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Phone)
            .OwnsOne(x => x.Verification)
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(6)
            .HasColumnType("CHAR");

        builder.OwnsOne(x => x.Phone)
            .OwnsOne(x => x.Verification)
            .Property(x => x.CodeExpireDate)
            .IsRequired()
            .HasColumnType("DATETIME2");

        builder.Property(x => x.Citizenship)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Gender)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.IsDeleted)
            .HasColumnName("IsDeleted");

        builder.Property(x => x.Obs)
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.BirthDate)
            .HasColumnType("DATETIME2");

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

        builder.Property(x => x.Photo)
            .HasColumnType("NVARCHAR");
    }
}