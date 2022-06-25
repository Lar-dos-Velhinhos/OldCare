using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User);

        builder.HasMany(x => x.Activities);

        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Students)
            .UsingEntity<Dictionary<string, object>>(
                "StudentTag",
                tag => tag
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasConstraintName("FK_StudentTag_TagId")
                    .OnDelete(DeleteBehavior.NoAction),
                student => student
                    .HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .HasConstraintName("FK_StudentTag_StudentId")
                    .OnDelete(DeleteBehavior.Cascade));

        builder.OwnsOne(x => x.Name)
            .Property(x => x.FirstName)
            .HasColumnName("FirstName")
            .IsRequired(true)
            .HasMaxLength(60)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Name)
            .Property(x => x.LastName)
            .HasColumnName("LastName")
            .IsRequired(true)
            .HasMaxLength(60)
            .HasColumnType("NVARCHAR");

        builder.OwnsOne(x => x.Email)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .IsRequired(true)
            .HasMaxLength(120)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Email)
            .OwnsOne(x => x.Verification)
            .Property(x => x.IsVerified)
            .HasColumnName("EmailVerified")
            .IsRequired(true)
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Email)
            .OwnsOne(x => x.Verification)
            .Property(x => x.Code)
            .HasColumnName("EmailVerificationCode")
            .IsRequired(true)
            .HasMaxLength(8)
            .HasColumnType("CHAR");

        builder.OwnsOne(x => x.Email)
            .OwnsOne(x => x.Verification)
            .Property(x => x.CodeExpireDate)
            .HasColumnName("EmailVerificationCodeExpireDate")
            .IsRequired(true)
            .HasColumnType("DATETIME2");

        builder.OwnsOne(x => x.Phone)
            .Property(x => x.FullNumber)
            .HasColumnName("Phone")
            .IsRequired(true)
            .HasMaxLength(16)
            .HasColumnType("VARCHAR");

        builder.OwnsOne(x => x.Phone)
            .OwnsOne(x => x.Verification)
            .Property(x => x.IsVerified)
            .HasColumnName("PhoneVerified")
            .IsRequired(true)
            .HasColumnType("BIT");

        builder.OwnsOne(x => x.Phone)
            .OwnsOne(x => x.Verification)
            .Property(x => x.Code)
            .HasColumnName("PhoneVerificationCode")
            .IsRequired(true)
            .HasMaxLength(6)
            .HasColumnType("CHAR");

        builder.OwnsOne(x => x.Phone)
            .OwnsOne(x => x.Verification)
            .Property(x => x.CodeExpireDate)
            .HasColumnName("PhoneVerificationCodeExpireDate")
            .IsRequired(true)
            .HasColumnType("DATETIME2");

        builder.OwnsOne(x => x.Document)
            .Property(x => x.Number)
            .HasColumnName("Document")
            .IsRequired(false)
            .HasMaxLength(11)
            .HasColumnType("VARCHAR");

        builder.Property(x => x.BirthDate)
            .IsRequired(false)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.Title)
            .IsRequired(false)
            .HasMaxLength(80)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Bio)
            .IsRequired(false)
            .HasMaxLength(1024)
            .HasColumnType("NVARCHAR");

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

        builder.OwnsOne(x => x.Utm)
            .Property(x => x.Campaign)
            .HasColumnName("UtmCampaign")
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);

        builder.OwnsOne(x => x.Utm)
            .Property(x => x.Content)
            .HasColumnName("UtmContent")
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);

        builder.OwnsOne(x => x.Utm)
            .Property(x => x.Medium)
            .HasColumnName("UtmMedium")
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);

        builder.OwnsOne(x => x.Utm)
            .Property(x => x.Source)
            .HasColumnName("UtmSource")
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);
    }
}