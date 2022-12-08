namespace Pizza.Infrastructure.Persistence.Repositories.Interfaces;

public interface IBaseRepository
{
    Task SaveChangesAsync();
}
