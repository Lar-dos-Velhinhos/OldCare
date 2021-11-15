namespace OldCare.Web.Data.Mappings;

public class BedroomMap : IEntityTypeConfiguration<Bedroom>
{
    public void Configure(EntityTypeBuilder<Bedroom> builder)
    {
        // Table
        builder.ToTable("Bedroom");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}
