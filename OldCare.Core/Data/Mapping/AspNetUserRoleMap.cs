using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Balta.Core.Data.Mappings
{
    internal class AspNetUserRoleMap : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });
            builder.ToTable("AspNetUserRoles");
        }
    }
}
