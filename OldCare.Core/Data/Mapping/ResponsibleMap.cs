using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class ResponsibleMap : IEntityTypeConfiguration<Responsible>
{
    public void Configure(EntityTypeBuilder<Responsible> builder)
    {
        // Table
        builder.ToTable("Responsible");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

