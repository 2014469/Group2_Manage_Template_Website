using Carter;
using ManageTemplate.Core.DTO;
using ManageTemplate.Services.Templates.SampledDataService;
using ManageTemplate.WebApi.Model;
using ManageTemplate.WebApi.Models;
using Mapster;
using MapsterMapper;

namespace ManageTemplate.WebApi.Endpoints
{
  public class SampledDataEndpoint : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      var routeGroupBuilder = app.MapGroup("/api/sampledData");

      routeGroupBuilder.MapGet("/", GetSampledData)
        .WithName("GetSampledData")
        .Produces<IList<SampledDataDto>>();
    }


    private static async Task<IResult> GetSampledData(
    [AsParameters] SampledDataFilterModel model,
    ISampledDataRepository sampledDataRepository,
    IMapper mapper)
    {

      var sampledDataQuery = mapper.Map<SampledDataQuery>(model);

      var sampledData = await sampledDataRepository.GetSampledDataAsync(sampledDataQuery, sampledData => sampledData.ProjectToType<SampledDataDto>());

      return Results.Ok(ApiResponse.Success(sampledData));
    }

  }
}
