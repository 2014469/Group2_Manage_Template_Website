using Carter;

namespace ManageTemplate.WebApi.Endpoints
{
  public class SectionsEndpoint : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      var routeGroupBuilder = app.MapGroup("/api/sections");

    }
  }
}
