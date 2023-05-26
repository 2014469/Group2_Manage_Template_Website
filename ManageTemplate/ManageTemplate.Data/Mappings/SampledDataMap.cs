
using ManageTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageTemplate.Data.Mappings
{
  public class SampledDataMap : IEntityTypeConfiguration<SampledData>
  {
    public void Configure(EntityTypeBuilder<SampledData> builder)
    {
      builder.ToTable("SampledDatas");

      builder.HasKey(sd => sd.Id);

      builder.Property(sd => sd.Name)
        .HasMaxLength(200)
        .IsRequired();

      builder.Property(sd => sd.Data)
        .IsRequired();

      builder.Property(sd => sd.Title)
        .IsRequired();

      builder.Property(sd => sd.Enable)
        .IsRequired()
        .HasDefaultValue(true);

      builder.HasOne(sd => sd.Section)
        .WithMany(s => s.ExampledDatas)
        .HasForeignKey(sd => sd.SectionId)
        .HasConstraintName("FK_SampledDatas_Sections")
        .OnDelete(DeleteBehavior.Cascade);

    }
  }
}
