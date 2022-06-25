namespace OldCare.Web.Data.Mappings;

public class HistoryMap : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        // Table
        builder.ToTable("History");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}