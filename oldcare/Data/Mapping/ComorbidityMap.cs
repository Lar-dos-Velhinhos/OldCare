namespace OldCare.Web.Data.Mappings;

public class ComorbidityMap : IEntityTypeConfiguration<Comorbidity>
{
    public void Configure(EntityTypeBuilder<Comorbidity> builder)
    {
        // Table
        builder.ToTable("Comorbidity");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}
