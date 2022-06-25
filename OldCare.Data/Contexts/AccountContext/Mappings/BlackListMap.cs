using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class BlackListMap : IEntityTypeConfiguration<BlackList>
{
    public void Configure(EntityTypeBuilder<BlackList> builder)
    {
        builder.ToTable("BlackList");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Email)
            .Ignore(x => x.Verification)
            .Property(x => x.Address)
            .HasColumnName("Email")
            .IsRequired(true)
            .HasMaxLength(120)
            .HasColumnType("VARCHAR");

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
            .IsRequired(false);
    }
}