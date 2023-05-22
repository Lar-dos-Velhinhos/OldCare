using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Data.Contexts.PersonContext.Mappings;

public class DocumentMap : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        #region Identifiers

        builder.ToTable("Document");
        builder.HasKey(x => x.Id);

        #endregion

        #region Relationships

        builder.HasOne(x => x.Person);

        #endregion

        #region Properties

        builder.Property(x => x.DocumentNumber)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.IsDeleted)
            .IsRequired()
            .HasColumnType("BIT");

        builder.Property(x => x.DocumentType)
            .HasDefaultValue(EDocumentType.RG)
            .HasColumnType("INT");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnType("SMALLDATETIME");

        builder.OwnsOne(x => x.Tracker)
            .Property(x => x.Notes)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");

        #endregion
    }
}