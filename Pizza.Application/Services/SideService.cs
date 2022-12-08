using AutoMapper;
using Pizza.Application.DTOs;
using Pizza.Application.Services.Interfaces;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Core.Services;

public class SideService : ISideService
{
    private readonly ISideRepository _sideRepository;
    private readonly IMapper _mapper;

    public SideService(ISideRepository sideRepository, IMapper mapper)
	{
        _sideRepository = sideRepository;
        _mapper = mapper;
    }

    public async Task<IList<SideDto>> GetSidesAsync()
    {
        var sideEntities = await _sideRepository.GetSidesAsync();
        return _mapper.Map<IList<SideDto>>(sideEntities);
    }
}
