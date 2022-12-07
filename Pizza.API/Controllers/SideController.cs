using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.DTOs.Responses;
using Pizza.Application.Services.Interfaces;

namespace Pizza.API.Controllers;
[Route("[controller]")]
[ApiController]
public class SideController : ControllerBase
{
    private readonly ISideService _sideService;
    private readonly IMapper _mapper;

    public SideController(ISideService pizzaService, IMapper mapper)
	{
        _sideService = pizzaService;
        _mapper = mapper;
    }

    [HttpGet("/Sides")]
    public async Task<IList<SideResponse>> GetPizzasAsync()
    {
        var sides = await _sideService.GetSidesAsync();
        return _mapper.Map<IList<SideResponse>>(sides);
    }
}
