using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class PrescriptionMap : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        // Table
        builder.ToTable("Prescription");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

