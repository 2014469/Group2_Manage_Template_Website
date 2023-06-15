
using ManageTemplate.Core.DTO;
using ManageTemplate.Core.Entities;
using ManageTemplate.Data.Contexts;
using ManageTemplate.Services.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ManageTemplate.Services.Templates.SampledDataService
{
  public class SampledDataRepository : ISampledDataRepository
  {
    private readonly TemplateDbContext _context;

    public SampledDataRepository(TemplateDbContext context)
    {
      _context = context;
    }

    public IQueryable<SampledData> FilterSampledData(
      SampledDataQuery condition)
    {
      return _context.Set<SampledData>()
        .WhereIf(!condition.SectionId.IsNullOrEmpty(),
                  sd => sd.SectionId.Equals(condition.SectionId));
    }



    public async Task<IList<T>> GetSampledDataAsync<T>(
      SampledDataQuery sampledDataQuery,
      Func<IQueryable<SampledData>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default)
    {
      IQueryable<SampledData> sampledDataFilter = FilterSampledData(sampledDataQuery);

      return await mapper(sampledDataFilter)
            .ToListAsync<T>(cancellationToken);
    }
  }
}
