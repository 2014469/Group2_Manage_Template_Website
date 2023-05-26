using ManageTemplate.Core.Entities;

namespace ManageTemplate.Services.Templates.Sections
{
  public class SectionRepository : ISectionRepository
  {
    public Task<IList<T>> GetAllSectionsByCategorySlug<T>(
      string slug,
      Func<IQueryable<Section>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}
