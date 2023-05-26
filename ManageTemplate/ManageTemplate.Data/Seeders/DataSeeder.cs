
using ManageTemplate.Core.Entities;
using MusicApp.Data.Contexts;

namespace ManageTemplate.Data.Seeders
{
  public class DataSeeder : IDataSeeder
  {
    private readonly TemplateDbContext _dbContext;

    public DataSeeder(
      TemplateDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Intitalize()
    {
      _dbContext.Database.EnsureCreated();

      if (_dbContext.Set<Section>().Any())
      {
        return;
      }
    }

    public IList<Category> AddCategories()
    {
      var categories = new List<Category>() { };

      return categories;
    }

  }
}
