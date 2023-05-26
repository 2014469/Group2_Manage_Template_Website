
using ManageTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageTemplate.Data.Mappings
{

  public class CategoryMap : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("Categoires");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Name)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(c => c.ImageUrl)
        .HasMaxLength(1000);

      builder.Property(c => c.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(c => c.Description)
        .HasMaxLength(2000)
        .IsRequired();

      builder.Property(c => c.Enable)
        .IsRequired()
        .HasDefaultValue(true);
    }
  }
}
