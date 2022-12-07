namespace Pizza.Application.DTOs;

public class OrderDto
{
    public int Id { get; set; }

    public IList<PizzaDto>? Pizzas { get; set; }

    public IList<SideDto>? Sides { get; set; }
}
