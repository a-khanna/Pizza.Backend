using Pizza.Domain.Entities;
using Pizza.Infrastructure.Persistence.Repositories.Interfaces;

namespace Pizza.Infrastructure.Persistence.Interfaces;

public interface IOrderRepository : IBaseRepository
{
    Task<IList<Order>> GetOrdersAsync();

    Task<Order> AddOrderAsync(Order order);
}
