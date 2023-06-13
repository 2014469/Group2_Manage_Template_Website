using Carter;
using ManageTemplate.Core.DTO;
using ManageTemplate.Services.Templates.Categories;
using ManageTemplate.WebApi.Models;
using Mapster;
using MapsterMapper;
using System.Net;

namespace ManageTemplate.WebApi.Endpoints
{
  public class CategoriesEndpoint : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      var routeGroupBuilder = app.MapGroup("/api/categories");

      routeGroupBuilder.MapGet("/", GetAllCategories)
        .WithName("GetAllCategories")
        .Produces<IList<CategoryItem>>();

      routeGroupBuilder.MapGet("/{id:Guid}", GetCategoryById)
          .WithName("GetCategoryById")
          .Produces<IList<CategoryItem>>();

      routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetCategoryBySlug)
          .WithName("GetCategoryBySlug")
          .Produces<IList<CategoryItem>>();
    }

    private static async Task<IResult> GetAllCategories(
      ICategoryRepository categoryRepository)
    {
      var categories = await categoryRepository
        .GetAllCategories(
          categories => categories.ProjectToType<CategoryItem>());

      return Results.Ok(ApiResponse.Success(categories));
    }

    private static async Task<IResult> GetCategoryById(
      Guid id,
      ICategoryRepository categoryRepository,
      IMapper mapper)
    {
      var category = await categoryRepository.GetCategoryByIdAsync(id, true);
      return category == null
          ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy category có id {id}"))
          : Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category)));
    }

    private static async Task<IResult> GetCategoryBySlug(
      string slug,
      ICategoryRepository categoryRepository,
      IMapper mapper)
    {
      var category = await categoryRepository.GetCategoryBySlugAsync(slug, true);
      return category == null
          ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy category có slug {slug}"))
          : Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category)));
    }
  }
}
