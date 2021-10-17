
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class BedroomMap : IEntityTypeConfiguration<Bedroom>
{
    public void Configure(EntityTypeBuilder<Bedroom> builder)
    {
        // Table
        builder.ToTable("Bedroom");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}
