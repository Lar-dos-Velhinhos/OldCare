namespace OldCare.Web.Data.Mappings;

public class ResidentModelMap : IEntityTypeConfiguration<ResidentModel>
{
    public void Configure(EntityTypeBuilder<ResidentModel> builder)
    {
        // Table
        builder.ToTable("Resident");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}