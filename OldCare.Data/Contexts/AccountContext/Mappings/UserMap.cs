using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Active)
            .HasColumnName("Active")
            .IsRequired(true)
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Username)
            .Ignore(x => x.Verification)
            .Property(x => x.Address)
            .HasColumnName("Username")
            .IsRequired(true)
            .HasMaxLength(120)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Password)
            .Property(x => x.Hash)
            .HasColumnName("PasswordHash")
            .IsRequired(true)
            .HasMaxLength(120)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Password)
            .Property(x => x.Expired)
            .HasColumnName("PasswordExpired")
            .IsRequired(true)
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired(true)
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .IsRequired(true)
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.Notes)
            .HasColumnName("Notes")
            .HasMaxLength(1024)
            .IsRequired(false)
            .HasColumnType("NVARCHAR");
    }
}