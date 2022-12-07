using Pizza.Infrastructure.Persistence.Repositories.Interfaces;

namespace Pizza.Infrastructure.Persistence.Interfaces;

public interface IPizzaRepository : IBaseRepository
{
    Task<IList<Domain.Entities.Pizza>> GetPizzasAsync();
}
