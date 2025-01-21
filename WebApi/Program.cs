using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureServices(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        Configure(app);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSwaggerGen(c =>
        {
            // Configuration de la documentation Swagger
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Tennis Player Stats API Test",
                Version = "v1",
                Description = "This API provides player statistics, using clean architecture with CQRS and Mediator pattern",
                Contact = new OpenApiContact
                {
                    Name = "Jennen Ilyes",
                    Email = "ilyes.jannen@gmail.com",
                    Url = new Uri("https://github.com/IlyesJannen/TennisProjectCleanArchitecture"),
                }
            });

        });

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Application).Assembly));
        services.AddSingleton<IPlayerStatsRepository, PlayerStatsRepository>();
    }

    private static void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}