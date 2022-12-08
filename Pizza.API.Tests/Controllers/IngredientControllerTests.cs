using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Pizza.API.Controllers;
using Pizza.Application.DTOs;
using Pizza.Application.Mappings;
using Pizza.Application.Services.Interfaces;

namespace Pizza.API.Tests.Controllers;

public class IngredientControllerTests
{
    private readonly Mock<IIngredientService> _ingredientServiceMock = new();
    private readonly IMapper _mapper = new MapperConfiguration(config => config.AddProfile<MapperProfile>()).CreateMapper();
    private readonly Fixture _fixture = new();
    private IngredientController? _ingredientController;

    [Fact]
    public async Task GetIngredientsAsync_ShouldReturnAListOfIngredients()
    {
        // Arrange
        var ingredients = _fixture.Create<List<IngredientDto>>();
        _ingredientServiceMock.Setup(i => i.GetIngredientsAsync()).ReturnsAsync(ingredients);
        _ingredientController = new(_ingredientServiceMock.Object, _mapper);

        // Act
        var result = await _ingredientController.GetIngredientsAsync();

        // Assert
        result.Should().NotBeEmpty();
        result.Count.Should().Be(3);

        var expectedIds = ingredients.Select(i => i.Id).ToList();
        var actualIds = result.Select(r => r.Id).ToList();
        actualIds.Should().Contain(expectedIds);
    }
}
