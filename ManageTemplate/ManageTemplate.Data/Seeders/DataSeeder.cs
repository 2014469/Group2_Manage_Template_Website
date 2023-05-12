
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
    }

  }
}
