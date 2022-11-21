using BestPractices.Api.Extensions;
using BestPractices.Api.Service.ContactFeatures;

namespace BestPractices.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();
            builder.Services.AddEndpointsApiExplorer();

            // Services
            builder.Services.ConfigureCustomMapping();

            builder.Services.AddScoped<IContactService, ContactService>();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomHealthCheck();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.UseAuthorization();

            app.Run();
        }
    }
}