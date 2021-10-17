using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class ResidentMap : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        // Table
        builder.ToTable("Resident");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

