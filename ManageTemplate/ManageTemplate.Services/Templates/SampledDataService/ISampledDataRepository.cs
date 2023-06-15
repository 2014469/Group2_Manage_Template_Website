using ManageTemplate.Core.DTO;
using ManageTemplate.Core.Entities;

namespace ManageTemplate.Services.Templates.SampledDataService
{
  public interface ISampledDataRepository
  {
    Task<IList<T>> GetSampledDataAsync<T>(
      SampledDataQuery sampledDataQuery,
      Func<IQueryable<SampledData>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default);
  }
}
