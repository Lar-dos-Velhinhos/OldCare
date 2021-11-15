namespace OldCare.Web.Data.Mappings;

public class PrescriptionMap : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        // Table
        builder.ToTable("Prescription");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Relationships
        builder.HasOne(x => x.Resident);
        builder.HasOne(x => x.Resident).WithMany().OnDelete(DeleteBehavior.NoAction);

        // Properties
    }
}