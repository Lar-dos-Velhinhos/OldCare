namespace OldCare.Web.Data.Mappings;

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