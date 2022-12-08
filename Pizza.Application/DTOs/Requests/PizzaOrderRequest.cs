using Pizza.Domain.Enums;

namespace Pizza.Application.DTOs.Requests;

public class PizzaOrderRequest
{
    public Size Size { get; set; }

    public int Quantity { get; set; }

    public IList<IngredientOrderRequest>? Ingredients { get; set; }
}
