using Pizza.Domain.Enums;

namespace Pizza.Application.DTOs;

public class IngredientDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public IngredientType IngredientType { get; set; }

    public decimal Price { get; set; }
}
