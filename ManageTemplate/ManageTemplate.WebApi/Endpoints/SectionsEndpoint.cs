using Carter;
using ManageTemplate.Core.Collections;
using ManageTemplate.Core.DTO;
using ManageTemplate.Services.Templates.Sections;
using ManageTemplate.WebApi.Models;
using ManageTemplate.WebApi.Models.Section;
using Mapster;
using MapsterMapper;

namespace ManageTemplate.WebApi.Endpoints
{
  public class SectionsEndpoint : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      var routeGroupBuilder = app.MapGroup("/api/sections");

      routeGroupBuilder.MapGet("/", GetSections)
        .WithName("GetSections")
        .Produces<ApiResponse<PaginationResult<SectionItem>>>();

    }

    private static async Task<IResult> GetSections(
      [AsParameters] SectionFilterModel model,
      ISectionRepository sectionRepository,
      IMapper mapper)
    {
      var sectionQuery = mapper.Map<SectionQuery>(model);

      var sections = await sectionRepository.GetPagedSectionsAsync(
        sectionQuery, model,
        sections => sections.ProjectToType<SectionItem>());

      var paginationResult = new PaginationResult<SectionItem>(sections);
      return Results.Ok(ApiResponse.Success(paginationResult));
    }
  }
}
