using Microsoft.Extensions.DependencyInjection;
using Pizza.Application.Services;
using Pizza.Application.Services.Interfaces;
using Pizza.Core.Services;

namespace Pizza.Application;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPizzaService, PizzaService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IIngredientService, IngredientService>();
        services.AddTransient<ISideService, SideService>();
        services.AddTransient<IPriceService, PriceService>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
