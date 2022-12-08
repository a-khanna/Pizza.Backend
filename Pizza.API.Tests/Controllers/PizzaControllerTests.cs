using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Pizza.API.Controllers;
using Pizza.Application.DTOs;
using Pizza.Application.Mappings;
using Pizza.Application.Services.Interfaces;

namespace Pizza.API.Tests.Controllers;

public class PizzaControllerTests
{
    private readonly Mock<IPizzaService> _pizzaServiceMock = new();
    private readonly IMapper _mapper = new MapperConfiguration(config => config.AddProfile<MapperProfile>()).CreateMapper();
    private readonly Fixture _fixture = new();
    private PizzaController? _pizzaController;

    [Fact]
    public async Task GetPizzasAsync_ShouldReturnAListOfPizzas()
    {
        // Arrange
        var pizzas = _fixture.Create<List<PizzaDto>>();
        _pizzaServiceMock.Setup(i => i.GetPizzasAsync()).ReturnsAsync(pizzas);
        _pizzaController = new(_pizzaServiceMock.Object, _mapper);

        // Act
        var result = await _pizzaController.GetPizzasAsync();

        // Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(3);

        var expectedIds = pizzas.Select(i => i.Id).ToList();
        var actualIds = result.Select(r => r.Id).ToList();
        actualIds.Should().Contain(expectedIds);
    }
}
