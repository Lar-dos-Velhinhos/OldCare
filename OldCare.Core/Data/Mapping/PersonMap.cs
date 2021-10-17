using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OldCare.Core.Entities;

namespace OldCare.Core.Data.Mapping;
public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // Table
        builder.ToTable("Person");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}

