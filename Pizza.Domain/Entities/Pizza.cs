using Pizza.Domain.Enums;

namespace Pizza.Domain.Entities;

public class Pizza : EntityBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Size Size { get; set; }

    public bool IsCustom { get; set; }

    public int Quantity { get; set; }

    public ICollection<Ingredient>? Ingredients { get; set; }
}
