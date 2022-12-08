using Pizza.Application.DTOs;

namespace Pizza.Application.Services.Interfaces;

public interface IOrderService
{
    Task<IList<OrderDto>> GetOrdersAsync();

    Task<OrderDto> AddOrderAsync(OrderDto order);
}
