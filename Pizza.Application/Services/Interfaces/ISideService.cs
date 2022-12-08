using Pizza.Application.DTOs;

namespace Pizza.Application.Services.Interfaces;

public interface ISideService
{
    Task<IList<SideDto>> GetSidesAsync();
}
