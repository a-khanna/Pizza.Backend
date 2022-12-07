using Microsoft.EntityFrameworkCore;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Infrastructure.Persistence.Repositories;

public class PizzaRepository : BaseRepository, IPizzaRepository
{
    private readonly AppDbContext _dbContext;

    public PizzaRepository(AppDbContext dbContext) : base(dbContext)
	{
        _dbContext = dbContext;
    }

    public async Task<IList<Domain.Entities.Pizza>> GetPizzasAsync()
    {
        var result = await _dbContext.Pizzas
            .Include(p => p.Ingredients)
            .ToListAsync();

        return result;
    }
}
