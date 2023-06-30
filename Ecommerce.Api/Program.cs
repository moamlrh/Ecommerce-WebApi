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
                opts => opts.SuppressModelStateInvalidFilter = true // To enable our custom responses from the actions for validation
            );
            builder.Services.ConfigureControllers(); // Extension
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // builder.Services.AddScoped<ValidationUserFilter>(); // Action Filter test

            // Service Extensions
            builder.Services.ConfigureSqlServer(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureAutoMapper();
            builder.Services.AddAuthentication(); // auth Identity
            builder.Services.ConfigureIdentity();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // auth Identity 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
