using Carter;
using ManageTemplate.WebApi.Extensions;
using ManageTemplate.WebApi.Mapsters;
using ManageTemplate.WebApi.Validations;

var builder = WebApplication.CreateBuilder(args);

{
  builder
    .ConfigureCors()
    .ConfigureServices()
    .ConfigureSwaggerOpenApi()
    .ConfigureMapster()
    .ConfigureFluentValidation();
}


var app = builder.Build();

{
  app.SetupRequestPipeline();

  app.MapCarter();

  app.UseDataSeeder();

  app.Run();
}

public partial class Program { }
