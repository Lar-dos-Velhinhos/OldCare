using OldCare.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class ActivityMap : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("Activity");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasMaxLength(180)
            .HasColumnType("VARCHAR");

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(1024)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Date)
            .HasColumnName("Date")
            .IsRequired(true)
            .HasColumnType("SMALLDATETIME");
    }
}