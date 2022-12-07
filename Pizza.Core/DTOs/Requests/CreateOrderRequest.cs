namespace Pizza.Application.DTOs.Requests;

public class CreateOrderRequest
{
    public IList<PizzaOrderRequest>? Pizzas { get; set; }

    public IList<SideOrderRequest>? Sides { get; set; }
}
