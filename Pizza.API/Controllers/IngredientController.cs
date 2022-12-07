using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.DTOs.Responses;
using Pizza.Application.Services.Interfaces;

namespace Pizza.API.Controllers;
[Route("[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    private readonly IMapper _mapper;

    public IngredientController(IIngredientService ingredientService, IMapper mapper)
	{
        _ingredientService = ingredientService;
        _mapper = mapper;
    }

    [HttpGet("/Ingredients")]
    public async Task<IList<IngredientResponse>> GetIngredientsAsync()
    {
        var ingredients = await _ingredientService.GetIngredientsAsync();
        return _mapper.Map<IList<IngredientResponse>>(ingredients);
    }
}
