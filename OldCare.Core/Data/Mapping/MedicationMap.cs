using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class MedicationMap : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        // Table
        builder.ToTable("Medication");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

