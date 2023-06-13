using ManageTemplate.Core.Contracts;
using ManageTemplate.Core.DTO;
using ManageTemplate.Core.Entities;
using ManageTemplate.Data.Contexts;
using ManageTemplate.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ManageTemplate.Services.Templates.Sections
{
  public class SectionRepository : ISectionRepository
  {

    private readonly TemplateDbContext _context;

    public SectionRepository(TemplateDbContext context)
    {
      _context = context;
    }

    public IQueryable<Section> FilterSections(
      SectionQuery condition)
    {
      return _context.Set<Section>()
        .Include(s => s.ExampledDatas)
        .WhereIf(!string.IsNullOrWhiteSpace(condition.CategorySlug), s =>
            s.Category.UrlSlug.Equals(condition.CategorySlug));
    }

    public async Task<IPagedList<T>> GetPagedSectionsAsync<T>(
      SectionQuery query,
      IPagingParams pagingParams,
      Func<IQueryable<Section>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default)
    {

      await Console.Out.WriteLineAsync(pagingParams.ToString());
            IQueryable<Section> sectionsFitler = FilterSections(query);

      return await mapper(sectionsFitler)
        .ToPagedListAsync<T>(pagingParams, cancellationToken);
    }
  }
}
