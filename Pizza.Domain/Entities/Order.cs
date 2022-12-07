namespace Pizza.Domain.Entities;

public class Order : EntityBase
{
    public ICollection<Pizza>? Pizzas { get; set; }

    public ICollection<Side>? Sides { get; set; }
}
