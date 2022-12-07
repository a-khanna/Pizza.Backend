using Pizza.Infrastructure.Persistence.Repositories.Interfaces;

namespace Pizza.Infrastructure.Persistence.Repositories;

public class BaseRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public BaseRepository(AppDbContext appDbContext)
	{
        _appDbContext = appDbContext;
    }

    public Task SaveChangesAsync()
    {
        return _appDbContext.SaveChangesAsync();
    }
}
