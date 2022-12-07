namespace Pizza.Domain.Entities;

public class Side : EntityBase
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool IsCustom { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
