using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ManageTemplate.WebApi.Filters
{
  public class GuidParamaterFilter : IParameterFilter
  {
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
      if (parameter.Schema.Type == "string" &&
            context.ApiParameterDescription.Type == typeof(Guid))
      {
        parameter.Schema.Format = "uuid";
      }
    }

  }
}
