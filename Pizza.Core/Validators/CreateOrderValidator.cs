using Pizza.Application.DTOs.Requests;
using Pizza.Application.Exceptions;

namespace Pizza.Application.Validators;

public class CreateOrderValidator : ICreateOrderValidator
{
    public void ValidateAndThrow(CreateOrderRequest request)
    {
        if (request == null)
            throw new ValidationException("Request cannot be null");

        if ((!request.Pizzas?.Any() ?? true) && (!request.Sides?.Any() ?? true))
            throw new ValidationException("At least one pizza or one side must be provided.");

        if (request.Pizzas?.Any() ?? false)
        {
            foreach (var pizza in request.Pizzas)
            {
                if (pizza.Quantity <= 0)
                    throw new ValidationException("Pizza Quantity cannot be less than 1");

                if (pizza.Ingredients?.Any() ?? false)
                    throw new ValidationException("Ingredients cannot be null or empty");
            }
        }

        if (request.Sides?.Any() ?? false)
        {
            foreach (var side in request.Sides)
            {
                if (side.Quantity <= 0)
                    throw new ValidationException("Side Quantity cannot be less than 1");
            }
        }
    }
}
