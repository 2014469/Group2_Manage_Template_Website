using ManageTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageTemplate.Data.Contexts
{
  public class TemplateDbContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<SampledData> SampledDatas { get; set; }


    public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=ManageTemplate;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.ApplyConfigurationsFromAssembly(typeof().Assembly);
    }
  }
}
