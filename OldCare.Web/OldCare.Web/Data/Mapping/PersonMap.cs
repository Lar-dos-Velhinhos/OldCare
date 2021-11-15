namespace OldCare.Web.Data.Mappings;

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