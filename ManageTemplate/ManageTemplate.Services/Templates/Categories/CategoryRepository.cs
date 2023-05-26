
using ManageTemplate.Core.Contracts;
using ManageTemplate.Core.DTO;
using ManageTemplate.Core.Entities;
using ManageTemplate.Data.Contexts;
using ManageTemplate.Services.Extensions;
using ManageTemplate.Services.Templates.Categories;
using Microsoft.EntityFrameworkCore;

namespace ManageTemplate.Services.Musics.Categories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly TemplateDbContext _context;

    public CategoryRepository(TemplateDbContext context)
    {
      _context = context;
    }

    public IQueryable<Category> FilterCategories(CategoryQuery condition)
    {

      return _context.Set<Category>()
        .Include(c => c.Sections)
        .WhereIf(!string.IsNullOrWhiteSpace(condition.KeyWord),
          c => c.Name.Contains(condition.KeyWord)
            || c.UrlSlug.Contains(condition.KeyWord)
            || c.Description.Contains(condition.KeyWord));
    }

    public async Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
      CategoryQuery query,
      IPagingParams pagingParams,
      Func<IQueryable<Category>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default)
    {
      IQueryable<Category> categoryFilter = FilterCategories(query);

      return await mapper(categoryFilter)
        .ToPagedListAsync<T>(pagingParams, cancellationToken);
    }

    public async Task<Category> GetCategoryByIdAsync(
      Guid id,
      bool includeDetail = false,
      CancellationToken cancellationToken = default)
    {
      if (!includeDetail)
      {
        return await _context.Set<Category>()
          .FindAsync(id, cancellationToken);
      }

      return await _context.Set<Category>()
              .Include(c => c.Sections)
              .Where(c => c.Id == id)
              .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> AddOrUpdateCategoryAsync(
      Category category,
      CancellationToken cancellationToken = default)
    {

      if (category.Id != Guid.Empty)
      {
        _context.Set<Category>().Update(category);
      }
      else
      {
        _context.Set<Category>().Add(category);
      }

      return await _context
        .SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteCategoryByIdAsync(
      Guid id,
      CancellationToken cancellationToken = default)
    {
      var categoryToDelete = await _context
        .Set<Category>()
        .Where(c => c.Id.Equals(id))
        .FirstOrDefaultAsync(cancellationToken);

      if (categoryToDelete == null)
      {
        return false;
      }

      _context.Set<Category>().Remove(categoryToDelete);
      return await _context
        .SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> IsCategorySlugExistAsync(
      Guid id,
      string slug,
      CancellationToken cancellationToken = default)
    {
      return await _context.Set<Category>()
        .AnyAsync(c => c.Id != id
          && c.UrlSlug == slug,
          cancellationToken);
    }

    public async Task<IList<T>> GetAllCategories<T>(
      Func<IQueryable<Category>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default)
    {
      var category = _context.Set<Category>()
        .Include(c => c.Sections);

      return await mapper(category)
        .ToListAsync<T>(cancellationToken);
    }

    public async Task<Category> GetCategoryBySlugAsync(string slug, bool includeDetail = false, CancellationToken cancellationToken = default)
    {
      if (!includeDetail)
      {
        return await _context.Set<Category>()
          .Where(c => c.UrlSlug.Equals(slug))
          .FirstOrDefaultAsync(cancellationToken);
      }

      return await _context.Set<Category>()
              .Include(c => c.Sections)
              .Where(c => c.UrlSlug == slug)
              .FirstOrDefaultAsync(cancellationToken);
    }
  }
}
