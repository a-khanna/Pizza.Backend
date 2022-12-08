using AutoMapper;
using Pizza.Application.DTOs;
using Pizza.Application.Services.Interfaces;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Core.Services;

public class PizzaService : IPizzaService
{
    private readonly IPizzaRepository _pizzaRepository;
    private readonly IPriceService _priceService;
    private readonly IMapper _mapper;

    public PizzaService(IPizzaRepository pizzaRepository, IMapper mapper, IPriceService priceService)
    {
        _pizzaRepository = pizzaRepository;
        _mapper = mapper;
        _priceService = priceService;
    }

    public async Task<IList<PizzaDto>> GetPizzasAsync()
    {
        var pizzaEntities = await _pizzaRepository.GetPizzasAsync();
        var dtos = _mapper.Map<IList<PizzaDto>>(pizzaEntities);

        foreach (var dto in dtos)
            dto.Price = _priceService.CalculatePrice(dto);

        return dtos;
    }
}
