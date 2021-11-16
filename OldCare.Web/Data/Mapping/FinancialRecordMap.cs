namespace OldCare.Web.Data.Mappings;

public class FinancialRecordMap : IEntityTypeConfiguration<FinancialRecord>
{
    public void Configure(EntityTypeBuilder<FinancialRecord> builder)
    {
        // Table
        builder.ToTable("FinancialRecord");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}