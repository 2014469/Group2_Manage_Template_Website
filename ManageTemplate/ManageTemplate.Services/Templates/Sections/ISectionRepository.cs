using ManageTemplate.Core.Entities;

namespace ManageTemplate.Services.Templates.Sections
{
  public interface ISectionRepository
  {
    Task<IList<T>> GetAllSectionsByCategorySlug<T>(
      string slug,
      Func<IQueryable<Section>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default);
  }
}
