using Pizza.Domain.Entities;
using Pizza.Infrastructure.Persistence.Repositories.Interfaces;

namespace Pizza.Infrastructure.Persistence.Interfaces;

public interface ISideRepository : IBaseRepository
{
    Task<IList<Side>> GetSidesAsync();
}
