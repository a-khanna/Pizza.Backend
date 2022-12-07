using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.DTOs.Responses;
using Pizza.Application.Services.Interfaces;

namespace Pizza.API.Controllers;
[Route("[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;
    private readonly IMapper _mapper;

    public PizzaController(IPizzaService pizzaService, IMapper mapper)
	{
        _pizzaService = pizzaService;
        _mapper = mapper;
    }

    [HttpGet("/Pizzas")]
    public async Task<IList<PizzaResponse>> GetPizzasAsync()
    {
        var pizzas = await _pizzaService.GetPizzasAsync();
        return _mapper.Map<IList<PizzaResponse>>(pizzas);
    }
}
