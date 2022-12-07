using Pizza.Application.DTOs;

namespace Pizza.Application.Services.Interfaces;

public interface IIngredientService
{
    Task<IList<IngredientDto>> GetIngredientsAsync();
}
