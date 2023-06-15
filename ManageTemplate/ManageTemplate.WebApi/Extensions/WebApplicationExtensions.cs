using Carter;
using ManageTemplate.Data.Contexts;
using ManageTemplate.Data.Seeders;
using ManageTemplate.Services.Musics.Categories;
using ManageTemplate.Services.Templates.Categories;
using ManageTemplate.Services.Templates.SampledDataService;
using ManageTemplate.Services.Templates.Sections;
using Microsoft.EntityFrameworkCore;

namespace ManageTemplate.WebApi.Extensions
{
  public static class WebApplicationExtensions
  {

    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
      builder.Services.AddCarter();
      builder.Services.AddMemoryCache();
      builder.Services.AddDbContext<TemplateDbContext>(options =>
          options.UseSqlServer(
            builder.Configuration
              .GetConnectionString("DefaultConnection")));

      builder.Services.AddScoped<IDataSeeder, DataSeeder>();

      builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
      builder.Services.AddScoped<ISectionRepository, SectionRepository>();
      builder.Services.AddScoped<ISampledDataRepository, SampledDataRepository>();

      return builder;
    }


    public static WebApplicationBuilder ConfigureCors(
     this WebApplicationBuilder builder)
    {
      builder.Services.AddCors(options =>
      {
        options.AddPolicy("ManageTemplate", policyBuilder =>
                  policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
      });
      return builder;
    }

    public static WebApplicationBuilder ConfigureSwaggerOpenApi(
      this WebApplicationBuilder builder)
    {
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      return builder;
    }

    public static WebApplication SetupRequestPipeline(
      this WebApplication app)
    {

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseStaticFiles();
      app.UseHttpsRedirection();

      app.UseCors("ManageTemplate");

      return app;
    }

    public static IApplicationBuilder UseDataSeeder(
      this IApplicationBuilder app)
    {
      using var scope = app.ApplicationServices.CreateScope();
      try
      {
        scope.ServiceProvider
          .GetRequiredService<IDataSeeder>()
          .Intitalize();
      }
      catch (Exception ex)
      {
        scope.ServiceProvider
            .GetRequiredService<ILogger<Program>>()
            .LogError(ex, "Could not insert data into database");
      }
      return app;
    }
  }
}