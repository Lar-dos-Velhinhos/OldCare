namespace OldCare.Web.Data.Mappings;

public class ResidentResponsibleMap : IEntityTypeConfiguration<ResidentResponsible>
{
    public void Configure(EntityTypeBuilder<ResidentResponsible> builder)
    {
        // Table
        builder.ToTable("ResidentResponsible");

        // Keys and indexes
        builder.HasKey(x => x.Id);

        // Relationships
        //builder.HasOne(x => x.Resident);
        //builder.HasOne(x => x.Resident).WithMany().OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne(x => x.Responsible);
        //builder.HasOne(x => x.Responsible).WithMany().OnDelete(DeleteBehavior.NoAction);

        // Properties
    }
}