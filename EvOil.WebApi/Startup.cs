using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using EvOil.Business.Infrastructure;
using EvOil.Business.Services.Abstractions;
using EvOil.Business.Services.Implementations;
using EvOil.Persistence;
using EvOil.WebApi.Infrastructure;

namespace EvOil.WebApi;

internal sealed partial class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Configures Applications DI IoC Container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddScoped<IUserValidatorService, UserValidatorService>();
        _ = services.AddScoped<IUserService, UserService>();
        _ = services.AddScoped<IOilValidatorService, OilValidatorService>();
        _ = services.AddScoped<IOilService, OilService>();
        _ = services.AddScoped<IOrganizerValidatorService, OrganizerValidatorService>();
        _ = services.AddScoped<IOrganizerService, OrganizerService>();
        _ = services.AddScoped<IEvaluationValidatorService, EvaluationValidatorService>();
        _ = services.AddScoped<IEvaluationService, EvaluationService>();

        _ = services.AddControllers();

        _ = services.AddDbContext<IEvOilDatabaseContext, EvOilDatabaseContext>(dbContextOptionsBuilder =>
        {
            _ = dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalDatabase"));
        });

        services.AddSpaStaticFiles(configuration => configuration.RootPath = "../client/build");
    }

    /// <summary>
    /// Configures Application Middleware.
    /// </summary>
    /// <param name="app"></param>
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        _ = app.UseMiddleware<ExceptionMiddleware>();

        _ = app.UseRouting();

        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = Path.Join(env.ContentRootPath, "../client");
        });

        _ = app.UseEndpoints(endpoints =>
          {
              _ = endpoints.MapControllers();
          });
    }
}
