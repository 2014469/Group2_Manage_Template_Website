using ManageTemplate.Core.Contracts;
using ManageTemplate.Core.DTO;
using ManageTemplate.Core.Entities;

namespace ManageTemplate.Services.Templates.Sections
{
  public interface ISectionRepository
  {
    Task<IPagedList<T>> GetPagedSectionsAsync<T>(
      SectionQuery sectionQuery, 
      IPagingParams pagingParams,
      Func<IQueryable<Section>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default);

    Task<Section> GetSectionBySlug(
      string slug,
      bool includeDetail = false,
      CancellationToken cancellationToken = default);
  }
}
