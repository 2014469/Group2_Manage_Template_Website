using ManageTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageTemplate.Data.Mappings
{
  public class SectionMap : IEntityTypeConfiguration<Section>
  {
    public void Configure(EntityTypeBuilder<Section> builder)
    {
      builder.ToTable("Sections");

      builder.HasKey(s => s.Id);

      builder.Property(s => s.Name)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(s => s.Hbs)
        .IsRequired();

      builder.Property(s => s.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(s => s.PreviewImageUrl)
        .HasMaxLength(1000);

      builder.Property(s => s.Enable)
        .IsRequired()
        .HasDefaultValue(true);

      builder.HasOne(s => s.Category)
        .WithMany(c => c.Sections)
        .HasForeignKey(s => s.CategoryId)
        .HasConstraintName("FK_Sections_Categories")
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
