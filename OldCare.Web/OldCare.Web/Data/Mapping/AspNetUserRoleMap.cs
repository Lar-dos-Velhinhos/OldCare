namespace OldCare.Web.Data.Mappings;

internal class AspNetUserRoleMap : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasKey(r => new { r.UserId, r.RoleId });
        builder.ToTable("AspNetUserRoles");
    }
}