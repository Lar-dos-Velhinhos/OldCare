namespace OldCare.Web.Data.Mappings;

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