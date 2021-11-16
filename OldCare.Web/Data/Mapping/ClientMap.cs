namespace OldCare.Web.Data.Mappings;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        // Table
        builder.ToTable("Client");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Properties
    }
}