using Pizza.Domain.Enums;

namespace Pizza.Application.DTOs.Responses;

public class PizzaOrderResponse
{
    public int Id { get; set; }

    public Size Size { get; set; }

    public int Quantity { get; set; }

    public IList<IngredientOrderResponse>? Ingredients { get; set; }
}
