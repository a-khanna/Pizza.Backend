using Pizza.Application.DTOs;

namespace Pizza.Application.Services.Interfaces;

public interface IPriceService
{
    decimal CalculatePrice(PizzaDto pizzaDto);
}
