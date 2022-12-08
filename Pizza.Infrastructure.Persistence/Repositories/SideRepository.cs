using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Infrastructure.Persistence.Repositories;

public class SideRepository : BaseRepository, ISideRepository
{
    private readonly AppDbContext _dbContext;

    public SideRepository(AppDbContext dbContext) : base(dbContext)
	{
        _dbContext = dbContext;
    }

    public async Task<IList<Side>> GetSidesAsync()
    {
        var entities = await _dbContext.Sides
            .Where(p => !p.IsCustom)
            .ToListAsync();
        return entities;
    }
}
