using ManageTemplate.Core.Contracts;
using ManageTemplate.Core.DTO;
using ManageTemplate.Core.Entities;

namespace ManageTemplate.Services.Templates.Categories
{
  public interface ICategoryRepository
  {
    Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
       CategoryQuery query,
       IPagingParams pagingParams,
       Func<IQueryable<Category>, IQueryable<T>> mapper,
       CancellationToken cancellationToken = default);

    Task<IList<T>> GetAllCategories<T>(
       Func<IQueryable<Category>, IQueryable<T>> mapper,
       CancellationToken cancellationToken = default);

    Task<Category> GetCategoryByIdAsync(
        Guid id,
        bool includeDetail = false,
        CancellationToken cancellationToken = default);

        Task<Category> GetCategoryBySlugAsync(
                string slug,
                bool includeDetail = false,
                CancellationToken cancellationToken = default);

        Task<bool> AddOrUpdateCategoryAsync(
        Category category,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteCategoryByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<bool> IsCategorySlugExistAsync(
        Guid id,
        string slug,
        CancellationToken cancellationToken = default);
  }
}
