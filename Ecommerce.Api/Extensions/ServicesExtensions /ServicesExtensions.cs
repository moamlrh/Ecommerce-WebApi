using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using Ecommerce.Presentation.Controllers;
using Ecommerce.Repository;
using Ecommerce.Service;
using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Api.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureControllers(this IServiceCollection services)
    {
        services
            .AddControllers(config => config.RespectBrowserAcceptHeader = true)
            .AddApplicationPart(typeof(UserController).Assembly);
    }

    public static void ConfigureSqlServer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            var constr = configuration.GetConnectionString("SqlServerString");
            options.UseSqlServer(constr, options => options.MigrationsAssembly("Ecommerce.Api"));
        });
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection service) =>
        service.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(config =>
        {
            config.Password.RequireLowercase = true;
            config.Password.RequireDigit = true;
            config.User.AllowedUserNameCharacters = String.Empty;
            config.User.RequireUniqueEmail = true;
        });
    }
}
