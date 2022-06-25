namespace OldCare.Web.Data.Mappings;

public class ResponsibleMap : IEntityTypeConfiguration<Responsible>
{
    public void Configure(EntityTypeBuilder<Responsible> builder)
    {
        // Table
        builder.ToTable("Responsible");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}