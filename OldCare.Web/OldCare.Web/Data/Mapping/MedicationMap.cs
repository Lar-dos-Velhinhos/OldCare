namespace OldCare.Web.Data.Mappings;

public class MedicationMap : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        // Table
        builder.ToTable("Medication");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}