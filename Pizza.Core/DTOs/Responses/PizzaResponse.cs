namespace Pizza.Application.DTOs.Responses;

public class PizzaResponse
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public IList<IngredientResponseBase>? Ingredients { get; set; }
}
