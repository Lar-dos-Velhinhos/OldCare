using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class ResidentResponsibleMap : IEntityTypeConfiguration<ResidentResponsible>
{
    public void Configure(EntityTypeBuilder<ResidentResponsible> builder)
    {
        // Table
        builder.ToTable("ResidentResponsible");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}
