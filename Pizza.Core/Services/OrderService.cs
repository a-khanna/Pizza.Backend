using AutoMapper;
using Pizza.Application.DTOs;
using Pizza.Application.Services.Interfaces;
using Pizza.Domain.Entities;
using Pizza.Infrastructure.Persistence.Interfaces;

namespace Pizza.Application.Services;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<IList<OrderDto>> GetOrdersAsync()
    {
        var orderEntities = await _orderRepository.GetOrdersAsync();
        return _mapper.Map<IList<OrderDto>>(orderEntities);
    }

    public async Task<OrderDto> AddOrderAsync(OrderDto order)
    {
        var orderEntity = _mapper.Map<Order>(order);

        var savedEntity = await _orderRepository.AddOrderAsync(orderEntity);
        return _mapper.Map<OrderDto>(savedEntity);
    }
}
