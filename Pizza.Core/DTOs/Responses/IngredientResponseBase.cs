using Pizza.Domain.Enums;

namespace Pizza.Application.DTOs.Responses;

public class IngredientResponseBase
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public IngredientType IngredientType { get; set; }
}
