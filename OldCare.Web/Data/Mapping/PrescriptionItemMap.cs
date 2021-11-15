namespace OldCare.Web.Data.Mappings;

public class PrescriptionItemMap : IEntityTypeConfiguration<PrescriptionItem>
{
    public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
    {
        // Table
        builder.ToTable("PrescriptionItem");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}