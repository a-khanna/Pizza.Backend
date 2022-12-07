using AutoMapper;
using Pizza.Application.DTOs;
using Pizza.Application.Services.Interfaces;
using Pizza.Infrastructure.Persistence.Interfaces;
using Pizza.Infrastructure.Persistence.Repositories;

namespace Pizza.Core.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
	{
        _ingredientRepository = ingredientRepository;
        _mapper = mapper;
    }

    public async Task<IList<IngredientDto>> GetIngredientsAsync()
    {
        var ingredientEntities = await _ingredientRepository.GetIngredientsAsync();
        return _mapper.Map<IList<IngredientDto>>(ingredientEntities);
    }
}
