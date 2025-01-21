using Application.Interfaces.Repositories;
using Domain.PlayerStats;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<PlayerDbContext>();
            context.Database.EnsureCreated(); 
            SeedDatabase(context);
        }

        Configure(app);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSwaggerGen(c =>
        {
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

        services.AddDbContext<PlayerDbContext>(options =>
            options.UseInMemoryDatabase("TennisPlayersDB"));

        services.AddScoped<IPlayerStatsRepository, PlayerStatsRepository>();
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
    private static void SeedDatabase(PlayerDbContext context)
    {
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "tennisData.json");
        var jsonData = File.ReadAllText(jsonPath);
        var playersData = JsonConvert.DeserializeObject<List<Player>>(jsonData);

        if (playersData != null)
        {
            context.Players.AddRangeAsync(playersData);
            context.SaveChangesAsync();
        }
    }
}