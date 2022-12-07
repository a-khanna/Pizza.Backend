using Pizza.Application.DTOs;
using Pizza.Application.Services.Interfaces;

namespace Pizza.Application.Services;

public class PriceService : IPriceService
{
    public decimal CalculatePrice(PizzaDto pizzaDto)
    {
        var result = 0m;

        foreach(var ingredient in pizzaDto.Ingredients!)
            result += ingredient.Price;

        if (pizzaDto.Size == Domain.Enums.Size.Small)
            result += 50;
        else if (pizzaDto.Size == Domain.Enums.Size.Medium)
            result += 80;
        else
            result += 100;

        return result;
    }
}
