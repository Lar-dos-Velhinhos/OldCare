using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class OccurrenceMap : IEntityTypeConfiguration<Occurrence>
{
    public void Configure(EntityTypeBuilder<Occurrence> builder)
    {
        // Table
        builder.ToTable("Occurrence");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

