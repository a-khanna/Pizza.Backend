using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.DTOs;
using Pizza.Application.DTOs.Requests;
using Pizza.Application.DTOs.Responses;
using Pizza.Application.Services.Interfaces;
using Pizza.Application.Validators;

namespace Pizza.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    private readonly ICreateOrderValidator _createOrderValidator;

    public OrderController(IOrderService orderService, IMapper mapper, ICreateOrderValidator createOrderValidator)
    {
        _orderService = orderService;
        _mapper = mapper;
        _createOrderValidator = createOrderValidator;
    }

    [HttpGet("/Orders")]
    public async Task<IList<OrderResponse>> GetOrdersAsync()
    {
        var orders = await _orderService.GetOrdersAsync();
        return _mapper.Map<IList<OrderResponse>>(orders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody]CreateOrderRequest request)
    {
        _createOrderValidator.ValidateAndThrow(request);

        var order = _mapper.Map<OrderDto>(request);
        var result = await _orderService.AddOrderAsync(order);

        return new CreatedResult(string.Empty, _mapper.Map<CreateOrderResponse>(result));
    }
}
