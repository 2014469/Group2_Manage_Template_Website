using Microsoft.EntityFrameworkCore;

namespace MusicApp.Data.Contexts
{
  public class TemplateDbContext : DbContext
  {


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
