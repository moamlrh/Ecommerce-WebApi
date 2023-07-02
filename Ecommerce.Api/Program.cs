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

            builder.Services.ConfigureControllers(); // Extension
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureApiBehaviorOptions(); // Extension
            builder.Services.AddSwaggerGen();

            // Action Filter test
            // builder.Services.AddScoped<ValidationUserFilter>();

            // Service Extensions
            builder.Services.ConfigureSqlServer(builder.Configuration);
            builder.Services.ConfigureCors();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureAutoMapper();
            builder.Services.AddAuthentication(); // Auth Identity
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();

            // Extenstions
            app.ConfigureExceptionHandler();

            // auth Identity
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}