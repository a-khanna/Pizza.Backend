using Pizza.Domain.Enums;

namespace Pizza.Domain.Entities;

public class Ingredient : EntityBase
{
    public string? Name { get; set; }

    public IngredientType IngredientType { get; set;}

    public decimal Price { get; set; }

    public ICollection<Pizza>? Pizzas { get; set; }
}
