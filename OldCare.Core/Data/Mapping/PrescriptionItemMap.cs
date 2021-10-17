using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class PrescriptionItemMap : IEntityTypeConfiguration<PrescriptionItem>
{
    public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
    {
        // Table
        builder.ToTable("PrescriptionItem");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

