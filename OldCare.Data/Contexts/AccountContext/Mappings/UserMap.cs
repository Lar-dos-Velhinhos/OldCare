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

        builder.HasOne(x => x.Person);

        builder.Property(x => x.Active)
            .IsRequired()
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Username)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .IsRequired(true)
            .HasMaxLength(120)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Username)
            .OwnsOne(x => x.Verification)
            .Property(x => x.IsVerified)
            .HasColumnName("EmailVerified")
            .IsRequired(true)
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Username)
            .OwnsOne(x => x.Verification)
            .Property(x => x.Code)
            .HasColumnName("EmailVerificationCode")
            .IsRequired(true)
            .HasMaxLength(8)
            .HasColumnType("CHAR");

        builder.OwnsOne(x => x.Username)
            .OwnsOne(x => x.Verification)
            .Property(x => x.CodeExpireDate)
            .HasColumnName("EmailVerificationCodeExpireDate")
            .IsRequired(true)
            .HasColumnType("DATETIME2");

        builder.OwnsOne(x => x.Password)
            .Property(x => x.Hash)
            .IsRequired()
            .HasMaxLength(120)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Password)
            .Property(x => x.Expired)
            .IsRequired()
            .HasColumnType("BIT");

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
            .HasMaxLength(1024)
            .HasColumnType("NVARCHAR");
    }
}