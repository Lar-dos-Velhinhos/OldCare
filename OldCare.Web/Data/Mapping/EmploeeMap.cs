namespace OldCare.Web.Data.Mappings;

public class EmploeeMap : IEntityTypeConfiguration<Emploee>
{
    public void Configure(EntityTypeBuilder<Emploee> builder)
    {
        // Table
        builder.ToTable("Emploee");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}
