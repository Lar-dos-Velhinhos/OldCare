using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Contexts.AccountContext.Entities;

namespace OldCare.Data.Contexts.AccountContext.Mappings;

public class BedroomMap : IEntityTypeConfiguration<Bedroom>
{
    public void Configure(EntityTypeBuilder<Bedroom> builder)
    {
        builder.ToTable("Bedroom");
        
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Residents);
        
        builder.Property(x => x.Capacity)
            .HasColumnType("TINYINT");
        
        builder.Property(x => x.Gender)
            .HasColumnType("BIT");
        
        builder.Property(x => x.Number)
            .HasColumnType("INT");
    }
}