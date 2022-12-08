using AutoFixture;
using FluentAssertions;
using Pizza.Application.DTOs.Requests;
using Pizza.Application.Exceptions;
using Pizza.Application.Validators;

namespace Pizza.Application.Tests.Validators;

public class CreateOrderValidatorTests
{
    private readonly CreateOrderValidator _validator = new();
    private static readonly Fixture _fixture = new();

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void ValidateAndThrow_ShouldThrowWhenValidationFails(CreateOrderRequest order, string expectedMessage)
    {
        // Act
        var exception = Assert.Throws<ValidationException>(() => _validator.ValidateAndThrow(order));

        // Assert
        exception.Message.Should().Be(expectedMessage);
    }

    public static IEnumerable<object?[]> GetTestData()
    {
        var noPizzaOrSide = new CreateOrderRequest
        {
            Pizzas = new List<PizzaOrderRequest>(),
            Sides = new List<SideOrderRequest>()
        };

        var wrongPizzaQuantity = _fixture.Create<CreateOrderRequest>();
        wrongPizzaQuantity.Pizzas!.ElementAt(0).Quantity = 0;

        var wrongSideQuantity = _fixture.Create<CreateOrderRequest>();
        wrongPizzaQuantity.Sides!.ElementAt(0).Quantity = 0;

        return new List<object?[]>
        {
            new object?[] { null, "Request cannot be null" },
            new object?[] { noPizzaOrSide, "At least one pizza or one side must be provided." },
            new object?[] { wrongPizzaQuantity, "Pizza Quantity cannot be less than 1" },
            new object?[] { wrongPizzaQuantity, "Side Quantity cannot be less than 1" }
        };
    }
}
