using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza.Infrastructure.Persistence.Interfaces;
using Pizza.Infrastructure.Persistence.Repositories;

namespace Pizza.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static void AddDatabaseAndSeeder(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("Database")));
        services.AddScoped<DataSeeder>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPizzaRepository, PizzaRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
    }
}
