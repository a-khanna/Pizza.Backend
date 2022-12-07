using Pizza.Domain.Enums;

namespace Pizza.Application.DTOs;

public class PizzaDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Size Size { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public IList<IngredientDto>? Ingredients { get; set; }
}
