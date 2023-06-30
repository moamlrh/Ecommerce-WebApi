using Ecommerce.Api.Extensions;
using Ecommerce.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(
                // To enable our custom responses from the actions for validation
                opts => opts.SuppressModelStateInvalidFilter = true
            );
            builder.Services.ConfigureControllers(); // Extension
            builder.Services.AddEndpointsApiExplorer();

            // Enable it for Swagger usage
            // builder.Services.AddSwaggerGen();

            // Action Filter test
            // builder.Services.AddScoped<ValidationUserFilter>();

            // Service Extensions
            builder.Services.ConfigureSqlServer(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureAutoMapper();
            builder.Services.AddAuthentication(); // auth Identity
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);

            var app = builder.Build();

            // if (app.Environment.IsDevelopment())
            // {
            // -- Enable it for swagger usage --
            // app.UseSwagger();
            // app.UseSwaggerUI();
            // }

            app.UseCors();
            app.UseHttpsRedirection();

            // auth Identity
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
