using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Infrastructure.Persistence.Repositories;

public class IngredientRepository : BaseRepository, IIngredientRepository
{
    private readonly AppDbContext _dbContext;

    public IngredientRepository(AppDbContext dbContext) : base(dbContext)
	{
        _dbContext = dbContext;
    }

    public async Task<IList<Ingredient>> GetIngredientsAsync()
    {
        var entities = await _dbContext.Ingredients.ToListAsync();
        return entities;
    }
}
