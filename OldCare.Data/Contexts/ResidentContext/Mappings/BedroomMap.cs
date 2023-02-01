using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.ResidentContext.Entities;

namespace OldCare.Data.Contexts.ResidentContext.Mappings;

public class BedroomMap : IEntityTypeConfiguration<Bedroom>
{
    public void Configure(EntityTypeBuilder<Bedroom> builder)
    {
        builder.ToTable("Bedroom");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Capacity)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(x => x.Gender)
            .IsRequired()
            .HasColumnType("BIT");

        builder.Property(x => x.Number)
            .IsRequired()
            .HasColumnType("INT");

        builder.HasMany(x => x.Residents);
    }
}