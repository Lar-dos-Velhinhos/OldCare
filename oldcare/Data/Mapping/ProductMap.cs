namespace OldCare.Web.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Table
        builder.ToTable("Product");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}