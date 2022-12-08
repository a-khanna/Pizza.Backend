using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pizza.API.Controllers;
using Pizza.Application.DTOs;
using Pizza.Application.DTOs.Requests;
using Pizza.Application.DTOs.Responses;
using Pizza.Application.Mappings;
using Pizza.Application.Services.Interfaces;
using Pizza.Application.Validators;

namespace Pizza.API.Tests.Controllers;

public class OrderControllerTests
{
    private readonly Mock<IOrderService> _orderServiceMock = new();
    private readonly Mock<ICreateOrderValidator> _validatorMock = new();
    private readonly IMapper _mapper = new MapperConfiguration(config => config.AddProfile<MapperProfile>()).CreateMapper();
    private readonly Fixture _fixture = new();
    private OrderController? _orderController;

    [Fact]
    public async Task GetOrdersAsync_ShouldReturnAListOfOrders()
    {
        // Arrange
        var orders = _fixture.Create<List<OrderDto>>();
        _orderServiceMock.Setup(i => i.GetOrdersAsync()).ReturnsAsync(orders);
        _orderController = new(_orderServiceMock.Object, _mapper, _validatorMock.Object);

        // Act
        var result = await _orderController.GetOrdersAsync();

        // Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(3);

        var expectedIds = orders.Select(i => i.Id).ToList();
        var actualIds = result.Select(r => r.Id).ToList();
        actualIds.Should().Contain(expectedIds);
    }

    [Fact]
    public async Task CreateOrdersAsync_ShouldValidateOrderAndInvokeOrderService()
    {
        // Arrange
        var orderRequest = _fixture.Create<CreateOrderRequest>();
        _orderServiceMock.Setup(i => i.AddOrderAsync(It.IsAny<OrderDto>())).ReturnsAsync(new OrderDto { Id = 1 });
        _orderController = new(_orderServiceMock.Object, _mapper, _validatorMock.Object);

        // Act
        var result = await _orderController.CreateOrderAsync(orderRequest);

        // Assert
        _validatorMock.Verify(v => v.ValidateAndThrow(orderRequest));

        result.Should().NotBeNull();
        ((result as CreatedResult)!.Value as CreateOrderResponse)!.Id.Should().Be(1);
    }
}
