using Pizza.Application.DTOs;

namespace Pizza.Application.Services.Interfaces;

public interface IPizzaService
{
    Task<IList<PizzaDto>> GetPizzasAsync();
}
