using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class TagMap : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tag");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Slug)
            .IsRequired(true)
            .HasMaxLength(80)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasMaxLength(180)
            .HasColumnType("VARCHAR");

        builder.Property(x => x.Description)
            .IsRequired(true)
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

        builder.Property(x => x.IsPublic)
            .IsRequired(true)
            .HasColumnType("BIT");
    }
}