using Ecommerce.Contracts;
using Ecommerce.Repository;
using Ecommerce.Service;
using Ecommerce.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
            })
            .AddApplicationPart(typeof(Presentation.Controllers.UserController).Assembly);
    }

    public static void ConfigureSqlServer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SqlServerString");
            options.UseSqlServer(
                connectionString,
                options => options.MigrationsAssembly("Ecommerce.Api")
            );
        });
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection service) =>
        service.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(Ecommerce.Api.MapperProfile).Assembly);
}
