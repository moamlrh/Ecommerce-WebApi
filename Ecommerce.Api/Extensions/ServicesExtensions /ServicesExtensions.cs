using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
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

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityRole>(opts =>
            {
                // opts.Password.RequireLowercase = true;
                // opts.Password.RequireDigit = true;
                // opts.User.AllowedUserNameCharacters = String.Empty;
                opts.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }
}
